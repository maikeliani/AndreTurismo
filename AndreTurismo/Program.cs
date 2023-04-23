using System.ComponentModel.Design;
using System.Data;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Security.Cryptography;
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


        City city2 = new()
        {
            Description = "São Carlos",

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

        Adress ad3 = new()
        {
            Street = " rua dos Eletricitários",
            Number = 110,
            NeighborHood = "Vila Regina",
            ZipCode = "14800099",
            Dt_Register = DateTime.Now,
            Complement = "",
            City = city
        };

        Adress ad4 = new()
        {
            Street = " rua dos Eletricitários",
            Number = 110,
            NeighborHood = "Vila Regina",
            ZipCode = "14800099",
            Dt_Register = DateTime.Now,
            Complement = "",
            City = city2
        };

        Adress ad5 = new()
        {
            Street = " de sao carlos",
            Number = 110,
            NeighborHood = "sc",
            ZipCode = "14800099",
            Dt_Register = DateTime.Now,
            Complement = "",
            City = city2
        };


        Client client = new()
        {
            Name = "Jose de Sanca",
            Telephone = "16997225955",
            Adress = ad5,
            Dt_Register = DateTime.Now
        };



        Client client3 = new()
        {
            Name = "Josivaldo de Araraquara",
            Telephone = "1699887766",
            Adress = ad2,
            Dt_Register = DateTime.Now
        };

       

        Hotel hotel = new()
        {
            Name = "hotel de araraquara",
            Adress = ad2,
            Dt_Register = DateTime.Now,
            Price = 150.55
        };

        Hotel hotel2 = new()
        {
            Name = "Hotel London",
            Adress = ad,
            Dt_Register = DateTime.Now,
            Price = 199.55
        };

        Hotel hotel3 = new()
        {
            Name = "Hotel SANCA",
            Adress = ad5,
            Dt_Register = DateTime.Now,
            Price = 199.55
        };

        Ticket ticket = new()
        {
            SourceAdress = ad,
            DestinationAdress = ad5,
            Client = client3,
            Dt_Register = DateTime.Now,
            Price = 59.90
        };

        Package package = new()
        {
            Hotel = hotel2,
            Ticket = ticket,
            Dt_Register = DateTime.Now,
            Price = 119.90,
            Client = client
        };




        //update Package 

        if(new PackageController().Update(hotel, ticket, 120, client3,1))
            Console.WriteLine("Package atualizado");
        else
        {
            Console.WriteLine("erro ao atualizar package");
        }



        //update Ticket
        /*
        if(new TicketController().Update(ad, ad3, 79.80, 2))
            Console.WriteLine("Ticket atualizado com sucesso");
        else
            Console.WriteLine("erro ao atualizar ticket");
        */


        // Update Hotel
        /*
        if(new HotelController().Update("hotel de buracoquara",95.5, 7 ))
             Console.WriteLine("hotel atualizado");
        else
             Console.WriteLine("erro ao atualizar hotel");
        */

        //update City
        /*
        if (new CityController().Update("Guarulhos", DateTime.Parse("2023 - 04 - 21 13:15:43.513"))) 
           
            else
          Console.WriteLine(" erro ao atualizar");
        */


        // Update Adress
        /*
        if(new AddressController().Update("Rua das Amoras", 99,  "cambuy",  "9999-9", "",1040))
            Console.WriteLine(" endereço atualizado");
        else
            Console.WriteLine("erro ao atualizar endereço");
        */


        //UPDATE
        /*
        if (new ClientController().Update(client, "Doidão de Sanca", "999778880",ad)) 
        Console.WriteLine("alterado com sucesso");
        else
        {
            Console.WriteLine("Erro ao alterar o cliente");
        }
        */








        /*
        if (new ClientController().Insert(client))
            Console.WriteLine($"Sucesso! Cliente   Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        /*
        if (new ClientController().Update(client2,  "JURACI", "997113380", ad))
                Console.WriteLine(" CLiente atualizado");
        else
            Console.WriteLine("Erro ao atualizar cliente");
        */



        //INSERTS


        //criando cidade 
        /*
        if (new CityController().Insert(city2))
            Console.WriteLine("Cidade adicionada ao registro");
        else
            Console.WriteLine("Erro ao adicionar a cidade");

        //criando endereço
        if (new AddressController().Insert(ad4))
            Console.WriteLine("Endereço cadastrado!");
        else
            Console.WriteLine("Erro ao cadastrar endereço");

        //criando cliente
        if (new ClientController().Insert(client))
            Console.WriteLine($"Sucesso! Cliente {client.Name} Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        //criando ticket
        /*
        if (new TicketController().Insert(ticket))
            Console.WriteLine("Sucesso! Ticket Registrado");
        else
            Console.WriteLine("Erro ao inserir Ticket");


        // criando hotel
        /*
        if (new HotelController().Insert(hotel3))
            Console.WriteLine("Hotel cadastrado com sucesso!");
        else
            Console.WriteLine("Erro ao cadastrar hotel");
        */
        
        

        /*
        //criando package

        if (new PackageController().Insert(package))
            Console.WriteLine("Sucesso! Package Registrado");
        else
            Console.WriteLine("erro ao deletar package");
        */



        //DELETES

        /*
        if(new PackageController().Delete(package.Id))
            Console.WriteLine("Package deletado");
        else
            Console.WriteLine("Erro ao deletar package");*/

        /*
        if(new TicketController().Delete(3))
            Console.WriteLine("Ticket deletado com sucesso!");
        else
            Console.WriteLine("Erro ao deletar ticket");


        /*
        if( new HotelController().Delete("Hotel SANCA", "São Carlos"))
            Console.WriteLine("Hotel deletado do registro");
        else        
            Console.WriteLine("Erro ao deletar hotel");
        */

        /*      
       if (new CityController().Delete(city))
           Console.WriteLine("Cidade deletada do registro!");
       else
           Console.WriteLine("Erro ao deletar cidade do registro");
       */

        /*
        if (new ClientController().Delete(client2))
            Console.WriteLine($"Sucesso! Cliente  DELETADO");
        else
            Console.WriteLine("Deu ruimm");
        */
        /*
        if (new AddressController().Delete(" rua dos Ipes", 10, "Vila Harmonia"))
            Console.WriteLine($"Sucesso! Endereço  DELETADO");
        else
            Console.WriteLine("erro ao deletar endereço");
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