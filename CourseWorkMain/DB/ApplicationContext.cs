using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using CourseWorkMain.Models;

namespace CourseWorkMain.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BusinessTrip> BusinessTrips { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение товаров
            BusinessTrip businessTrip = new BusinessTrip
            {
                id = 1,
                Employee = "Владимир Васильевич Марченко",
                Days = 15,
                Wage = 100000,
                City = "Волгоград",
            };

            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip);
        }
    }
}