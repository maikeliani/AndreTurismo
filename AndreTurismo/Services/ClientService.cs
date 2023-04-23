using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public class ClientService
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\Turismo\turismo.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(StrConn);
            conn.Open();
        }

        public bool Insert(Client client)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Client (Name, Telephone , IdAdress, Dt_Register) values (@Name, @Telephone, @IdAdress, @Dt_Register)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
                commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(client.Adress)));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", client.Dt_Register));

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


        //  METODO PARA DELETAR


        public bool Delete(Client cli) 
        {
            bool status = false;
            try
            {
                Console.WriteLine(" O nome do cli é: " + cli.Name);
                Console.ReadLine();
                string strInsert = " DELETE FROM Client where Name = @Name ";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                commandInsert.Parameters.Add(new SqlParameter("@Name", cli.Name));


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



        //UPDATE

                    //usar join por causa do IdAdress
        public bool Update(Client client, string newName, string newTelephone,Adress adress )
        {
            bool status = false;
            try
            {
                Console.WriteLine(client.Name);
                Console.ReadLine();
                string strInsert = "Update  Client set Name = @Name, Telephone = @Telephone , IdAdress = @IdAdress where Client.Name = client.Name";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                
                commandInsert.Parameters.Add(new SqlParameter("@Name", newName));
                commandInsert.Parameters.Add(new SqlParameter("@Telephone", newTelephone));
                commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(adress)));

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




        public List<Client> FindAll()
        {
            List<Client> clients = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.Id,");
            sb.Append("      c.Name,");
            sb.Append("      c.Telephone,");
            sb.Append("      c.IdAdress,");
            sb.Append("      c.Dt_Register");
            sb.Append("  from Client c ,");
            sb.Append("    Adress a ");
            sb.Append("  where c.IdAdress = a.Id ");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Telephone = (string)dr["Telephone"];
                client.Dt_Register = (DateTime)dr["Dt_Register"];
                client.Adress = new Adress() { Id = (int)dr["IdAdress"] };

                clients.Add(client);

            }
            return clients;
        }
    }
}
