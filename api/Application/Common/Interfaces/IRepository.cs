using System.Linq.Expressions;

namespace Api.Application.Common.Interfaces;

public interface IRepository<T>
{
    Task<T?> Get(Guid id);

    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    IQueryable<T> AsQueryable(Expression<Func<T, bool>>? predicate);

    Task<T> AddAsync(T entity);
        
    Task<T?> UpdateAsync(T entity);

    Task<bool> DeleteAsync(Guid id);
}
