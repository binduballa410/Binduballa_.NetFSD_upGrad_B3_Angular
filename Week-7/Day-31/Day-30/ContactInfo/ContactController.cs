using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {

        public static List<ContactInfo> contacts = new List<ContactInfo>();
        public ActionResult ShowContacts()
        {
            return View(contacts);
        }
        public ActionResult GetContactId(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}

