using WebApplication7.Models;

namespace WebApplication7.Services
{
    public interface IMovieServices
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        void CreateMovie (Movie movie);
        void UpdateMovie (Movie movie);
        void RemoveMovie (int id);
    }
}
