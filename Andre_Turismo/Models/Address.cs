using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andre_Turismo.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Extension { get; set; }
        public City City { get; set; }
        public DateTime Registration_Date { get; set; }

        public override string ToString()
        {
            return $"Street: {Street}| Number: {Number}| Neighborhood: {Neighborhood}| ZipCode: {ZipCode}| Extension: {Extension}| City: {City}";
        }
    }
}
