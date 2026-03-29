using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        static List<Product> products = new List<Product>();
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                products.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(x => x.ProductId == p.ProductId);
                product.ProductName = p.ProductName;
                product.Price = p.Price;
                product.Category = p.Category;
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            products.Remove(product);   
            return RedirectToAction("Index");
        }
    }
}
