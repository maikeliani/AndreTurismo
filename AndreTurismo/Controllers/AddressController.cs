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

        public bool Delete(string street, int number, string zipcode)
        {
            return new AddressService().Delete(street, number, zipcode);
        }



        public List<Adress> FindAll()
        {
            return new AddressService().FindAll();
        }

        internal bool Update(string newStreet, int newNumber, string newNeighborHood, string newZipCode, string newComplement, int id)
        {
            return new AddressService().Update(newStreet, newNumber, newNeighborHood, newZipCode, newComplement, id);
        }
    }
}

