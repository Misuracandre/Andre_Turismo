using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Andre_Turismo.Services;

namespace Andre_Turismo.Controllers
{
    public class AddressControllers
    {
        private CityServices cityServices;
        private AddressServices addressServices;
        public AddressControllers()
        {
           cityServices = new CityServices();
           addressServices = new AddressServices();
        }
        public bool Insert(Address address)
        {
            address.City = cityServices.Insert(address.City);
            new AddressServices().Insert(address);

            return true;

        }
    }
}
