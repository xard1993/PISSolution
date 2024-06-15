using PISSolution.Models;

namespace PISSolution.Repositories.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync(int pageNumber, int pageSize, string search);
        Task<Property> GetPropertyByIdAsync(Guid id);
    }
}
