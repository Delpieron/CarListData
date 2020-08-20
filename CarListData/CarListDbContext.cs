using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarListData
{
    public class CarListDbContext : DbContext
    {
        public CarListDbContext(DbContextOptions<CarListDbContext>options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CarList> CarList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarList>().HasKey(x => x.CarId);
            base.OnModelCreating(modelBuilder);
        }
       /*private CarList[] GetCars()
        {
            return new CarList[]
            {
            new CarList { CarId = 1, RegistrationNumber = "TShirt", Vin = "Blue Color", Model = "ford", Brand ="mustang"},
            new CarList { CarId = 2, RegistrationNumber = "Shirt", Vin = "Formal Shirt", Model = "mazda", Brand ="6"},
            new CarList { CarId = 3, RegistrationNumber = "Socks", Vin = "Wollen", Model = "audi", Brand ="a3"},
            new CarList { CarId = 4, RegistrationNumber = "Tshirt", Vin = "Red", Model = "bmw", Brand ="seria5"},
            };
        }*/
    }
}
