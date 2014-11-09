using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIR_Analitic_Loader
{
    class DBHandler
    {
        public string ServerName;
        public string Database;
        public string UserName;
        public string Pwd;
        public bool DomainAuth;

        public bool Connect()
        {
            return true;
        }
    }
}
