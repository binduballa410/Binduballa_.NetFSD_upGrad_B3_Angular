using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieServices _service;
        public MoviesController(IMovieServices service) => _service = service;
        

        public IActionResult Index() => View(_service.GetMovies());

        public IActionResult Create() => View();
        
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _service.CreateMovie(movie);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) => View(_service.GetMovie(id));
       
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
           _service.UpdateMovie(movie);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) => View(_service.GetMovie(id));

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.RemoveMovie(id);
            return RedirectToAction(nameof(Index));
        }
       
       

    }
}
