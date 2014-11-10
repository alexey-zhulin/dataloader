using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLoader
{
    class DBHandler
    {
        SqlConnection connection;
        Exception connectException;
        public string ServerName;
        public string Database;
        public string UserName;
        public string Pwd;
        public bool DomainAuth;
        public Exception ConnectException { get { return connectException; } }
        public ConnectionState connectionState { get { return connection.State; } }

        public DBHandler()
        {
            connection = new SqlConnection();
        }

        private string GetConnectionString()
        {
            if (DomainAuth)
            {
                return"server=" + ServerName + "; Integrated Security=true; database=" + Database + "; connection timeout=30";
            }
            else
            {
                return "user id=" + UserName + ";password=" + Pwd + "; server=" + ServerName + "; Trusted_Connection=false; database=" + Database + "; connection timeout=30";
            };
        }

        public bool Connect()
        {
            string connectionString = GetConnectionString();
            using (connection)
            {
                connection.ConnectionString = connectionString;
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    connectException = e;
                    return false;
                }
            }
            return true;
        }
    }
}
