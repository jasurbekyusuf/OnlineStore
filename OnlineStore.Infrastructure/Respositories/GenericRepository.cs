using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected OnlinestoreContext onlinestoreContext;
        internal DbSet<T> dbSet;
        public GenericRepository(OnlinestoreContext onlinestoreContext)
        {
            this.onlinestoreContext = onlinestoreContext;
            this.dbSet = onlinestoreContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            if (entity is null)
                return false;

            dbSet.Remove(entity);

            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbSet : dbSet.Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            return entry.Entity;
        }
    }
}
