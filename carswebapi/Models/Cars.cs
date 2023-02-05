namespace carswebapi.Models
{
    public class Cars
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string YearOfBuild { get; set; } 
        public ICollection<BrandsOfCars> BrandsOfCars { get; set; }
    }
}
