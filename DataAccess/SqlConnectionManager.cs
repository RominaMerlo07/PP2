using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlConnectionManager
    {
        public string getCadenaConexion()
        {
            return ConfigurationManager.AppSettings["TURNERO_WEB"];
        }

    }
}
