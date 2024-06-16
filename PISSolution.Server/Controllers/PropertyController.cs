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
        public async Task<IActionResult> GetProperties([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
        {
            var query = await _propertyRepository.GetAllPropertiesAsync(pageIndex, pageSize, search);
            var totalCount = query.Count();
            var items = query.ToArray<Property>();

            var response = new
            {
                items,
                totalCount
            };

            return Ok(response);
        }
        // GET: api/Property/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(Guid id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        // POST: api/Property/
        [HttpPost]
        public async Task<ActionResult<Property>> PostSingleProperty(Property property)
        {
            property.ID = Guid.NewGuid();
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


        // PUT: api/Property
        [HttpPut]
        public async Task<IActionResult> PutProperty([FromBody] Property property)
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