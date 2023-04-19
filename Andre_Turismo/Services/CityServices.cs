using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class CityServices
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Proj_Tourism.mdf";
        readonly SqlConnection conn;

        public CityServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public City Insert(City city)
        {
            int id = 0;
            try
            {
                string strInsert = "insert into City (Description)" + "values (@Description); select cast(scope_Identity as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));

                id = (int) commandInsert.ExecuteScalar();
                //city.Id = id;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return city;
        }
    }
}
