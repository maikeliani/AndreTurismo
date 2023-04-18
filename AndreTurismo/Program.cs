using AndreTurismo.Controllers;
using AndreTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Client client = new()
        {
            Name = "Jose das Couves",
            Id = 1,
            Telephone = "16997225955",
             //Adress ad = new Adress() {Id =1 },
            
            Dt_Register = new DateTime(18/04/2023)
            
        };

        if (new ClientController().Insert(client))
            Console.WriteLine("Sucesso! Cliente Registrado");
        else
            Console.WriteLine("Erro ao inserir registro");




        new ClientController().FindAll().ForEach(Console.WriteLine);
    }
}