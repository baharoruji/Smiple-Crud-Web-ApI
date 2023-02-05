using carswebapi.Common.Brands;
using carswebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;

namespace carswebapi.Context
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<BrandsOfCars> BrandsOfCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Brands>().HasData(new Brands { Id = 1, Name = nameof(BrandNames.Tiba) });
        modelBuilder.Entity<Brands>().HasData(new Brands { Id = 2, Name = nameof(BrandNames.Dena) });
        modelBuilder.Entity<Brands>().HasData(new Brands { Id = 3, Name = nameof(BrandNames.Pride) });
        modelBuilder.Entity<Brands>().HasData(new Brands { Id = 4, Name = nameof(BrandNames.Ferari) });
        modelBuilder.Entity<Brands>().HasData(new Brands { Id = 5, Name = nameof(BrandNames.Hyundai) });

    }
}

}
