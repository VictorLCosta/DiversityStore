using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;

namespace Api.Infrastructure.Persistence.Repositories;

public class StockRepository : Repository<Stock>, IStockRepository
{
    public StockRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}
