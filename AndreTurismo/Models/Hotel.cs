using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Adress Adress { get; set; }

        public DateTime Dt_Register { get; set; }

        public decimal Price { get; set; }
    }
}
