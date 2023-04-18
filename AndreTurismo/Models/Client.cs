using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        public Adress Adress { get; set; }

        public DateTime Dt_Register { get; set; }

        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nTelefone: {Telephone}" +
                $"\nEndereço: {Adress}\nData de Registro: {Dt_Register}";
        }
    }
}
