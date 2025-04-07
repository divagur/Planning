using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Planning.Kernel
{
    public class BaseRepository<T, M>:IRepository<T>
        where T : BaseDataItem
        where M : IDataAdaper, new()
    {
        //IBaseDataAdapter<T> _dataAdapter;
        string _connectionString;
        string _lastError = "";
        protected IDbConnection dbConnection = null;
        protected M dataAdapter;
        public BaseRepository(string connectionString)
        {
            //_dataAdapter = GetDataAdapter();
            _connectionString = connectionString;
            InitConnection(connectionString);
            
        }

        public BaseRepository()
        {
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
            dataAdapter = new M();
        }
        //public abstract IBaseDataAdapter<T> GetDataAdapter();

        public virtual List<T> GetAll()
        {
            List<T> result = new List<T>();
            string queryText = dataAdapter.GetSelectItemSql();
            if (!String.IsNullOrEmpty(queryText))
            {
                var queryResult = dbConnection.Query<T>(queryText);
                if (queryResult != null)
                {
                    result = queryResult.ToList();
                }
            }
            
            return result.ToList();
        }

        public virtual T GetById(int? id)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where id = @Id";
            T item = null;
            var queryResult = dbConnection.Query<T>(sql, new { Id = id });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }    
   
        public virtual bool Save(T Item)
        {
            EditState itemState = Item.GetState();
            int count = 0;
            string sql = dataAdapter.GetSaveSql(itemState);
            switch (itemState)
            {
                case EditState.New:
                    sql = sql + " select SCOPE_IDENTITY()";
                    try
                    {
                        var ids = dbConnection.Query<int>(sql, Item);
                        Item.Id = ids.First();
                        count = ids.Count();
                    }
                    catch (Exception ex )
                    {

                        _lastError = ex.Message;
                    }

                    break;
                case EditState.Edit:
                case EditState.Delete:
                    try
                    {
                        count = dbConnection.Execute(sql, Item);
                    }
                    catch (Exception ex)
                    {

                        string s = ex.Message;
                    }
                    
                    break;
                default:
                    break;
            }

            
            return count > 0;
        }

        public bool Save(List<T> Items)
        {
            bool result = false;

            foreach (var item in Items)
            {
                result = Save(item);
                if (!result)
                    break;
            }
            return result;
        }

        public string ConnectionString { get => _connectionString; }

        public string LastError { get => _lastError; }

    }
}
