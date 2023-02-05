namespace carswebapi.Models
{
    public class Brands
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<BrandsOfCars> ModelsOfCars { get; set; }
    }
}
