using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    

    class SqlHandle
    {
        private string _connectionString;
        private SqlConnection _connection;
        private SqlDataReader _reader;
        private SqlCommand _command;
        public static event Action<string> OnExecuteBeforeCommon;
        public static event Action<string> OnExecuteAfterCommon;

        public string SqlStatement
        { get
            { return _command.CommandText; }
          set
            {
                _command.CommandText = value;
            }
        }

        public string LastError;
        public bool IsResultSet;
        
        public CommandType TypeCommand
        {
            get
            {
                return _command.CommandType;
            }
            set
            {
                _command.CommandType = value;
            }
        }
        public SqlDataReader Reader
        {
            get
            {
                return _reader;
            }
        }

        public SqlParameterCollection Parameters
        {
            get
            {
                return _command.Parameters;
            }
        }
        public SqlHandle(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            TypeCommand = CommandType.Text;
            IsResultSet = false;
        }

        public bool Connect()
        {
            
            try
            {
                _connection.Open();
            }
            catch(SqlException ex)
            {
                LastError = ex.Message;
                return false;
            }

            return true;
        }
        

        public void Disconnect()
        {
            _connection.Close();
        }
        private bool CanExecute()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                LastError = "Попытка выполнения запроса при неактивном подключении к базе данных";
                return false;
            }
            return true;
        }

        public bool Execute()
        {
            if (SqlStatement == null || SqlStatement == "" || !CanExecute())
                return false;

            //SqlCommand command = new SqlCommand(SqlStatement, _connection);
            //_command.CommandText = SqlStatement;
            _command.Connection = _connection;
            _command.CommandType = TypeCommand;
            
            try
            {
                OnExecuteBeforeCommon?.Invoke(SqlStatement);
                //Если есть ридер с прошлого вызова и он не закрыт то закроем
                if (_reader != null && !_reader.IsClosed)
                {
                    _reader.Close();
                }

                if (IsResultSet)
                {
                    _reader = _command.ExecuteReader();
                }
                    
                else
                    _command.ExecuteNonQuery();
                OnExecuteAfterCommon?.Invoke(SqlStatement);
            }
            catch (SqlException ex)
            {
                LastError = ex.Message;
                return false;
            } 
          /*  finally
            {
                Disconnect();
            }
            */
            return true;

            
        }

        public bool HasRows()
        {
            return _reader != null && _reader.HasRows;
        }

        public void AddCommandParametr(SqlParameter param)
        {
            _command.Parameters.Add(param);
            
        }
        public SqlDataReader ExecuteReader()
        {

            if (SqlStatement == null || SqlStatement == "" || !CanExecute())
                return null;

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
