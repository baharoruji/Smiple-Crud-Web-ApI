using carswebapi.Common.Brands;
using carswebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace carswebapi.Context
{
    public interface IApiDbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<BrandsOfCars> BrandsOfCars { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());


        

    }


    }
