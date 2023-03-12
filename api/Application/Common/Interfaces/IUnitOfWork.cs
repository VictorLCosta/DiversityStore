using Api.Application.Common.Interfaces.Repositories;

namespace Api.Application.Common.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IProductRepository ProductRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    ISaleRepository SaleRepository { get; }
    IStockRepository StockRepository { get; }

    Task<bool> Complete();
}
