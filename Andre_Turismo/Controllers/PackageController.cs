using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre_Turismo.Models;
using Andre_Turismo.Services;

namespace Andre_Turismo.Controllers
{
    public class PackageController
    {
        public bool Insert(Package package)
        {
            return new PackageServices().Insert(package);
        }

        //public List<Package> FindAll()
        //{
        //    return new PackageServices().FindAll();
        //}
    }
}
