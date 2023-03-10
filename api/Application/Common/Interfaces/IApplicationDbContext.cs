using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Sale> Sales { get; }
    DbSet<SaleItem> SalesItems { get; }
    DbSet<Stock> Stocks { get; }
    DbSet<Customer> Customers { get; }
}
