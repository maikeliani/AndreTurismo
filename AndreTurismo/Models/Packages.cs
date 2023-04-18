﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public  class Packages
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }

        public Ticket Ticket { get; set; }

        public DateTime Dt_Register { get; set; }

        public decimal Price { get; set; }

        public Client Client { get; set; }
    }
}
