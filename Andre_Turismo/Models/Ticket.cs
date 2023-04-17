using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andre_Turismo.Models
{
    public class Ticket
    {
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
