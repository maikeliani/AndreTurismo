using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;


namespace AndreTurismo.Controllers
{
    public class AddressController
    {
        public bool Insert(Adress address)
        {
            return new AddressService().Insert(address);
        }

        public bool Delete(int Id)
        {
            return new AddressService().Delete(Id);
        }



        public List<Adress> FindAll()
        {
            return new AddressService().FindAll();
        }
    }
}

