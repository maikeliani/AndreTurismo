using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class PackageController
    {
        public bool Insert(Package package)
        {
            return new PackageService().Insert(package);
        }

        public bool Delete(int id)
        {
            return new PackageService().Delete(id);
        }


        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public bool Update(Hotel hotel, Ticket ticket, double price, Client client, int id)
        {
            return new PackageService().Update(hotel, ticket, price, client, id);
        }
    }
}
