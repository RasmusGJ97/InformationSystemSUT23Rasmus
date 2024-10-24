using InformationSystemSUT23Rasmus.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemSUT23Rasmus.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Employees
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                Name = "Rasmus",
                Email = "rasmus@email.com",
                Password = "Rasmus@1",
                Role = "Admin"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 2,
                Name = "Göran",
                Email = "göran@email.com",
                Password = "Göran@2",
                Role = "Employee"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 3,
                Name = "Sven",
                Email = "sven@email.com",
                Password = "Sven@3",
                Role = "Employee"
            });

            // Drivers
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 1,
                DriverName = "Peter",
                CarReg = "ABC123",
                NoteDate = DateTime.Now,
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Sven",
                BeloppUt = 200.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 200.00M,
                TotalBeloppIn = 1000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 2,
                DriverName = "Anja",
                CarReg = "DEF456",
                NoteDate = DateTime.Now.AddDays(-4),
                NoteDescription = "Added Fuel",
                ResponsibleEmployee = "Göran",
                BeloppUt = 500.00M,
                BeloppIn = 0.00M,
                TotalBeloppUt = 500.00M,
                TotalBeloppIn = 0.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 3,
                DriverName = "Chris",
                CarReg = "GHI789",
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Sven",
                BeloppUt = 100.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 100.00M,
                TotalBeloppIn = 1000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 4,
                DriverName = "Lena",
                CarReg = "CBA321",
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Göran",
                BeloppUt = 200.00M,
                BeloppIn = 2000.00M,
                TotalBeloppUt = 200.00M,
                TotalBeloppIn = 2000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 5,
                DriverName = "Fredrik",
                CarReg = "FED654",
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Sven",
                BeloppUt = 500.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 500.00M,
                TotalBeloppIn = 1000.00M
            });

            // Event
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 1,
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1000.00M,
                DriverID = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 2,
                NoteDate = DateTime.Now,
                NoteDescription = "Fueled Car",
                BeloppUt = 1000.00M,
                BeloppIn = 0.00M,
                DriverID = 2
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 3,
                NoteDate = DateTime.Now.AddDays(-4),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 500.00M,
                DriverID = 3
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 4,
                NoteDate = DateTime.Now.AddDays(-1),
                NoteDescription = "Car Service",
                BeloppUt = 2000.00M,
                BeloppIn = 0.00M,
                DriverID = 4
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 5,
                NoteDate = DateTime.Now.AddDays(-1),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1800.00M,
                DriverID = 5
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 6,
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 700.00M,
                DriverID = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 7,
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1200.00M,
                DriverID = 2
            });
        }
    }

}
