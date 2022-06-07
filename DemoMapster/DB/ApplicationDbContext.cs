using DemoMapster.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoMapster.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
