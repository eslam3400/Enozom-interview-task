using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModels.DTO.HotelPrices;

namespace TaskModels.DTO.Hotel
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HotelPricesDTO> Prices { get; set; }
    }
}
