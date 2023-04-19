﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class HotelController
    {
        public bool Insert(Hotel hotel)
        {
            return  new HotelService().Insert(hotel);
        }

        public List<Hotel>FindAll()
        {
             return new HotelService().FindAll();
        }
    }
}
