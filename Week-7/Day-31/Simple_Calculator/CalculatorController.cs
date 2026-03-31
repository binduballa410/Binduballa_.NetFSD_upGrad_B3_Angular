using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult Add()
        {
            var num1 = Request.Form["num1"];
            var num2 = Request.Form["num2"];
            int n1 = int.Parse(num1);
            int n2 = int.Parse(num2);

            int sum = n1 + n2;

            ViewData["Result"] = sum;
            return View("Index");
        }
    }
}
