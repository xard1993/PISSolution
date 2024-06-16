using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{

    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
         

        public PropertyRepository(ApplicationDbContext context, ILogger<PropertyRepository> logger) : base(context, logger) { }

        // creates a property specific filter than calls the Repo methos GetAllAsync
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync(int pageNumber, int pageSize, string search)
        {
            try
            {
                Func<IQueryable<Property>, IQueryable<Property>> filter = query =>
                {
                    if (!string.IsNullOrEmpty(search))
                    {
                        query = query.Where(p => p.PropertyName.Contains(search) || p.Address.Contains(search));
                    }

                    return query.Include(p => p.Ownerships).ThenInclude(o => o.Contact)
                                .Include(p => p.PriceHistories);
                };

                return await GetAllAsync(pageNumber, pageSize, filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred retrieving all prorperties with filter {filter}", search);
                throw;
            }
        }

        public async Task<Property> GetPropertyByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.Include(p => p.Ownerships).ThenInclude(o => o.Contact)
                                 .Include(p => p.PriceHistories).FirstOrDefaultAsync(i => i.ID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred retrieving a record with filter {filter}", id);
                throw;
            }
        }
    }
}



