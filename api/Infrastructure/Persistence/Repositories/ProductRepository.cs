using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;

namespace Api.Infrastructure.Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}
