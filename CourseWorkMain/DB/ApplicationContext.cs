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
            BusinessTrip businessTrip1 = new BusinessTrip
            {
                id = 1,
                Employee = "Владимир Васильевич Марченко",
                Days = 15,
                Wage = 100000,
                City = "Волгоград",
            };

            BusinessTrip businessTrip2 = new BusinessTrip
            {
                id = 2,
                Employee = "Михаил Михайлович Минин",
                Days = 30,
                Wage = 20000,
                City = "Севастополь",
            };

            BusinessTrip businessTrip3 = new BusinessTrip
            {
                id = 3,
                Employee = "Беляев Рудольф Максович",
                Days = 25,
                Wage = 130000,
                City = "Москва",
            };

            BusinessTrip businessTrip4 = new BusinessTrip
            {
                id = 4,
                Employee = "Гусев Святослав Антонович",
                Days = 11,
                Wage = 10000,
                City = "Волгоград",
            };

            BusinessTrip businessTrip5 = new BusinessTrip
            {
                id = 5,
                Employee = "Муравьёв Роман Семенович",
                Days = 17,
                Wage = 100600,
                City = "Крым",
            };

            BusinessTrip businessTrip6 = new BusinessTrip
            {
                id = 6,
                Employee = "Гусев Святослав Антонович",
                Days = 31,
                Wage = 100000,
                City = "Вологда",
            };

            BusinessTrip businessTrip7 = new BusinessTrip
            {
                id = 7,
                Employee = "Андреев Лавр Иосифович",
                Days = 15,
                Wage = 100000,
                City = "Воронеж",
            };

            BusinessTrip businessTrip8 = new BusinessTrip
            {
                id = 8,
                Employee = "Беляев Рудольф Максович",
                Days = 5,
                Wage = 15000,
                City = "Калининград",
            };

            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip1);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip2);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip3);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip4);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip5);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip6);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip7);
            modelBuilder.Entity<BusinessTrip>().HasData(businessTrip8);
        }
    }
}