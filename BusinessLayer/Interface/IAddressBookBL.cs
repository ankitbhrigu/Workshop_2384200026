using ModelLayer.Model;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        IEnumerable<ResponseAddressBook> GetAllContacts();
        ResponseAddressBook GetContactById(int id);
        ResponseAddressBook AddContact(RequestAddressBook contact);
        ResponseAddressBook UpdateContact(int id, RequestAddressBook contact);
        bool DeleteContact(int id);

    }
}
