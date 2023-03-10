using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistence.EntityConfig;

public class StockConfig : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder
            .HasOne(x => x.Product)
            .WithOne(x => x.Stock)
            .HasForeignKey<Stock>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
