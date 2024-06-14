using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Interfaces;

namespace PISSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // GET: api/Property
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties(
         int pageNumber = 1,
         int pageSize = 10,
        string search = null)
        {
            Func<IQueryable<Property>, IQueryable<Property>> filter = null;

            if (!string.IsNullOrEmpty(search))
            {
                filter = query => query.Where(c => c.Address.Contains(search) || c.PropertyName.Contains(search));
            }

            var properties = await _propertyRepository.GetAllAsync(pageNumber, pageSize, filter);
            return Ok(properties);
        }

        // GET: api/Property/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(Guid id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // POST: api/Property/single
        [HttpPost("single")]
        public async Task<ActionResult<Property>> PostSingleProperty(Property property)
        {
            await _propertyRepository.AddAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = property.ID }, property);
        }

        // POST: api/Property/multiple
        [HttpPost("multiple")]
        public async Task<ActionResult<Property>> PostMultipleProperties(IEnumerable<Property> properties)
        {
            await _propertyRepository.AddRangeAsync(properties);
            return Ok();
        }


        // PUT: api/Property/5
        [HttpPut]
        public async Task<IActionResult> PutProperty( [FromBody] Property property)
        {
            

            await _propertyRepository.UpdateAsync(property);
            return NoContent();
        }

        // PUT: api/Property/multiple
        [HttpPut("multiple")]
        public async Task<IActionResult> PutMultipleProperties([FromBody] IEnumerable<Property> properties)
        {
          
            await _propertyRepository.UpdateRangeAsync(properties);
            return NoContent();
        }

    }
}