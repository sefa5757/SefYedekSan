using Microsoft.EntityFrameworkCore;

namespace SefaYedekSan.WebApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Models.CarType> CarTypes { get; set; }
        public DbSet<Models.Brand> Brands { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.History> Histories { get; set; }
        public DbSet<Models.Model> Models { get; set; }
        public DbSet<Models.Product> Products { get; set; }
    }
}
