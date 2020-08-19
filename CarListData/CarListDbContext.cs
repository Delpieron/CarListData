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

        public DbSet<CarList> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarList>().HasKey(x => x.CarId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
