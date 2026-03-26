using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProController : Controller
    {
        List<Products> products = new List<Products>()
            {
                new Products { ProductId = 1, ProName = "Laptop", Price = 20000 },
                new Products { ProductId = 2, ProName = "Mobile", Price = 15000 },
                new Products { ProductId = 3, ProName = "Headphones", Price = 2000 }
            };

        public IActionResult Index()
        {
            
                return View(products);
            
        }
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
           

            if (product == null)
            { 
                return NotFound();
            }
            return View(product);


        }
    }
}

