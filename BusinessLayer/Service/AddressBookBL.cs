using AddressBook.BusinessLayer.Interface;
using AddressBook.RepositoryLayer.Entity;
using AddressBook.RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly IAddressBookRL _addressBookRL;

        public AddressBookBL(IAddressBookRL addressBookRL)
        {
            _addressBookRL = addressBookRL;
        }

        public async Task<IEnumerable<AddressBookEntry>> GetAllContacts()
        {
            return await _addressBookRL.GetAllContacts();
        }

        public async Task<AddressBookEntry> GetContactById(int id)
        {
            return await _addressBookRL.GetContactById(id);
        }

        public async Task<AddressBookEntry> AddContact(AddressBookEntry newContact)
        {
            return await _addressBookRL.AddContact(newContact);
        }

        public async Task<bool> UpdateContact(int id, AddressBookEntry updatedContact)
        {
            return await _addressBookRL.UpdateContact(id, updatedContact);
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await _addressBookRL.DeleteContact(id);
        }
    }
}
