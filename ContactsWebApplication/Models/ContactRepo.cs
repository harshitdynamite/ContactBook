using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApplication.Models
{
    public class ContactRepo : IContactRepo
    {
        private static ConcurrentDictionary<string, Contact> _contactDictionary =
           new ConcurrentDictionary<string, Contact>();
        public ContactRepo()
        {
            Add(new Contact()
            {
                FirstName = "James",
                LastName = "",
                DOB = DateTime.Now,
                Email = new List<string>() { "abc@gmail.com", "def@gmail.com" },
                PhoneNos = new List<string> { "123456", "456789" }
            });
        }
        public void Add(Contact contact)
        {
            contact.Key = Guid.NewGuid().ToString();
            _contactDictionary[contact.Key] = contact;
        }

        public Contact Find(string key)
        {
            Contact contact;
            _contactDictionary.TryGetValue(key, out contact);
            return contact;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactDictionary.Values;
        }

        public Contact Remove(string key)
        {
            Contact contact;
            _contactDictionary.TryGetValue(key, out contact);
            _contactDictionary.TryRemove(key, out contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contactDictionary[contact.Key] = contact;
        }
    }
}
