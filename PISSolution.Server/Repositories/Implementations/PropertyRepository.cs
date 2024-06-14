using Microsoft.EntityFrameworkCore;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Repositories.Implementations
{

    public class PropertyRepository :  Repository<Property>, IPropertyRepository
    { 

        public PropertyRepository(ApplicationDbContext context) : base(context) { }        
       

    }
}



