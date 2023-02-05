using carswebapi.Context;

namespace carswebapi.Services.Queries.GetBrands
{
    public class GetBrandService : IGetBrandService
    {
        private readonly IApiDbContext _context;

        public GetBrandService(IApiDbContext context)
        {
            _context = context;
        }
        public List<BrandsDto> Execute()
        {
            var brands = _context.Brands.ToList().Select(p => new BrandsDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return brands;
        }
    }
}
