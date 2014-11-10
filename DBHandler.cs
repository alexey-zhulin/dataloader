using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLoader
{
    class DBHandler : IDisposable
    {
        SqlConnection connection;
        Exception connectException;
        bool tableWasCreated;
        public string ServerName;
        public string Database;
        public string UserName;
        public string Pwd;
        public bool DomainAuth;
        public string TableName;
        public string Schema = "dbo";
        public Exception ConnectException { get { return connectException; } }
        public ConnectionState connectionState { get { return connection.State; } }
        public bool TableWasCreated { get { return tableWasCreated; } }

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
            return true;
        }

        public void CreateTable()
        {
            string queryText = "Select * From INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = @Schema And  TABLE_NAME = @TableName";
            SqlCommand dbCommand = new SqlCommand(queryText, connection);
            dbCommand.Parameters.Add("Schema", SqlDbType.VarChar).Value = Schema;
            dbCommand.Parameters.Add("TableName", SqlDbType.VarChar).Value = TableName;
            SqlDataReader cursor = dbCommand.ExecuteReader();
            tableWasCreated = false;
            if (!cursor.Read())
            {
                tableWasCreated = true;
            }
            cursor.Close();
            cursor.Dispose();
            if (tableWasCreated)
            {
                queryText = "create table [" + Schema + "].[" + TableName + "] (" +
                            "ParamId              integer              identity," +
                            "Param                nvarchar(Max)        null," +
                            "ParamCode            nvarchar(100)        null," +
                            "ParamCode2           nvarchar(100)        null," +
                            "SubjectId            integer              null," +
                            "FDate                date	                null," +
                            "CL                   integer              null," +
                            "VerId                integer              null," +
                            "AValue1              numeric(18,2)        null," +
                            "AValue2              numeric(18,2)        null," +
                            "AValue3              numeric(18,2)        null," +
                            "constraint PK_" + TableName + " primary key (ParamId)" +
                            ")";
                dbCommand = new SqlCommand(queryText, connection);
                dbCommand.ExecuteNonQuery();
            }
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
