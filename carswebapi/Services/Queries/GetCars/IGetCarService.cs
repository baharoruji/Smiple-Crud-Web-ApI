namespace carswebapi.Services.Queries.GetCars
{
    public interface IGetCarService
    {
        ResultGetCarDto Execute(RequestGetCarDto request);
    }
}
