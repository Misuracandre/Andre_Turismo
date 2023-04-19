using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;
// Scalar = quando tem subquery;

namespace Andre_Turismo.Services
{
    public class TicketServices
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Proj_Tourism.mdf;";
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
                string strInsert = "insert into Ticket (IdOrigin, IdDestination, IdClient, Value)" + "values (@IdOrigin, @IdDestination, @IdClient, @Value)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdOrigin", InsertOrigin(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@IdDestination", InsertDestination(ticket)));
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
            int id = 0;

            string strInsert = "insert into Address (Street, IdCity)" + "values (@Street, @IdCity); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", ticket.Origin.Street));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", ticket.Origin.City));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        }

        private int InsertDestination(Ticket ticket)
        {
            int id = 0;

            string strInsert = "insert into Address (Neighborhood, IdCity)" + "values (@Neighborhood, @IdCity); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", ticket.Destination.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", ticket.Destination.City));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        }

        private int InsertClient(Ticket ticket)
        {
            int id = 0;

            string strInsert = "insert into Client (Name, Phone)" + "values (@Name, @Phone); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", ticket.Client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", ticket.Client.Phone));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        }
    }
}
