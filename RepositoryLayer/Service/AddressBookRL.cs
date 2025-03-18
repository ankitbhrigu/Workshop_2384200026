using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using AddressBook.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AppDbContext _dbContext;

        public AddressBookRL(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ResponseAddressBook> GetAllContacts()
        {
            return _dbContext.AddressBookEntries
                .Select(entry => new ResponseAddressBook
                {
                    Id = entry.Id,
                    Name = entry.Name,
                    Email = entry.Email,
                    PhoneNumber = entry.PhoneNumber,
                    Address = entry.Address
                }).ToList();
        }

        public ResponseAddressBook GetContactById(int id)
        {
            var entry = _dbContext.AddressBookEntries.Find(id);
            if (entry == null) return null;

            return new ResponseAddressBook
            {
                Id = entry.Id,
                Name = entry.Name,
                Email = entry.Email,
                PhoneNumber = entry.PhoneNumber,
                Address = entry.Address
            };
        }

        public ResponseAddressBook AddContact(AddressBookEntry contact)
        {
            _dbContext.AddressBookEntries.Add(contact);
            _dbContext.SaveChanges();

            return new ResponseAddressBook
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Address = contact.Address
            };

        }

        public ResponseAddressBook UpdateContact(int id, AddressBookEntry contact)
        {
            var existingContact = _dbContext.AddressBookEntries.FirstOrDefault(c => c.Id == id);

            if (existingContact == null)
            {
                return null;
            }

            // Update fields
            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Email = contact.Email;
            existingContact.Address = contact.Address;

            _dbContext.AddressBookEntries.Update(existingContact);
            _dbContext.SaveChanges();

            return new ResponseAddressBook
            {
                Id = existingContact.Id,
                Name = existingContact.Name,
                PhoneNumber = existingContact.PhoneNumber,
                Email = existingContact.Email,
                Address = existingContact.Address
            };
        }

        public bool DeleteContact(int id)
        {
            var entry = _dbContext.AddressBookEntries.Find(id);
            if (entry == null) return false;

            _dbContext.AddressBookEntries.Remove(entry);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
