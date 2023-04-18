using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class AddressServices
    {
        readonly string strConn = @"Server=(localdb)/MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Turismo.mdf";
        readonly SqlConnection conn;

        public AddressServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Address address )
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Address (Street, Number, Nighborhood, ZipCode, Extension, IdCity)" + "values (@Street, @Number, @Neighborhood, @ZipCode, @Extension, @IdCity)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Extension", address.Extension));
                commandInsert.Parameters.Add(new SqlParameter("@Extension", InsertCity(address)));
            }
            catch (Exception)
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

        private int InsertCity(Address address)
        {
            string strInsert = "insert into City (Description)" + "values (@Description); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand( strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", address.City.Description));

            return (int)commandInsert.ExecuteScalar();
        }
    }
}
