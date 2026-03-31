using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
        [Route("feedback")]
        public class FeedbackController : Controller
        {
            [HttpGet("")]
            public IActionResult Index()
            {
                return View();
            }
            [HttpPost("submit")]
            public IActionResult Submit()
            {
                string name = Request.Form["name"];
                string comments = Request.Form["comments"];
                int rating = int.Parse(Request.Form["rating"]);
                string message = "";

                if (rating >= 4)
                {
                    message = "Thank you for your feedback!";
                }
                else
                {
                    message = "We will improve based on your feedback.";
                }

                ViewData["Message"] = message;
                ViewData["Name"] = name;

                return View("Index");
            }
        }
    }

        
