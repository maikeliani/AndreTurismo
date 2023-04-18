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

        public string SourceAdress { get; set; }

        public string  DestinationAdress { get; set; }

        public Client  Client { get; set; }

        public DateTime DateAndTime { get; set; }

        public decimal Price { get; set; } 
    }
}
