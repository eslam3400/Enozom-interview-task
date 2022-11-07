namespace TaskModels
{
    public class HotelPrices
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
