using AddressBook.RepositoryLayer.Context;
using AddressBook.RepositoryLayer.Entity;
using AddressBook.RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AppDbContext _context;

        public AddressBookRL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressBookEntry>> GetAllContacts()
        {
            return await _context.AddressBookEntries.ToListAsync();
        }

        public async Task<AddressBookEntry> GetContactById(int id)
        {
            return await _context.AddressBookEntries.FindAsync(id);
        }

        public async Task<AddressBookEntry> AddContact(AddressBookEntry newContact)
        {
            _context.AddressBookEntries.Add(newContact);
            await _context.SaveChangesAsync();
            return newContact;
        }

        public async Task<bool> UpdateContact(int id, AddressBookEntry updatedContact)
        {
            var existingContact = await _context.AddressBookEntries.FindAsync(id);
            if (existingContact == null)
                return false;

            existingContact.Name = updatedContact.Name;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;
            existingContact.Email = updatedContact.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.AddressBookEntries.FindAsync(id);
            if (contact == null)
                return false;

            _context.AddressBookEntries.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
