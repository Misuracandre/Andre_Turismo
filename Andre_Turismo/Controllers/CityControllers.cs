using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Andre_Turismo.Services;

namespace Andre_Turismo.Controllers
{
    public class CityControllers
    {
        public bool Insert(City city)
        {
            new CityServices().Insert(city);

            return true;
        }
    }
}
