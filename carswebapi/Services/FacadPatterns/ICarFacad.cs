using carswebapi.Services.Commands.AddCars;
using carswebapi.Services.Queries.GetBrands;
using carswebapi.Services.Queries.GetCars;

namespace carswebapi.Services.FacadPatterns
{
    public class ICarFacad
    {
        AddCarService AddCarService { get; }
        IGetCarService GetCarService { get; }
        IGetBrandService GetBrandsService { get; }
    }
}
