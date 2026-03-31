using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            if (product != null)
            {
                products.Add(product);
            }
            ViewBag.Products = products;
            return View("Index");
        }

    }
}
