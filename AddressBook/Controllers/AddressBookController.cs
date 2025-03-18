using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AddressBook.BusinessLayer.Interface;
using AddressBook.RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Authorize] // Ensures only authenticated users can access these endpoints
    [ApiController]
    [Route("api/addressbook")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL _addressBookBL;

        public AddressBookController(IAddressBookBL addressBookBL)
        {
            _addressBookBL = addressBookBL;
        }

        // GET: api/addressbook - Fetch all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressBookEntry>>> GetAllContacts()
        {
            var contacts = await _addressBookBL.GetAllContacts();
            return Ok(contacts);
        }

        // GET: api/addressbook/{id} - Get contact by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBookEntry>> GetContactById(int id)
        {
            var contact = await _addressBookBL.GetContactById(id);
            if (contact == null)
                return NotFound(new { message = "Contact not found" });

            return Ok(contact);
        }

        // POST: api/addressbook - Add a new contact
        [HttpPost]
        public async Task<ActionResult<AddressBookEntry>> AddContact(AddressBookEntry newContact)
        {
            var contact = await _addressBookBL.AddContact(newContact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        // PUT: api/addressbook/{id} - Update contact
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, AddressBookEntry updatedContact)
        {
            var result = await _addressBookBL.UpdateContact(id, updatedContact);
            if (!result)
                return NotFound(new { message = "Contact not found" });

            return NoContent();
        }

        // DELETE: api/addressbook/{id} - Delete contact
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _addressBookBL.DeleteContact(id);
            if (!result)
                return NotFound(new { message = "Contact not found" });

            return NoContent();
        }
    }
}
