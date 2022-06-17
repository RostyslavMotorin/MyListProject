using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Interfaces.Repositories;

namespace MyList.Data.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DBSet;

        public IQueryable<T> Entities => DBSet;

        protected GenericRepository(DbContext context)
        {
            Context = context;
            DBSet = context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            DBSet.Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            DBSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DBSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate is null
                ? throw new ArgumentNullException(nameof(predicate))
                : await DBSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate is null
                ? throw new ArgumentNullException(nameof(predicate))
                : await DBSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return id is null
                ? throw new ArgumentNullException(nameof(id))
                : await DBSet.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            DBSet.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWithPagingAsync(int take, int skip)
        {
            return await DBSet.Take(take).Skip(skip).ToListAsync();
        }

        public abstract Task<IEnumerable<T>> GetBySearch(string search);
    }
}
