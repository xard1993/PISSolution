using Microsoft.EntityFrameworkCore;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{

    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {

        public PropertyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync(int pageNumber, int pageSize, string search)
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

        public async Task<Property> GetPropertyByIdAsync(Guid id)
        {
            return await _dbSet.Include(p => p.Ownerships).ThenInclude(o => o.Contact)
                             .Include(p => p.PriceHistories).FirstOrDefaultAsync(i => i.ID == id);
        }
    }
}



