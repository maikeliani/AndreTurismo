using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class TicketController
    {
        public bool Insert(Ticket ticket)
        {
            return new TicketService().Insert(ticket);
        }


        public bool Delete(int id)
        {
            return new TicketService().Delete(id);
        }


        public List<Ticket> FindAll()
        { 
            return new TicketService().FindAll();
        }

        public bool Update(Adress sourceAdress, Adress destinationAdress, double price, int id)
        {
            return new TicketService().Update(sourceAdress, destinationAdress, price, id);  
        }
    }
}
