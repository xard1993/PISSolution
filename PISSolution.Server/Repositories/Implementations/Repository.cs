using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PISSolution.Data;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger<Repository<T>> _logger;
        public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        // get all entity records using number pagesize and filter
        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, Func<IQueryable<T>, IQueryable<T>> filter = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = filter(query);
                }
                var totalCount = await query.CountAsync();
                var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred retrieving item with filter {filter}", filter);
                throw;
            }
        }

        //get one entity by id
        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred retrieving item with ID {id}", id);
                throw;
            }
        }

        //add entity
        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred adding entity {entity}", entity);
                throw;
            }
        }
        
        //add multiple entities
        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                await _dbSet.AddRangeAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred adding range of entities {entity}", entity);
                throw;
            }
        }

        //update entity
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred updating record ");
                throw;
            }

        }

        //update multiple entities
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.UpdateRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred updating range of records ");
                throw;
            }

        }
    }

}
