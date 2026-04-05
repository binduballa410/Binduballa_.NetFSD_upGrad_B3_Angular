using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) 
        { 
        } 
        public DbSet<Movie> Movies { get; set; }
    }
}
