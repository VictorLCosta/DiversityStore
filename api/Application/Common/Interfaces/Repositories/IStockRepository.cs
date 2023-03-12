using Api.Domain.Entities;

namespace Api.Application.Common.Interfaces.Repositories;

public interface IStockRepository : IRepository<Stock>
{
    Task<Stock> GetByProductIdAsync(Guid productId);
}
