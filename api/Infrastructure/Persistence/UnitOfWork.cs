using Api.Application.Common.Interfaces;
using Api.Application.Common.Interfaces.Repositories;
using Api.Infrastructure.Persistence.Repositories;

namespace Api.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Repositories

    public IProductRepository ProductRepository => new ProductRepository(_context);

    #endregion

    public async Task<bool> Complete()
        => await _context.SaveChangesAsync() > 0;

    public async ValueTask DisposeAsync()
        =>  await _context.DisposeAsync();
    
}
