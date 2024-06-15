using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PISSolution.Data;
using PISSolution.Models;
using PISSolution.Repositories.Implementations;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts(int pageNumber = 1, int pageSize = 10,string search = null)
        {
            var query = await _contactRepository.GetAllContactsAsync(pageNumber, pageSize, search);



            var totalCount = query.Count();
            var items = query.ToArray<Contact>();

            var response = new
            {
                items,
                totalCount
            };

            return Ok(response);
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var Contact = await _contactRepository.GetByIdAsync(id);

            if (Contact == null)
            {
                return NotFound();
            }

            return Ok(Contact);
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<ActionResult<Contact>> PostSingleContact(Contact contact)
        {
            contact.ID = Guid.NewGuid();
            await _contactRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.ID }, contact);
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