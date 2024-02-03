using MagazinAlimentar.Models;
using MagazinAlimentar.Models.One_to_Many;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Data
{
    public class MagazinContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // One to Many
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }

        public MagazinContext(DbContextOptions<MagazinContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Department>()
                        .HasMany(dep => dep.Products)
                        .WithOne(prod => prod.Department);

            base.OnModelCreating(modelBuilder);
        }
    }
}
