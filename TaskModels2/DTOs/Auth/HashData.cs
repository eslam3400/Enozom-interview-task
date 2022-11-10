using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModels.DTOs.Auth
{
    public class HashData
    {
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
