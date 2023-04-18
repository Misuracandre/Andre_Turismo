using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;

namespace Andre_Turismo.Services
{
    public class TicketServices
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\fly.mdf;";
        readonly SqlConnection conn;

        public TicketServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Ticket ticket)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Ticket (IdAddress, IdAddress, IdClient, Value)" + "values (@IdAddress, @IdAddress, @IdClient, @Value)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertOrigin(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertDestination(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Value", ticket.Value));

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

        private int InsertOrigin(Ticket ticket)
        {
            string strInsert = "insert into Address (Street)" + "values (@Street); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", ticket.Origin.Street));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertDestination(Ticket ticket)
        {
            string strInsert = "insert into Address (Neighborhood)" + "values (@Neighborhood); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", ticket.Destination.Neighborhood));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertClient(Ticket ticket)
        {
            string strInsert = "insert into Client (Name, Phone)" + "values (@Name, @Phone); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", ticket.Client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", ticket.Client.Phone));

            return (int)commandInsert.ExecuteScalar();
        }
    }
}
