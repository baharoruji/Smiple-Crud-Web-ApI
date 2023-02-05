namespace carswebapi.Services.Commands.EditCars
{
    public interface IEditCarService
    {
        bool Execute(RequestEditCarDto request);
    }
}
