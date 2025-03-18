using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        IEnumerable<ResponseAddressBook> GetAllContacts();
        ResponseAddressBook GetContactById(int id);
        ResponseAddressBook AddContact(AddressBookEntry contact);
        ResponseAddressBook UpdateContact(int id, AddressBookEntry contact);
        bool DeleteContact(int id);
    }
}
