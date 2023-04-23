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

        public double Price { get; set; } 

        public override string ToString()
        {
            return $"\nNome: {Name}\nEndereço: {Adress}" +
                $"\nData de cadastro do hotel:{Dt_Register}\nPreço: {Price}";
        }
    }
}
