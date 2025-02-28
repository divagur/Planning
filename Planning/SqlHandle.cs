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
        private DataSet _dataSet;
        private DataRow _currentRow;
        private int _currentRowIdx;
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
        /*public SqlDataReader Reader
        {
            get
            {
                return _reader;
            }
        }
        */
        public DataSet DataSet
        {
            get
            {
                return _dataSet;
            }
        }
        public int GetIntValue(DataRow row, int columnIndex)
        {
            if (row == null)
                return 0;

            return row[columnIndex] == null ? 0 : Int32.Parse(row[columnIndex].ToString());

        }
        public int? GetNullIntValue(DataRow row, int columnIndex)
        {
            if (row == null)
                return 0;
             
            return row[columnIndex] == null || row[columnIndex].ToString()==String.Empty? 0 : (int?)(Int32.Parse(row[columnIndex].ToString()));

        }
        public string GetStringValue(DataRow row, int columnIndex)
        {
            if (row == null)
                return String.Empty;

            return row[columnIndex].ToString();

        }
        public decimal GetDecimalValue(DataRow row, int columnIndex)
        {
            if (row == null)
                return 0;

            return row[columnIndex] == null ? 0 : Decimal.Parse(row[columnIndex].ToString());

        }
        public DateTime? GetNullDateTimeValue(DataRow row, int columnIndex, bool onlyDate)
        {
            if (row == null)
                return null;
            DateTime? result = null;

            if (row[columnIndex] != "Null")
            {
                string value = row[columnIndex].ToString();
                if (String.IsNullOrEmpty(value))
                {
                    return null;
                }
                value = onlyDate ? value.Substring(0, 10) : value;
                result = (DateTime?)DateTime.Parse(value);
            }



            return result;
        }
        public DateTime GetDateTimeValue(DataRow row, int columnIndex, bool onlyDate)
        {
            if (row == null)
                return DateTime.MinValue;
            DateTime result = DateTime.MinValue;

            if (row[columnIndex] != "Null")
            {
                string value = row[columnIndex].ToString();
                value = onlyDate ? value.Substring(0, 10) : value;
                result = DateTime.Parse(value);
            }



            return result;
        }

        public bool IsNull(DataRow row, int columnIndex)
        {

            return (row == null || row[columnIndex] == null);
        }

        public int GetIntValue(int columnIndex)
        {
         
            return GetIntValue(_currentRow, columnIndex);

        }

        public int? GetNullIntValue(int columnIndex)
        {
            return GetNullIntValue(_currentRow, columnIndex);
        }

        public string GetStringValue(int columnIndex)
        {
            return GetStringValue(_currentRow, columnIndex);
        }

        public decimal GetDecimalValue(int columnIndex)
        {
            return GetDecimalValue(_currentRow, columnIndex);
        }

        public DateTime? GetNullDateTimeValue(int columnIndex, bool onlyDate )
        {
            return GetNullDateTimeValue(_currentRow, columnIndex, onlyDate);
        }
        public DateTime GetDateTimeValue(int columnIndex, bool onlyDate)
        {
            return GetDateTimeValue(_currentRow, columnIndex, onlyDate);
        }
        public bool IsNull(int columnIndex)
        {

            return IsNull(_currentRow, columnIndex);
        }
        public bool Read()
        {
            if (DataSet == null || !HasRows() || _currentRowIdx >= _dataSet.Tables[0].Rows.Count)
                return false;
            _currentRow = _dataSet.Tables[0].Rows[_currentRowIdx++];
            return true;
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
            _command.CommandTimeout = 180;
            _command.Connection = _connection;
            _command.CommandType = TypeCommand;
            var text = _command.CommandText;
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
                    //_reader = _command.ExecuteReader();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(_command);
                    

                    _dataSet = new DataSet();
                    dataAdapter.Fill(_dataSet);
                    _currentRowIdx = 0;
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
            finally
            {
                Disconnect();
            }
            
            return true;

            
        }

        public bool HasRows()
        {
            //return _reader != null && _reader.HasRows;
            return _dataSet != null && _dataSet.Tables != null && _dataSet.Tables.Count>0 && _dataSet.Tables[0].Rows.Count>0;
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
