using carswebapi.Context;
using carswebapi.Models;
using carswebapi.Services.Commands.AddCars;
using carswebapi.Services.Commands.EditCars;
using carswebapi.Services.Commands.RemoveCars;
using carswebapi.Services.FacadPatterns;
using carswebapi.Services.Queries.GetBrands;
using carswebapi.Services.Queries.GetCars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace carswebapi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class CarsController : Controller
    {

        private readonly IGetCarService _getcars;
        private readonly IGetBrandService _getbrands;
        private readonly IAddCarService _addcars;
        private readonly IRemoveCarService _removecar;
        private readonly IApiDbContext _dbcontext;
        private readonly IEditCarService _editcar;

        public CarsController(
            IApiDbContext dbcontext,
            IGetCarService getcars,
            IGetBrandService getbrands,
            IAddCarService addcars,
            IRemoveCarService removecar,
            IEditCarService editcar
            )
        {
            _dbcontext = dbcontext;
            _getcars = getcars;
            _getbrands = getbrands;
            _addcars = addcars;
            _removecar = removecar;
            _editcar = editcar;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars(int page = 1)
        {
            return Ok(_getcars.Execute(new RequestGetCarDto
            {
                Page = page,
            }));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCarById([FromRoute] long id, int page = 1)
        {

            var car = await _dbcontext.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                GetCarDto cardto = new GetCarDto
                {
                    Id = car.Id,
                    Name = car.Name,
                    Color = car.Color,
                    YearOfBuild = car.YearOfBuild,
                };
                return Ok(cardto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = new SelectList(_getbrands.Execute(), "Id", "Name");
            return Ok(brands);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddNewCar(string Name, string Color, string YearOfBuild, long BrandId)
        {
            var result = _addcars.Execute(new RequestAddCarDto
        {
            Name = Name,
            Color = Color,
            YearOfBuild = YearOfBuild,
            brands = new List<BrandsOfCarsInAddCarsDto>()
                {
                    new BrandsOfCarsInAddCarsDto
                    {
                        Id = BrandId
                    }
                },
            });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(long CarId)
        {
            return Ok(_removecar.Execute(CarId));
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(long CarId , string Name , string Color , string YearOfBuild)
        {
            return Ok(_editcar.Execute(new RequestEditCarDto
            {
                Name = Name,
                Color = Color,
                YearOfBuild = YearOfBuild,
                CarId = CarId

            }));

        }
    }
}

