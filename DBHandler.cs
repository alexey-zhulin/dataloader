using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLoader
{
    class DBRecord
    {
        public object Param;
        public object ParamCode;
        public object ParamCode2;
        public object SubjectId;
        public object FDate;
        public object CL;
        public object AValue1;
        public object AValue2;
        public object AValue3;
    }
    
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
        public SqlConnection Connection { get { return connection; } }
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

        public void InsertRecord(DBRecord record)
        {
            string queryText = "insert into [" + Schema + "].[" + TableName + "]" + Environment.NewLine +
                                "(Param, ParamCode, ParamCode2, SubjectId, FDate, CL, AValue1, AValue2, AValue3)" + Environment.NewLine + 
                                "values" + Environment.NewLine +
                                "(@Param, @ParamCode, @ParamCode2, @SubjectId, @FDate, @CL, @AValue1, @AValue2, @AValue3)";
            SqlCommand dbCommand = new SqlCommand(queryText, connection);
            dbCommand.Parameters.Add("Param", SqlDbType.VarChar).Value = record.Param == null ? DBNull.Value : record.Param;
            dbCommand.Parameters.Add("ParamCode", SqlDbType.VarChar).Value = record.ParamCode == null ? DBNull.Value : record.ParamCode;
            dbCommand.Parameters.Add("ParamCode2", SqlDbType.VarChar).Value = record.ParamCode2 == null ? DBNull.Value : record.ParamCode2;
            dbCommand.Parameters.Add("SubjectId", SqlDbType.Int).Value = record.SubjectId == null ? DBNull.Value : record.SubjectId;
            dbCommand.Parameters.Add("FDate", SqlDbType.DateTime).Value = record.FDate == null ? DBNull.Value : record.FDate;
            dbCommand.Parameters.Add("CL", SqlDbType.Int).Value = record.CL == null ? DBNull.Value : record.CL;
            dbCommand.Parameters.Add("AValue1", SqlDbType.Float).Value = record.AValue1 == null ? DBNull.Value : record.AValue1;
            dbCommand.Parameters.Add("AValue2", SqlDbType.Float).Value = record.AValue2 == null ? DBNull.Value : record.AValue2;
            dbCommand.Parameters.Add("AValue3", SqlDbType.Float).Value = record.AValue3 == null ? DBNull.Value : record.AValue3;
            dbCommand.ExecuteNonQuery();
            /*
            using (SqlTransaction dbTrans = connection.BeginTransaction())
            {
                try
                {
                    dbCommand.ExecuteNonQuery();
                    dbTrans.Commit();
                }
                catch (SqlException)
                {
                    dbTrans.Rollback();
                    throw;
                }
            }
             * */
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
