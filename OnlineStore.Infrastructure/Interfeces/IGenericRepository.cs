﻿using System.Linq.Expressions;

namespace OnlineStore.Infrastructure.Interfeces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
