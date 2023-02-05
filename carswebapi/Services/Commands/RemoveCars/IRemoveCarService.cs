namespace carswebapi.Services.Commands.RemoveCars
{
    public interface IRemoveCarService
    {
        bool Execute(long CarId);
    }
}
