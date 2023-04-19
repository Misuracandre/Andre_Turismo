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
        //readonly AddressServices _addressServices;
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Proj_Tourism.mdf";
        readonly SqlConnection conn;

        public PackageServices()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        //public PackageServices(AddressServices addressServices)
        //{
        //    _addressServices = addressServices;
        //}

        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Package (IdHotel, IdTicket, Value, IdClient)" + "values (@IdHotel, @IdClient, @IdTicket, @Value)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", InsertHotel(package)));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(package)));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", InsertTicket(package)));
                commandInsert.Parameters.Add(new SqlParameter("@Value", package.Value));
                

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

        public int InsertHotel(Package package)
        {
            int hotelId = 0;
            //int cityId = Insert;
            
            //int addressId = 0;


            string strInsert = "insert into Hotel (Name)" + "values (@Name); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", package.Hotel.Name));
            

            string strSelectId = "select scope_identity() as id";
            SqlCommand commandSelectId = new SqlCommand(strSelectId, conn);
            

            hotelId = (int)commandInsert.ExecuteScalar();
            return hotelId;
        }

        public int InsertTicket(Package package)
        {
            int id = 0;

            string strInsert = "insert into Ticket (IdOrigin, IdDestination, IdClient, Value)" + "values (@IdOrigin, @IdDestination, @IdClient, @Value); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@IdOrigin", package.Ticket.Origin.Id));
            commandInsert.Parameters.Add(new SqlParameter("@IdDestination", package.Ticket.Destination.Id));
            commandInsert.Parameters.Add(new SqlParameter("@IdClient", package.Ticket.Client));
            commandInsert.Parameters.Add(new SqlParameter("@Value", package.Ticket.Value));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        }

        public int InsertClient(Package package)
        {
            int id = 0;

            string strInsert = "insert into Client (Name, Phone, IdAddress)" + "values (@Name, @Phone, @IdAddress); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", package.Client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", package.Client.Phone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", package.Client.Address.Id));

            id = (int)commandInsert.ExecuteScalar();
            return id;
        }
        //public List<Package> FindAll()
        //{
        //    List<Package> package = new();

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Select p.Id, ");
        //    sb.Append("       p.Hotel, ");
        //    sb.Append("       p.Ticket, ");
        //    sb.Append("       p.Value, ");
        //    sb.Append("       p.Client, ");
        //    sb.Append("       p.Registration_Date");
        //    sb.Append("  from Package p, ");
        //    sb.Append("       ");

        //    return package;
        //}
    }
}
