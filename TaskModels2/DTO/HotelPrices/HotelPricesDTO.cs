namespace TaskModels.DTO.HotelPrices
{
    public class HotelPricesDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int HotelId { get; set; }
    }
}
