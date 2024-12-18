﻿using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task SaveAsync();
        Task DeleteAsync(T entity);
        Task<T> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            bool tracked = true
            );
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null
            );
    }
}
