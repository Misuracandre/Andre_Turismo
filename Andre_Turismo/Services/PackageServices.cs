using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class PackageServices
    {
        readonly string strConn = @"Server=(localdb)/MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Turismo.mdf";
        readonly SqlConnection conn;

        public PackageServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Package (Hotel, Ticket, Value, Client, Registration_Date)" + "values (@Hotel, @Ticket, @Value, @Client, @Registration_Date";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Hotel", package.Hotel));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket", package.Ticket));
                commandInsert.Parameters.Add(new SqlParameter("@Value", package.Value));
                commandInsert.Parameters.Add(new SqlParameter("@Client", package.Value));
                commandInsert.Parameters.Add(new SqlParameter("@Registration_Date", package.Registration_Date));

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

        public List<Package> FindAll()
        {
            List<Package> package = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("Select p.Id, ");
            sb.Append("       p.Hotel, ");
            sb.Append("       p.Ticket, ");
            sb.Append("       p.Value, ");
            sb.Append("       p.Client, ");
            sb.Append("       p.Registration_Date");
            sb.Append("  from Package p, ");
            sb.Append("       ");

            return package;
        }
    }
}
