using Microsoft.EntityFrameworkCore;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(ApplicationDbContext context) : base(context) { }

        public  async Task<IEnumerable<Contact>> GetAllContactsAsync(int pageNumber, int pageSize, string search)
        {
            Func<IQueryable<Contact>, IQueryable<Contact>> filter =  query =>
            {
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search) || p.Email.Contains(search) || p.PhoneNumber.Contains(search));
                }

                return  query;
            };

            return await GetAllAsync(pageNumber, pageSize, filter);
        }
    }
}
