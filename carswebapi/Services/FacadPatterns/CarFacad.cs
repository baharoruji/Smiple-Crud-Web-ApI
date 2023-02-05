using carswebapi.Context;
using carswebapi.Services.Commands.AddCars;
using carswebapi.Services.Queries.GetCars;

namespace carswebapi.Services.FacadPatterns
{
    public class CarFacad : ICarFacad
    {
        private readonly IApiDbContext _context;
        public CarFacad(IApiDbContext context)
        {
            _context = context;

        }

        private AddCarService _addCarService;
        public AddCarService AddCarService
        {
            get
            {
                return _addCarService = _addCarService ?? new AddCarService(_context);
            }
        }


        public IGetCarService _getCarService;
        public IGetCarService GetCarService
        {
            get
            {
                return _getCarService = _getCarService ?? new GetCarService(_context);
            }
        }

       
        
    }
}
