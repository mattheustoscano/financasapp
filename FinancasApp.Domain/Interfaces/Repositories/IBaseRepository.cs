using FinancasApp.Domain.Utils;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PageResult<TEntity>> GetAllAsync(int pageNumber, int pageSize);
        Task<TEntity?> GetByIdAsync(Tkey id);
    }
}
