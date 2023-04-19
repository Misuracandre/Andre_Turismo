using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andre_Turismo.Models
{
    public class Package
    {
        public readonly static string INSERT = "insert into Package (IdHotel, IdClient, IdTicket, Value)" + "values (@IdHotel, @IdClient, @IdTicket, @Value)";

        public readonly static string GETALL = "select IdHotel, IdClient, IdTicket, Value from Package";
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public decimal Value { get; set; }
        public Client Client { get; set; }
        //public DateTime Registration_Date { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
