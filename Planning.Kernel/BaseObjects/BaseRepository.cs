﻿using System;
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
            dbConnection = new SqlConnection(ConnectionString);
            dataAdapter = new M();
        }

        //public abstract IBaseDataAdapter<T> GetDataAdapter();

        public virtual List<T> GetAll()
        {
            //string sql = $@"select id as {nameof(DelayReasons.Id)}, name as {nameof(DelayReasons.Name)} from delay_reasons";
            var queryResult = dbConnection.Query<T>(dataAdapter.GetSelectItemSql());

            return queryResult.ToList();
        }

        public virtual T GetById(int id)
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
                    }
                    catch (Exception ex )
                    {

                        _lastError = ex.Message;
                    }

                    break;
                case EditState.Edit:
                case EditState.Delete:
                    count = dbConnection.Execute(sql, Item);
                    break;
                default:
                    break;
            }

            
            return count > 0;
        }

        public bool Save(List<T> Items)
        {
            throw new NotImplementedException();
        }

        public string ConnectionString { get => _connectionString; }

        public string LastError { get => _lastError; }

    }
}
