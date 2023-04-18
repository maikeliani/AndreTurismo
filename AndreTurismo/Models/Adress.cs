using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AndreTurismo.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string  Street { get; set; }

        public int Number { get; set; }

        public string NeighborHood { get; set; }

        public string ZipCode { get; set; }

        public string Complement { get; set; }

        public City City { get; set; }  

        public DateTime Dt_Register { get; set; }


       
    }

   

}
