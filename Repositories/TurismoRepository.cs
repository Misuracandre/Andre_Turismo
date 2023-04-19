using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Andre_Turismo.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Repositories
{
    public class TurismoRepository : ITurismoRepository
    {
        private string Conn { get; set; }

        public TurismoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public List<Package> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var packages = db.Query<Package>(Package.GETALL);
                return (List<Package>)packages;
            }
        }

        public bool Insert(Package package)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(Package.INSERT, package);
                status = true;
            }
            return status;
        }

        public List<Package> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
