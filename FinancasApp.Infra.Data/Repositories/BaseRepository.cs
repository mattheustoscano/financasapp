using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Utils;
using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinancasApp.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TKey>(DataContext dataContext) : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        public virtual async Task AddAsync(TEntity entity)
        {
            await dataContext.AddAsync(entity);
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

            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PageResult<TEntity>()
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

        public virtual async Task UpdateAsync(TEntity entity)
        {
            dataContext.Update(entity);
            await dataContext.SaveChangesAsync();
        }
    }
}
