namespace carswebapi.Services.Commands.AddCars
{
    public class RequestAddCarDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string YearOfBuild { get; set; }
        public List<BrandsOfCarsInAddCarsDto> brands { get; set; }
    }
}
