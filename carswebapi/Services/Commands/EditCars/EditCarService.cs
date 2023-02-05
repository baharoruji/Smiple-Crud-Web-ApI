using carswebapi.Context;

namespace carswebapi.Services.Commands.EditCars
{
    public class EditCarService : IEditCarService
    {
        private readonly IApiDbContext _context;

        public EditCarService(IApiDbContext context)
        {
            _context = context;
        }
        public bool Execute(RequestEditCarDto request)
        {
            var car = _context.Cars.Find(request.CarId);
            if (car == null)
            {
                return false;
            }

            car.Name = request.Name;
            car.Color = request.Color;
            car.YearOfBuild= request.YearOfBuild;
            _context.SaveChanges();

            return true;

        }
    }
}
