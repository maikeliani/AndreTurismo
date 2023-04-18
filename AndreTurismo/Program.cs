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


        Client client = new()
        {
            Name = "Jose das Couves",
            Telephone = "16997225955",
            Adress = ad,
            Dt_Register = DateTime.Now

        };

        if (new ClientController().Insert(client))
            Console.WriteLine("Sucesso! Cliente Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");




        new ClientController().FindAll().ForEach(Console.WriteLine);
    }
}