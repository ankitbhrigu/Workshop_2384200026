using AddressBook.RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        Task<IEnumerable<AddressBookEntry>> GetAllContacts();
        Task<AddressBookEntry> GetContactById(int id);
        Task<AddressBookEntry> AddContact(AddressBookEntry newContact);
        Task<bool> UpdateContact(int id, AddressBookEntry updatedContact);
        Task<bool> DeleteContact(int id);
    }
}
