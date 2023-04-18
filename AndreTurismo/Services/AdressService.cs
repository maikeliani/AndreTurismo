using AndreTurismo.Models;
using System.Data.SqlClient;
using System.Text;

namespace AndreTurismo.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Turismo\turismo.mdf;";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Adress address)
        {
            bool status = false;
            try
            {
                string strInsert = "INSERT INTO Adress (Street, Number, Neighborhood, ZipCode, Complement, IdCity, Dt_Register ) VALUES (@Street, @Number, @Neighborhood, @ZipCode, @Complement, @IdCity, @Dt_Register ); SELECT CAST(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.NeighborHood));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));               
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", address.City));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", address.Dt_Register));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public List<Adress> FindAll()
        {
            List<Adress> addresses = new List<Adress>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT a.Id,");
            sb.Append(" a.Street,");
            sb.Append(" a.Number,");
            sb.Append(" a.Neighborhood,");
            sb.Append(" a.ZipCode,");
            sb.Append(" a.Complement,");
            sb.Append(" a.Dt_Register,");
            sb.Append(" a.IdCity,");
            sb.Append(" c.Id,");
            sb.Append(" c.Description,");            
            sb.Append(" FROM Address a, City c");
            sb.Append(" WHERE c.Id = a.IdCity");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Adress address = new Adress();

                address.Id = (int)dr["Id"];
                address.Street = (string)dr["Street"];
                address.Number = (int)dr["Number"];
                address.NeighborHood = (string)dr["Neighborhood"];
                address.ZipCode = (string)dr["ZipCode"];
                address.Complement = (string)dr["Complement"];
                address.Dt_Register = (DateTime)dr["Dt_Register"];
                address.City = new City()
                {
                    Id = (int)dr["IdCity"],
                    Description = (string)dr["Description"],
                    Dt_Register = (DateTime)dr["Dt_Register"]
                    
                };

                addresses.Add(address);
            }
            return addresses;
        }
    }
}