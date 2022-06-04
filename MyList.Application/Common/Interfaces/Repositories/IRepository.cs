using System.Linq.Expressions;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T?> GetByIdAsync(object id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetWithPagingAsync(int take, int skip);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task CreateAsync(T entity);
    }
}
