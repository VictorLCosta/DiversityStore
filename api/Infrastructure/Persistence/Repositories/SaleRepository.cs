using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;

namespace Api.Infrastructure.Persistence.Repositories;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    public SaleRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}
