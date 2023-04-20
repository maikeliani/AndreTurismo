using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public  class ClientController
    {
        public bool Insert(Client client)
        {
            return new ClientService().Insert(client);
        }

        public bool Delete(int Id) // mudei pra Id no parametro , era client
        {
            return new ClientService().Delete(Id);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }
    }
}
