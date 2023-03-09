using Api.Application.Common.Interfaces.Repositories;

namespace Api.Application.Common.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IProductRepository ProductRepository { get; }

    Task<bool> Complete();
}
