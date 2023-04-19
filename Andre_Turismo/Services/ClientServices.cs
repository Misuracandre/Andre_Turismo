using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class ClientServices
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Proj_Tourism.mdf;";
        readonly SqlConnection conn;

        public ClientServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Client client)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Client (Name, Phone, IdAddress)" + "values (@Name, @Phone, @IdAddress)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(client)));

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

        public int InsertAddress(Client client)
        {
            int id = 0;

            string strInsert = "insert into Address (Street, Number, Neighborhood, ZipCode, Extension)" + "values (@Street, @Number, @Neighborhood, @ZipCode, @Extension); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", client.Address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Number", client.Address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", client.Address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@ZipCode", client.Address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Extension", client.Address.Extension));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        } 
    }
}
