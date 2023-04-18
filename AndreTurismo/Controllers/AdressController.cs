using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class AdressController
    {
        public bool Insert(Adress address)
        {
            return new AddressService().Insert(address);
        }



        public List<Adress> FindAll()
        {
            return new AddressService().FindAll();
        }
    }
}

