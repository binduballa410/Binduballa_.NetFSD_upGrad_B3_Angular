using WebApplication7.Repository;
using WebApplication7.Models;
using WebApplication7.Services;

namespace WebApplication7.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db) => _db = db;
        public IEnumerable<Movie> GetAll() => _db.Movies.ToList();
        public Movie GetById(int id) => _db.Movies.Find(id);
        public void Add(Movie movie) {  
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
        public void Update(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var m = _db.Movies.Find(id);
            if (m != null)
            {
                _db.Movies.Remove(m);
                _db.SaveChanges();
            }
        }
       

    }
}
