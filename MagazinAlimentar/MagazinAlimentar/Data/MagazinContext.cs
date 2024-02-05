using MagazinAlimentar.Models;
using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Models.One_to_Many;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Data
{
    public class MagazinContext : DbContext
    {
        // One to One
        public DbSet<User> Users { get; set; }
        public DbSet<UserDates> UserDates { get; set; }

        // One to Many
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }

        // Many to Many
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationEmployeeRelation> LocationEmployeeRelations { get; set; }


        public MagazinContext(DbContextOptions<MagazinContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to One
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDates)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDates>(ud => ud.UserId);

            // One to Many
            modelBuilder.Entity<Department>()
                        .HasMany(dep => dep.Products)
                        .WithOne(prod => prod.Department);

            // Many to Many
            modelBuilder.Entity<LocationEmployeeRelation>().HasKey(ler => new { ler.EmployeeId, ler.LocationId });

            modelBuilder.Entity<LocationEmployeeRelation>()
                .HasOne(ler => ler.Location)
                .WithMany(l => l.LocationEmployeeRelations)
                .HasForeignKey(ler => ler.LocationId);

            modelBuilder.Entity<LocationEmployeeRelation>()
                .HasOne(ler => ler.Employee)
                .WithMany(e => e.LocationEmployeeRelations)
                .HasForeignKey(ler => ler.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
