using PISSolution.Models;

namespace PISSolution.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, Func<IQueryable<T>, IQueryable<T>> filter = null);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> Entity);
        Task UpdateAsync(T Entity);
        Task UpdateRangeAsync(IEnumerable<T> Entitys);
   
    }
}
