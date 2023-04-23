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

        public bool Delete(Client cli) 
        {
            return new ClientService().Delete(cli);
        }

        public bool Update(Client client, string name,string Telephone, Adress adress)
        {
            return new ClientService().Update(client,name, Telephone, adress); 
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }
    }
}
