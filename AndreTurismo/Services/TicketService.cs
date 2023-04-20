using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public class TicketService
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\Turismo\turismo.mdf";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(StrConn);
            conn.Open();
        }



        public bool Insert(Ticket ticket)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Ticket (SourceAdress, DestinationAdress , IdClient, Dt_Register, Price)" +
                    " values (@SourceAdress, @DestinationAdress, @IdClient, @Dt_Register, @Price)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@SourceAdress", InsertAdress(ticket.SourceAdress)));
                commandInsert.Parameters.Add(new SqlParameter("@DestinationAdress", InsertAdress(ticket.DestinationAdress)));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(ticket.Client)));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", ticket.Dt_Register));
                commandInsert.Parameters.Add(new SqlParameter("@Price", ticket.Price));

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



        //DELETE
        public bool Delete(int id)
        {
            bool status = false;
            try
            {
                string strInsert = " DELETE FROM Ticket where Id = @Id ";
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




        public List<Ticket> FindAll()
        {
            List<Ticket> tickets = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select t.Id,");
            sb.Append("      t.SourceAdress,");
            sb.Append("      t.DestinationAdress,");
            sb.Append("      t.IdClient,");
            sb.Append("      t.Dt_Register,");
            sb.Append("      t.Price");
            sb.Append("  from Ticket t ,");
            sb.Append("    Adress a , ");
            sb.Append("    Client c ");
            sb.Append("  where c.IdAdress = a.Id and c.Id = t.IdClient ");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket t = new();

                t.Id = (int)dr["Id"];
                t.SourceAdress = new Adress() { Id = (int)dr["SourceAdress"] };
                t.DestinationAdress = new Adress() { Id = (int)dr["DestinationAdress"] };
                t.Client = new Client() { Id = (int)dr["IdClient"] };
                t.Dt_Register = (DateTime)dr["Dt_Register"];
                t.Price = (double)dr["Price"]; 

                tickets.Add(t);

            }
            return tickets;
        }
    }
}
