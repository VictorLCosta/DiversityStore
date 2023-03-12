using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistence.Repositories;

public class StockRepository : Repository<Stock>, IStockRepository
{
    public StockRepository(ApplicationDbContext context) 
        : base(context)
    {
    }

    public async Task<Stock> GetByProductIdAsync(Guid productId)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == productId);

        return stock!;
    }
}
