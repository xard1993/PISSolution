using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(ApplicationDbContext context) : base(context) { }
    
    }
}
