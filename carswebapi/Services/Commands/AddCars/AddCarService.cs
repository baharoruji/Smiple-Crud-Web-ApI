using carswebapi.Context;
using carswebapi.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Text.RegularExpressions;

namespace carswebapi.Services.Commands.AddCars
{
    public class AddCarService : IAddCarService
    {
        private readonly IApiDbContext _context;

        public AddCarService(IApiDbContext context)
        {
            _context = context;
        }
        public ResultAddCarDto Execute(RequestAddCarDto request)
        {
            try
            {
                Cars car = new Cars()
                {
                    Name = request.Name,
                    Color= request.Color,
                    YearOfBuild = request.YearOfBuild,
                };

                List<BrandsOfCars> brandsofcars = new List<BrandsOfCars>();

                foreach (var item in request.brands)
                {
                    var brands = _context.Brands.Find(item.Id);
                    brandsofcars.Add(new BrandsOfCars
                    {
                        Brands = brands,
                        BrandId = brands.Id,
                        Car = car,
                        CarId = car.Id,
                    });
                }
                car.BrandsOfCars = brandsofcars;

                _context.Cars.Add(car);
                _context.SaveChanges();

                return new ResultAddCarDto() { CarId = car.Id } ;
            }
            catch (Exception)
            {
                return new ResultAddCarDto() { CarId= 0 } ;
                
            }
        }
    }
}
