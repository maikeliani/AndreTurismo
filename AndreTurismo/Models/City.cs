using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class City
    {
        public int Id { get; set; }
        public string  Description { get; set; }
        public DateTime Dt_Register { get; set; }

        public static implicit operator string(City v)
        {
            throw new NotImplementedException();
        }
    }
}
