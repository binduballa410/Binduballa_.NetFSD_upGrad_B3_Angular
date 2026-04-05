namespace WebApplication6.Models.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById (int id);
        void AddContact(ContactInfo contact);

    }
}
