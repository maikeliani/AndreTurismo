﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
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
                string strInsert = "insert into Package (IdHotel, IdTicket , Dt_Register, Price, IdClient)" +
                    " values (@IdHotel, @IdTicket, @Dt_Register, @Price, @IdClient)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", InsertHotel(pack.Hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", InsertTicket(pack.Ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", pack.Dt_Register));
                commandInsert.Parameters.Add(new SqlParameter("@Price", pack.Price));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(pack.Client)));


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
                "(SourceAdress, DestinationAdress , IdClient, Dt_Register, Price)" +
                " values (@SourceAdress, @DestinationAdress, @IdClient, @Dt_Register, @Price); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@SourceAdress", InsertAdress(ticket.SourceAdress)));
            commandInsert.Parameters.Add(new SqlParameter("@DestinationAdress", InsertAdress(ticket.DestinationAdress)));
            commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(ticket.Client)));
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
            string strInsert = "insert into Client (Name, Telephone, IdAdress, Dt_Register) values (@Name, @Telephone, @IdAdress, @Dt_Register  ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(client.Adress)));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", client.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

        }



        public bool Delete(int id)
        {
            bool status = false;
            try
            {
                string strInsert = " DELETE FROM Package where Id = @Id ";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                commandInsert.Parameters.Add(new SqlParameter("@Id", id));

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


        public List<Package> FindAll()
        {
            List<Package> packs = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT p.Id, ");
            sb.Append("       p.Dt_Register, ");

            sb.Append("       p.Price, ");
            sb.Append("       p.IdClient, ");
            sb.Append("       p.IdTicket, ");
            sb.Append("       p.IdHotel ");
            sb.Append(" FROM Package p ");



            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package p = new();

                p.Id = (int)dr["Id"];
                p.Price = (double)dr["Price"];
                p.Ticket = new Ticket()
                {
                    Id = (int)dr["IdTicket"],

                };
                p.Hotel = new Hotel()
                {
                    Id = (int)dr["IdHotel"]
                                                       

                };                
               
                p.Price = (double)dr["Price"];
                p.Client = new Client()
                {
                    Id = (int)dr["IdClient"]



                };

                packs.Add(p);

            }
            return packs;
        }



        public bool Update(Hotel hotel, Ticket ticket, double price, Client client, int id)
        {
            bool status = false;
            try
            {
                string strInsert = "Update  Package set IdHotel = @IdHotel, IdTicket = @IdTicket, Price = @Price, IdClient = @IdClient  where Package.Id = @Id";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", InsertHotel(hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", InsertTicket(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Price", price));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(client)));
                commandInsert.Parameters.Add(new SqlParameter("@Id", id));

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
    }
}
