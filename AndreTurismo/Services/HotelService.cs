using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;


namespace AndreTurismo.Services
{
    public class HotelService
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\Turismo\turismo.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(StrConn);
            conn.Open();
        }

        public bool Insert(Hotel hotel)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Hotel (Name, IdAdress , Dt_Register, Price) values (@Name, @IdAdress, @Dt_Register, @Price)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAdress", InsertAdress(hotel.Adress)));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", hotel.Dt_Register));
                commandInsert.Parameters.Add(new SqlParameter("@Price", hotel.Price));

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

        public bool Delete(int Id)
        {
            bool status = false;
            try
            {                
               
                string strInsert = " DELETE FROM Hotel where Id = @Id ";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                commandInsert.Parameters.Add(new SqlParameter("@Id", Id));
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
            // cria um objeto do tipo City para servir como referencia
        private int InsertCity(City city)
        {
            string strInsert = "insert into City (Description, Dt_Register) values (@Description, @Dt_Register ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", city.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

        }




        public List<Hotel> FindAll()
        {
            List<Hotel> hotels = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select h.Id,");
            sb.Append("      h.Name,");
            sb.Append("      h.IdAdress,");           
            sb.Append("      h.Dt_Register,");
            sb.Append("      h.Price");
            sb.Append("  from Hotel h ,");
            sb.Append("    Adress a ");
            sb.Append("  where h.IdAdress = a.Id ");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel h = new();

                h.Id = (int) dr["Id"];
                h.Name = (string) dr["Name"];
                h.Adress = new Adress() { Id = (int)dr["IdAdress"] };
                h.Dt_Register = (DateTime)dr["Dt_Register"];
                h.Price = (double)dr["Price"];

                hotels.Add(h);

            }
            return hotels;
        }
    }
}
