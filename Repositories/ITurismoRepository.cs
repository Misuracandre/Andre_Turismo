using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;

namespace Repositories
{
    public interface ITurismoRepository
    {
        bool Insert(Package package);

        List<Package> GetAll();
    }
}
