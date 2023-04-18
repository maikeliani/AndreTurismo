using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public class CityService
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\Turismo\turismo.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(StrConn);
            conn.Open();
        }

        public bool Insert(City city)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into City (Description, Dt_Register) values (@Description, @Dt_Register)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", city.Dt_Register));
     

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

        public List<City> FindAll()
        {
            List<City> cities = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.Id,");
            sb.Append("      c.Description,");
            sb.Append("      c.Dt_Register,");            
            sb.Append("  from City c, ");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            City city = new();
            while (dr.Read())
            {
                

                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];                
                city.Dt_Register = (DateTime)dr["Dt_Register"];
                cities.Add(city);
            };

            return cities;

        }
            
        
    }
}
