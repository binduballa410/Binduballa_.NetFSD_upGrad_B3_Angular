using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            ViewBag.Name = studentName;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return RedirectToAction("Display", new
            {
                name = studentName,
                age = age,
                course = course
            });
        }

        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
