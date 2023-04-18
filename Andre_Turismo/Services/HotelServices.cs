using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class HotelServices
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\fly.mdf;";
        readonly SqlConnection conn;

        public HotelServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Hotel hotel)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Hotel (Name, IdAddress)" + "values (@Name, @IdAddress)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(hotel)));

                commandInsert.ExecuteNonQuery();
                status = true;
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

        public int InsertAddress(Hotel hotel)
        {
            string strInsert = "insert into Hotel (Street, Number, Neighborhood, ZipCode, Extension)" + "values (@Street, @Number, @Neighborhood, @ZipCode, @Extension); select cast(scope_identity() as int";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", hotel.Address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Number", hotel.Address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", hotel.Address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@ZipCode", hotel.Address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Extension", hotel.Address.Extension));

            return (int)commandInsert.ExecuteScalar();


        }
    }
}
