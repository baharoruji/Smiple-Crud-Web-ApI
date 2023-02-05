namespace carswebapi.Services.Queries.GetCars
{
    public class ResultGetCarDto
    {
        public List<GetCarDto> Cars { get; set; }
        public int Rows { get; set; }
    }
}
