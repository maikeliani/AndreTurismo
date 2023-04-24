using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public  class Package
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }

        public Ticket Ticket { get; set; }

        public DateTime Dt_Register { get; set; }

        public double Price { get; set; }

        public Client Client { get; set; }

        public override string ToString()
        {
            return $"Hotel: {Hotel.Id}\nTicket: {Ticket.Id}\n" +
                $"Preço: {Price}\nCLiente: {Client.Id}\n";
        }
    }
}
