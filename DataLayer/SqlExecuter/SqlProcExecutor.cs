using Dapper;
using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class SqlProcExecutor
    {
        protected IDbConnection dbConnection = null;
        string _connectionString;
        public SqlProcExecutor(string connectionString)
        {
            //_dataAdapter = GetDataAdapter();
            _connectionString = connectionString;
            InitConnection(connectionString);

        }

        public SqlProcExecutor()
        {
            if (String.IsNullOrEmpty(ConnectionParams.ServerName) || String.IsNullOrEmpty(ConnectionParams.BaseName))
                return;
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = ConnectionParams.ServerName;
            sqlConnectionString.InitialCatalog = ConnectionParams.BaseName;
            sqlConnectionString.UserID = ConnectionParams.UserName;
            sqlConnectionString.Password = ConnectionParams.Pwd;
            InitConnection(sqlConnectionString.ToString());
        }

        protected virtual void InitConnection(string connectionString)
        {
            dbConnection = new SqlConnection(connectionString);
        }

        public List<T> ProcExecute<T>(string ProcName,  Dictionary<string, object> Parametrs)
            where T:class
            
        {
            List<T> result = new List<T>();

            DynamicParameters parameters = new DynamicParameters();
            foreach (var item in Parametrs)
            {
                parameters.Add(item.Key,item.Value);
            }
            try
            {
                var queryResult = dbConnection.Query<T>(ProcName, parameters, commandType: CommandType.StoredProcedure);
                if (queryResult != null)
                {
                    result = queryResult.ToList();

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
  
            return result;
        }
    }
}
