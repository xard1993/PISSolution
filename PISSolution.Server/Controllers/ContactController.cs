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

    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contractRepository)
        {
            _contactRepository = contractRepository;
        }

        // GET: api/Contact
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts(
         int pageNumber = 1,
         int pageSize = 10,
        string search = null)
        {
            Func<IQueryable<Contact>, IQueryable<Contact>> filter = null;

            if (!string.IsNullOrEmpty(search))
            {
                filter = query => query.Where(c => c.Email.Contains(search) || c.FirstName.Contains(search) || c.LastName.Contains(search) || c.PhoneNumber.Contains(search));
            }

            var contacts = await _contactRepository.GetAllAsync(pageNumber, pageSize, filter);
            return Ok(contacts);
        }

        // GET: api/Contact/5
        [HttpGet("GetContact/{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var Contact = await _contactRepository.GetByIdAsync(id);

            if (Contact == null)
            {
                return NotFound();
            }

            return Ok(Contact);
        }

        // POST: api/Contact/single
        [HttpPost("single")]
        public async Task<ActionResult<Contact>> PostSingleContact(Contact Contact)
        {
            await _contactRepository.AddAsync(Contact);
            return CreatedAtAction(nameof(GetContact), new { id = Contact.ID }, Contact);
        }

        // POST: api/Contact/multiple
        [HttpPost("multiple")]
        public async Task<ActionResult<Contact>> PostMultipleContacts(IEnumerable<Contact> contacts)
        {
            await _contactRepository.AddRangeAsync(contacts);
            return Ok();
        }


        // PUT: api/Contact/5
        [HttpPut]
        public async Task<IActionResult> PutContact( [FromBody] Contact Contact)
        {
            

            await _contactRepository.UpdateAsync(Contact);
            return NoContent();
        }

        // PUT: api/Contact/multiple
        [HttpPut("multiple")]
        public async Task<IActionResult> PutMultipleContacts([FromBody] IEnumerable<Contact> contacts)
        {
          
            await _contactRepository.UpdateRangeAsync(contacts);
            return NoContent();
        }

    }
}