using WebApplication6.Models.Services;
using WebApplication6.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication6.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("show")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return Content("Contact Not Found");
            }
            return View(contact);
        }
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _contactService.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

    }
}
