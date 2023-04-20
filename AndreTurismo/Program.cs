using System.ComponentModel.Design;
using System.Net.Sockets;
using AndreTurismo.Controllers;
using AndreTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        //PRIMEIRO CRIA CIDADE, DEPOIS ENDEREÇO E DEPOIS CLIENTE

        City city = new()
        {
            Description = "Araraquara",

            Dt_Register = DateTime.Now
        };

        Adress ad = new()
        {
            Street = " rua dos Ipes",
            Number = 10,
            NeighborHood = "Vila Harmonia",
            ZipCode = "14804087",
            Dt_Register = DateTime.Now,
            Complement = "",
            City = city

        };

        Adress ad2 = new()
        {
            Street = " rua dos Miasotis",
            Number = 70,
            NeighborHood = "Vila Harmonia",
            ZipCode = "14800025",
            Dt_Register = DateTime.Now,
            Complement = "",
            City = city
        };


        Client client = new()
        {
            Name = "Jose das Couves",
            Telephone = "16997225955",
            Adress = ad,
            Dt_Register = DateTime.Now
        };


        Client client2 = new()
        {
            Name = "Jose do Rego Sujo",
            Telephone = "169999999",
            Adress = ad2,
            Dt_Register = DateTime.Now

        };

        Client client3 = new()
        {
            Name = "Josivaldo matador de galinha",
            Telephone = "1699887766",
            Adress = ad2,
            Dt_Register = DateTime.Now
        };

        Hotel hotel = new()
        {
            Name = "casa da luz vermelha",
            Adress = ad,
            Dt_Register = DateTime.Now,
            Price = 150.55
        };

        Ticket ticket = new()
        {
            SourceAdress = ad,
            DestinationAdress = ad2,
            Client = client,
            Dt_Register = DateTime.Now,
            Price = 59.90
        };

        Package package = new()
        {
            Hotel = hotel,
            Ticket = ticket,
            Dt_Register = DateTime.Now,
            Price = 359.90,
            Client = client
        };




        //INSERTS

        /*
        //criando cidade 
        
        if (new CityController().Insert(city))
            Console.WriteLine("Cidade adicionada ao registro");
        else
            Console.WriteLine("Erro ao adicionar a cidade");
        
        //criando endereço
        if (new AddressController().Insert(ad2))
            Console.WriteLine("Endereço cadastrado!");
        else
            Console.WriteLine("Erro ao cadastrar endereço");
        
        //criando cliente
        if (new ClientController().Insert(client))
            Console.WriteLine($"Sucesso! Cliente {client.Name} Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");
        

        //criando ticket
        
        if (new TicketController().Insert(ticket))
            Console.WriteLine("Sucesso! Ticket Registrado");
        else
            Console.WriteLine("Erro ao inserir Ticket");
        

        // criando hotel
        
        if (new HotelController().Insert(hotel))
            Console.WriteLine("Hotel cadastrado com sucesso!");
        else
            Console.WriteLine("Erro ao cadastrar hotel");
        

        //criando ticket
        
        if (new TicketController().Insert(ticket))
            Console.WriteLine("Sucesso! Ticket Registrado");
        else
            Console.WriteLine("Erro ao inserir Ticket");
        

        //criando package
        
        if (new PackageController().Insert(package))
            Console.WriteLine("Sucesso! Cliente Registrado");
        else
            Console.WriteLine("erro ao deletar package");
        */



        //DELETES

        /*
        if(new PackageController().Delete(package.Id))
            Console.WriteLine("Package deletado");
        else
            Console.WriteLine("Erro ao deletar package");

        
        if(new TicketController().Delete(ticket.Id))
            Console.WriteLine("Ticket deletado com sucesso!");
        else
            Console.WriteLine("Erro ao deletar ticket");
        

        
        if( new HotelController().Delete(hotel.Id))
            Console.WriteLine("Hotel deletado do registro");
        else        
            Console.WriteLine("Erro ao deletar hotel");
        
        
                
        if (new CityController().Delete(city.Id))
            Console.WriteLine("Cidade deletada do registro!");
        else
            Console.WriteLine("Erro ao deletar cidade do registro");
        
        
        if (new ClientController().Delete(client.Id))
            Console.WriteLine($"Sucesso! Cliente {client.Name} DELETADO");
        else
            Console.WriteLine("Deu ruimm");
        
        
        if (new AddressController().Delete(client.Adress.Id))
            Console.WriteLine($"Sucesso! Endereço {client.Adress.Id} DELETADO");
        else
          */



        //FindAll()
        /*
         new ClientController().FindAll().ForEach(Console.WriteLine);
         new HotelController().FindAll().ForEach(Console.WriteLine);
         new TicketController().FindAll().ForEach(Console.WriteLine);
         new PackageController().FindAll().ForEach(Console.WriteLine);
        */
    }
}