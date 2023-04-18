using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Andre_Turismo.Services;

namespace Andre_Turismo.Controllers
{
    public class HotelControllers
    {
        public bool Insert(Hotel hotel)
        {
            return new HotelServices().Insert(hotel);
        }
    }
}
