using AddressBook.BusinessLayer.Interface;
using RepositoryLayer.Entity;
using AddressBook.RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ModelLayer.Model;

namespace AddressBook.BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly IAddressBookRL _addressBookRL;
        private readonly IMapper _mapper;

        public AddressBookBL(IAddressBookRL addressBookRL, IMapper mapper)
        {
            _addressBookRL = addressBookRL;
            _mapper = mapper;
        }

        public IEnumerable<ResponseAddressBook> GetAllContacts()
        {
            var contacts = _addressBookRL.GetAllContacts();

            return _mapper.Map<IEnumerable<ResponseAddressBook>>(contacts);
        }

        public ResponseAddressBook GetContactById(int id)
        {
            var contact = _addressBookRL.GetContactById(id);
            return contact == null ? null : _mapper.Map<ResponseAddressBook>(contact);
        }

        public ResponseAddressBook AddContact(RequestAddressBook contact)
        {
            //var entity = _mapper.Map<AddressBookEntry>(contact);
            // Map RequestAddressBook to AddressBookEntry
            var entity = _mapper.Map<AddressBookEntry>(contact);
            var newContact = _addressBookRL.AddContact(entity);
            return _mapper.Map<ResponseAddressBook>(newContact);
        }

        public ResponseAddressBook UpdateContact(int id, RequestAddressBook contact)
        {
            var entity = _mapper.Map<AddressBookEntry>(contact);
            var updatedContact = _addressBookRL.UpdateContact(id, entity);

            return updatedContact == null ? null : _mapper.Map<ResponseAddressBook>(updatedContact);
        }

        public bool DeleteContact(int id)
        {
            return _addressBookRL.DeleteContact(id);
        }

    }
}
