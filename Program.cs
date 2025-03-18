using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class Program
    {
        static void Main(String[] args)
        {
            IAddressBookService addressBook = new AddressBookService();
            ContactPerson contact = new ContactPerson(1, "Ankit", "ankitbhrigu22@mail.com", "9621896867");
            addressBook.Add(contact);
            addressBook.Remove(1);
            addressBook.Display();
            addressBook.Display();
        }
    }
    public class ContactPerson
    {
        private int id;
        private string name;
        private string email;
        private string phone;

        public ContactPerson(int id, string name, string email, string phone)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    public interface IAddressBookService
    {
        void Add(ContactPerson contact);
        void Remove(int id);
        void Update(int id);
        void Display();
    }

    public class AddressBookService : IAddressBookService
    {
        public List<ContactPerson> contacts = new List<ContactPerson>();

        public void Add(ContactPerson contact) => contacts.Add(contact);

        public void Remove(int id)
        {
            foreach (var item in contacts)
            {
                if (item.Id.Equals(id))
                {
                    contacts.Remove(item);
                    break;
                }
            }
            Console.WriteLine($"there is no contact by the id {id}");
        }

        public void Update(int id)
        {
            foreach (var contact in contacts)
            {
                if (contact.Id.Equals(id))
                {
                    Console.WriteLine("Enter new name: ");
                    contact.Name = Console.ReadLine();

                    Console.WriteLine("Enter new email: ");
                    contact.Email = Console.ReadLine();

                    Console.WriteLine("Enter new phone: ");
                    contact.Phone = Console.ReadLine();
                }
            }

        }
        public void Display()
        {
            foreach (var c in contacts)
            {
                Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Email: {c.Email}, Phone: {c.Phone}");
            }
        }     
    }

}
