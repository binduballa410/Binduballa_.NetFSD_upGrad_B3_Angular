using WebApplication7.Repository;
using WebApplication7.Models;
using WebApplication7.Services;
using Microsoft.Data.SqlClient.DataClassification;

namespace WebApplication7.Services
{
    public class MovieService : IMovieServices
    {
        private readonly IMovieRepository _repo;
        public MovieService(IMovieRepository repo) => _repo = repo;
        public IEnumerable<Movie> GetMovies() => _repo.GetAll();
        public Movie GetMovie(int id) => _repo.GetById(id);
        public void CreateMovie(Movie movie) => _repo.Add(movie);
        public void UpdateMovie(Movie movie) => _repo.Update(movie);
        public void RemoveMovie(int id) => _repo.Delete(id);
        
    }
}
