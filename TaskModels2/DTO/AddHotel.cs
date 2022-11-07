using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModels.DTO
{
    public class AddHotel
    {
        public string Name { get; set; }
        public List<HotelPrices>? Prices { get; set; }
    }
}
