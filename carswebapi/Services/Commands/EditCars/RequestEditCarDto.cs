namespace carswebapi.Services.Commands.EditCars
{
    public class RequestEditCarDto
    {
        public long CarId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string YearOfBuild { get; set; }
    }
}
