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
        public bool Insert(Address address)
        {
            return new AddressServices().Insert(address);
        }
    }
}
