using AndreTurismo.Models;
using System.Data.SqlClient;
using System.Reflection.Emit;
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
                string strInsert = "INSERT INTO Adress (Street, Number, Neighborhood, ZipCode, Complement, IdCity, Dt_Register )" +
                    " VALUES (@Street, @Number, @Neighborhood, @ZipCode, @Complement, @IdCity, @Dt_Register );" +
                    " SELECT CAST(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.NeighborHood));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));               
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(address.City)));
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

        //METODO DELETE

        public bool Delete(string street, int number, string zipCode)
        {
            bool status = false;
            try
            {
               
                Console.WriteLine($"{street} {number} {zipCode}");
                Console.ReadLine();
        
                string strInsert = " DELETE FROM Adress where Adress.Street = @Street and Adress.Number = @Number and Adress.ZipCode = zipCode";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                commandInsert.Parameters.Add(new SqlParameter("@Street", street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", number));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", zipCode));


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


        private int InsertCity(City city)
        {
            string strInsert = "insert into City (Description, Dt_Register) values (@Description, @Dt_Register ); " +
                "select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            commandInsert.Parameters.Add(new SqlParameter("@Dt_Register", city.Dt_Register));
            return (int)commandInsert.ExecuteScalar();

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
                    Id = (int)dr["Id"],
                    Description = (string)dr["Description"],
                    Dt_Register = (DateTime)dr["Dt_Register"]
                    
                };

                addresses.Add(address);
            }
            return addresses;
        }


        public bool Update(string newStreet, int newNumber, string neighborHood , string newNeighborHood ,string zipCode, string newZipCode, string newComplement )
        {
            bool status = false;
            try
            {
                
                string strInsert = "Update  Adress set Street = @newStreet, Number = @newNumber ," +
                    " NeighborHood = @newNeighborHood, ZipCode = @newZipCode, Complement = @newComplement " +
                    "where Adress.NeighborHood = @NeighborHood and Adress.ZipCode = @ZipCode";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@newStreet", newStreet));
                commandInsert.Parameters.Add(new SqlParameter("@newNumber", newNumber));
                commandInsert.Parameters.Add(new SqlParameter("@newNeighborHood", newNeighborHood));
                commandInsert.Parameters.Add(new SqlParameter("@newZipCode", newZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@newComplement", newComplement));
                commandInsert.Parameters.Add(new SqlParameter("@NeighborHood", neighborHood));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", zipCode));


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