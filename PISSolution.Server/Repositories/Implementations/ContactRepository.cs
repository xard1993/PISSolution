using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(ApplicationDbContext context, ILogger<Repository<Contact>> logger) : base(context, logger) { 
     
        }
        
        // creates a contact specific filter than calls the Repo methos GetAllAsync
        public async Task<IEnumerable<Contact>> GetAllContactsAsync(int pageNumber, int pageSize, string search)
        {
            try
            {
                Func<IQueryable<Contact>, IQueryable<Contact>> filter = query =>
                {
                    if (!string.IsNullOrEmpty(search))
                    {
                        query = query.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search) || p.Email.Contains(search) || p.PhoneNumber.Contains(search));
                    }

                    return query;
                };

                return await GetAllAsync(pageNumber, pageSize, filter);
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred retrieving all records with filter {filter}", search);
                throw;
            }
}
    }
}
