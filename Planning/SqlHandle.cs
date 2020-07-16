using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    class SqlHandle
    {
        private string _connectionString;
        public string SqlStatement;
        public string LastError;

        public SqlHandle(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Execute()
        {
            if (SqlStatement == null || SqlStatement == "")
                return false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SqlStatement, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    LastError = ex.Message;
                    return false;                    
                }
            }
            return true;
        }

        public SqlDataReader ExecuteReader()
        {
            SqlDataReader reader;// = new SqlDataReader();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SqlStatement, connection);

                try
                {
                    reader  = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    LastError = ex.Message;
                    return null;
                }
            }
            return reader;
        }
    }
}
