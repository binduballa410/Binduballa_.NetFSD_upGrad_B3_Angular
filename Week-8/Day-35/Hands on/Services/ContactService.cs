using WebApplication9.Models;
using WebApplication9.Models.Services;

namespace WebApplication9.Models.Services
{
    public class ContactService : IContactService
    {
        private static List<ContactInfo> _contacts = new List<ContactInfo>();
        private static int _nextContactId = 1; 
        public ContactService()
        {
            if (_contacts.Count == 0)
            {
                AddContact(new ContactInfo { FirstName = "John", LastName = "Deo", CompanyName = "ABC corp", EmailId = "John@gmail.com", MobileNo = 1234567890, Designation = "Software" });
                AddContact(new ContactInfo { FirstName = "Jane", LastName = "Smith", CompanyName = "ABC corp", EmailId = "Jane@gmail.com", MobileNo = 9087654321, Designation = "Developer" });
            }
        }
        public void AddContact(ContactInfo contact)
        {
            if (contact != null)
            {
                contact.ContactId = _nextContactId++;
                _contacts.Add(contact);
            }
        }
        public List<ContactInfo> GetAllContacts()
        {
            return _contacts;
        }
        public ContactInfo GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}
