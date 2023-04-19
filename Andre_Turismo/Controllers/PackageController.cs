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
        private PackageServices packageServices;

        public PackageController()
        {
            packageServices = new PackageServices();
        }

        public bool Insert(Package package)
        {
            return packageServices.Insert(package);
        }

        public List<Package> GetAll()
        {
            return packageServices.GetAll();
        }
    }
}
