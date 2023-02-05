using carswebapi.Context;

namespace carswebapi.Services.Commands.RemoveCars
{
    public class RemoveCarService : IRemoveCarService
    {
        private readonly IApiDbContext _context;

        public RemoveCarService(IApiDbContext context)
        {
            _context = context;
        }

        public bool Execute(long CarId)
        {

            var car = _context.Cars.Find(CarId);
            if (car == null)
            {
                return false;
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();

            return true;
        }
    }
}
