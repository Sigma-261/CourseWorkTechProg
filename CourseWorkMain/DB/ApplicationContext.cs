using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using CourseWorkMain.Models;

namespace CourseWorkMain.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BusinessTrip> Localities { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение товаров
            BusinessTrip locality1 = new BusinessTrip
            {
                id = 1,
                Name = "Волгоград",
                Type = "City",
                NumberResidants = 100000,
                Budget = 100000,
                Budget1 = 50,
                Mayor = "Владимир Васильевич Марченко"
            };

            modelBuilder.Entity<BusinessTrip>().HasData(locality1);
        }
    }
}