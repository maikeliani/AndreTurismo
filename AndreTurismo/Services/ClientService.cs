using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public  class ClientService
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
                string strInsert = "insert into Client (Name, Telephone , Adress, Dt_Register) values (@Name, @Telephone, @Adress, @Dt_Register)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
                commandInsert.Parameters.Add(new SqlParameter("@Adress", client.Adress));
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

        public List<Client> FindAll()
        {
            List<Client> clients = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.Id,");
            sb.Append("      c.Name,");
            sb.Append("      c.Telephone,");
            sb.Append("      c.Adress,");
            sb.Append("      c.Dt_Register");
            sb.Append("  from Client c, ");
            

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Telephone = (string) dr["Telephone"];
                client.Dt_Register = (DateTime)dr["Dt_Register"];
                client.Adress = new Adress() { Id = (int)dr["Adress"] };

                clients.Add(client);

            }
            return clients;
        }
    }
}
