using AndreTurismo.Controllers;
using AndreTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        

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

        Hotel hotel = new()
        {
            Name="casa da luz vermelha",
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




        if (new ClientController().Insert(client))
            Console.WriteLine("Sucesso! Cliente Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");


        if(new HotelController().Insert(hotel))
            Console.WriteLine("Hotel cadastrado com sucesso!");
        else
            Console.WriteLine("Erro ao cadastrar hotel");

        if (new TicketController().Insert(ticket))
            Console.WriteLine("Sucesso! Ticket Registrado");
        else
            Console.WriteLine("Erro ao inserir Ticket");

        if (new PackageController().Insert(package))
            Console.WriteLine("Sucesso! Cliente Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");




        new ClientController().FindAll().ForEach(Console.WriteLine);
        new HotelController().FindAll().ForEach(Console.WriteLine);
        new TicketController().FindAll().ForEach(Console.WriteLine);
        new PackageController().FindAll().ForEach(Console.WriteLine);
    }
}