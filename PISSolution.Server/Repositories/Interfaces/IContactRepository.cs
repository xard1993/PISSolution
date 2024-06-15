using PISSolution.Models;

namespace PISSolution.Repositories.Interfaces {

    public interface IContactRepository : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync(int pageNumber, int pageSize, string search);
    }
}
