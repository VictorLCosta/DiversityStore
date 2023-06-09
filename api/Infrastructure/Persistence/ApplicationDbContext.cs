using System.Reflection;

using Api.Application.Common.Interfaces;
using Api.Domain.Common;
using Api.Domain.Entities;
using Api.Domain.Entities.Identity;
using Api.Domain.Enum;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SalesItems => Set<SaleItem>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entity in builder.Model.GetEntityTypes().Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
        {
            var stringProps = entity.ClrType.GetProperties().Where(p => p.PropertyType == typeof(string));
            foreach (var prop in stringProps)
            {
                switch (prop.Name)
                {
                    case "Description":
                        builder.Entity(entity.Name).Property(prop.Name).HasColumnType("TEXT");
                        break;
                    default:
                        builder.Entity(entity.Name).Property(prop.Name).HasColumnType("varchar(150)");
                        break;
                }
            }
        }

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var item in builder.Model.GetEntityTypes())
            {
                var props = item.ClrType.GetProperties().Where(e => e.PropertyType == typeof(DateTimeOffset));
                foreach (var prop in props)
                {
                    builder.Entity(item.Name).Property(prop.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
         var entries = ChangeTracker
            .Entries<Stock>()
            .Where(e => e.State == EntityState.Added || (e.State == EntityState.Modified && e.Property(x => x.QuantityInStock).IsModified));

        foreach (var entry in entries)
        {
            var product = Products.FirstOrDefault(p => p.Id == entry.Entity.ProductId);

            if (product != null)
            {
                if (entry.Entity.QuantityInStock > 0)
                {
                    product.Status = ProductStatus.Available;
                }
                else
                {
                    product.Status = ProductStatus.OutOfStock;
                }
            }
        }

        return await base.SaveChangesAsync();
    }
}
