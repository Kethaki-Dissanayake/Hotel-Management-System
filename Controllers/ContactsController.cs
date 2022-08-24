using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts =  await _contactRepository.GetAllContactsAsync();
            return Ok(contacts);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if(contact == null)
            {
                return NotFound();
            }


            return Ok(contact);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewContact([FromBody]ContactModel contactModel)
        {
            var id = await _contactRepository.AddContactAsync(contactModel);
            return CreatedAtAction(nameof(GetContactById), new {id = id, controller ="contacts"}, id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactModel contactModel, [FromRoute] int id)
        {
            await _contactRepository.UpdateContactAsync(id, contactModel);
            return Ok();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            await _contactRepository.DeleteContactAsync(id);
            return Ok();

        }
    }
}
