﻿using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Utils;
using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>(DataContext dataContext) : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        public virtual async Task AddAsync(TEntity entity)
        {
            await dataContext.AddAsync(entity);
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            dataContext.Update(entity);
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            dataContext.Remove(entity);
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<PageResult<TEntity>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = dataContext.Set<TEntity>();

            var totalCount = await query.CountAsync();

            var items = await query
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PageResult<TEntity>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>().AnyAsync(where);
        }
    }
}
