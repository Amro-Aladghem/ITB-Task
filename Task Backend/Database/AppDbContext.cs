using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("");
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(p => p.DateOfJoined).HasDefaultValueSql("CAST(GETDATE() AS DATE)");

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Ali", LastName = "Khalid", JobTitle = "Backend Developer", Level = "Junior"},
                new Employee { Id = 2, FirstName = "Lina", LastName = "Hassan", JobTitle = "Frontend Developer", Level = "Mid" },
                new Employee { Id = 3, FirstName = "Salim", LastName = "Yousef", JobTitle = "Full Stack Developer", Level = "Senior"},
                new Employee { Id = 4, FirstName = "Mona", LastName = "Ahmad", JobTitle = "DevOps Engineer", Level = "Mid"},
                new Employee { Id = 5, FirstName = "Omar", LastName = "Sami", JobTitle = "QA Engineer", Level = "Junior" },
                new Employee { Id = 6, FirstName = "Sara", LastName = "Nabil", JobTitle = "Project Manager", Level = "Senior" }
            );
        }
    }
}
