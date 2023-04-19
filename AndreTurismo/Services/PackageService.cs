﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public class PackageService
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\Turismo\turismo.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(StrConn);
            conn.Open();
        }

        public bool Insert(Package pack)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Package (Hotel, Ticket , Dt_Register, Price, Client) values (@Hotel, @Ticket, @Dt_Register, @Price, @Client)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Hotel", InsertHotel(pack.Hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket", InsertTicket(pack.Ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", pack.Dt_Register));
                commandInsert.Parameters.Add(new SqlParameter("@Price", pack.Price));
                commandInsert.Parameters.Add(new SqlParameter("@Client", InsertClient(pack.Client)));
               

                commandInsert.ExecuteNonQuery();
                status = true;
                return true;
            }
            catch (Exception e)
            {

                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        private int InsertTicket(Ticket ticket)
        {
            string strInsert = "insert into Ticket " +
                "(SourceAdress, DestinationAdress , Client, Dt_Register, Price)" +
                " values (@SourceAdress, @DestinationAdress, @Client, @Dt_Register, @Price); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@SourceAdress", InsertAdress(ticket.SourceAdress)));
            commandInsert.Parameters.Add(new SqlParameter("@DestinationAdress", InsertAdress(ticket.DestinationAdress)));
            commandInsert.Parameters.Add(new SqlParameter("@Client", ticket.Client.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", ticket.Dt_Register));
            commandInsert.Parameters.Add(new SqlParameter("@Price", ticket.Price));
            return (int)commandInsert.ExecuteScalar();
        }


        private int InsertHotel(Hotel hotel)
        {
            string strInsert = "insert into Hotel " +
                "(Name, IdAdress , Dt_Register, Price) " +
                "values (@Name, @IdAdress, @Dt_Register, @Price); " +
            "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(hotel.Adress)));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", hotel.Dt_Register));
            commandInsert.Parameters.Add(new SqlParameter("@Price", hotel.Price));
            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertAdress(Adress adress)
        {
            string strInsert = "insert into Adress " +
                "(Street, Number, NeighborHood, ZipCode, Complement, IdCity, Dt_Register)" +
                " values (@Street, @Number, @NeighborHood, @ZipCode, @Complement, @IdCity , @Dt_Register ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", adress.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Number", adress.Number));
            commandInsert.Parameters.Add(new SqlParameter("@NeighborHood", adress.NeighborHood));
            commandInsert.Parameters.Add(new SqlParameter("@ZipCode", adress.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complement", adress.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(adress.City)));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", adress.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

        }

        private int InsertCity(City city)
        {
            string strInsert = "insert into City (Description, Dt_Register) values (@Description, @Dt_Register ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", city.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

        }


        private int InsertClient(Client client)
        {
            string strInsert = "insert into Client (Name, Telephone, IdAdress, Dt_Register) values (@Name, @Telephone, @IdAdress, Dt_Register  ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(client.Adress)));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", client.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

        }



        public List<Package> FindAll()
        {
            List<Package> packs = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.Id,");
            sb.Append("      h.IdHotel,");
            sb.Append("      t.IdTicket,");
            sb.Append("      p.Dt_Register,");
            sb.Append("      p.Price");
            sb.Append("      c.IdClient");
            sb.Append("  from Package p ,");
            sb.Append("    Ticket t , ");
            sb.Append("    Hotel h ");
            sb.Append("    Client c ");
            sb.Append("  where p.IdClient = c.Id and p.IdTicket = Ticket.Id  and p.IdHotel = h.Id");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package p = new();

                p.Id = (int)dr["Id"];
                p.Hotel = (Hotel)dr["IdHotel"];
                p.Ticket = (Ticket)dr["IdTicket"];
                p.Dt_Register = (DateTime)dr["Dt_Register"];
                p.Price = (double)dr["Price"];
                p.Client = new Client() { Id = (int)dr["IdClient"] };

                packs.Add(p);

            }
            return packs;
        }
    }
}