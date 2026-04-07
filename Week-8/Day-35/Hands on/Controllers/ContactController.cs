using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Models.Services;
using WebApplication9.Repository;


namespace WebApplication9.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("all")]
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        [HttpGet("add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();

            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        [HttpPost("edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            return View(contact);
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }

}
