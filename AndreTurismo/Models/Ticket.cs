using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Adress SourceAdress { get; set; }

        public Adress DestinationAdress { get; set; }

        public Client  Client { get; set; }

        public DateTime Dt_Register { get; set; }

        public double Price { get; set; } 
    }
}
