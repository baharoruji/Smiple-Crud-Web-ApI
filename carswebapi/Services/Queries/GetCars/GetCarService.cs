using carswebapi.Common;
using carswebapi.Context;

namespace carswebapi.Services.Queries.GetCars
{
    public class GetCarService : IGetCarService
    {
        private readonly IApiDbContext _context;
        public GetCarService(IApiDbContext context)
        {
            _context = context;
        }

        public ResultGetCarDto Execute(RequestGetCarDto request)
        {
            var cars = _context.Cars.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                cars = cars.Where(p => p.Name.Contains(request.SearchKey) && p.Color.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var carslist = cars.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetCarDto
            {
                Name= p.Name,
                Color= p.Color,
                YearOfBuild= p.YearOfBuild,
                Id  = p.Id,
               
            }).ToList();

            return new ResultGetCarDto
            {
                Rows = rowsCount,
                Cars = carslist,
            };
        }
    }
}
