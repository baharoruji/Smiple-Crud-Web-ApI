namespace carswebapi.Models
{
    public class BrandsOfCars
    {
        public long Id { get; set; }
        public virtual Cars Car { get; set; }
        public long CarId { get; set; }

        public virtual Brands Brands { get; set; }
        public long BrandId { get; set; }
    }
}
