namespace TaskModels
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HotelPrices> Prices { get; set; }
    }
}
