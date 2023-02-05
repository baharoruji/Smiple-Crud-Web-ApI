namespace carswebapi.Services.Commands.AddCars
{
    public interface IAddCarService
    {
        ResultAddCarDto Execute(RequestAddCarDto request);
    }
}
