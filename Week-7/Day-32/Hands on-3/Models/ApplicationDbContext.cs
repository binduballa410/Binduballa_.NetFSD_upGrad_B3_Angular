using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
