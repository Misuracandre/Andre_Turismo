using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andre_Turismo.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public DateTime Registration_Date { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} \nAddress: {Address}";
        }
    }
}
