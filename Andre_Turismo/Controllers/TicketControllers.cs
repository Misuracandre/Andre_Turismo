using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Andre_Turismo.Services;

namespace Andre_Turismo.Controllers
{
    public class TicketControllers
    {
        public bool Insert(Ticket ticket)
        {
            return new TicketServices().Insert(ticket);
        }
    }
}
