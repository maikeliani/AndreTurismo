using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class CityController
    {
        public bool Insert(City city)
        {
            return new CityService().Insert(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }
    }
}
