using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Reflection;

namespace Planning.DataLayer
{
    public class MSSqlAdapter
    {
        private string connectionString;
        public bool IsConnected => db != null && db.State == ConnectionState.Open;

        public string LastError = "";
        private SqlTransaction tr = null;
        private SqlConnection db;



        private bool IsConnectionStringValid()
        {
            if (connectionString == String.Empty)
            {
                throw new Exception("Не указана строка подключения к базе данных");
            }
            return true;
        }

        private string GetInsertString<T>()
        {
            Type type = typeof(T);
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            sb.Append($"insert into {type.Name}");
            StringBuilder sbCol = new StringBuilder();
            StringBuilder sbVal = new StringBuilder();
            foreach (var prop in props)
            {
                if (!Attribute.IsDefined(prop, typeof(DBFieldAttribute)))
                    continue;
                var attr = prop.GetCustomAttribute<DBFieldAttribute>();

                string dbField = attr.Field == null ? prop.Name : attr.Field;

                if (sbCol.Length != 0)
                    sbCol.Append(", ");
                sbCol.Append(dbField);

                if (sbVal.Length != 0)
                    sbVal.Append(", ");
                sbVal.Append($"@{prop.Name}");

            }

            sb.Append($"( {sbCol.ToString()}) values ({sbVal.ToString()})");

            return sb.ToString();
        }

        private string GetUpdateString<T>()
        {
            Type type = typeof(T);
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            StringBuilder sbCol = new StringBuilder();
            StringBuilder sbVal = new StringBuilder();
            string WhereKey = "";
            foreach (var prop in props)
            {
                if (!Attribute.IsDefined(prop, typeof(DBFieldAttribute)))
                    continue;
                var attr = prop.GetCustomAttribute<DBFieldAttribute>();

                string dbField = attr.Field == null ? prop.Name : attr.Field;
                if (dbField == "id")
                {
                    WhereKey = dbField + "=" + $"@{prop.Name}";
                    continue;
                }

                if (sbCol.Length != 0)
                    sbCol.Append(", ");
                sbCol.Append(dbField + "=" + $"@{prop.Name}");

            }
            if (sbCol.Length == 0)
                return "";

            sb.Append($"update {type.Name} set {sbCol.ToString()} where {WhereKey}");

            return sb.ToString();
        }


        public bool Conntect(string ConnectionString)
        {
            if (!IsConnected && IsConnectionStringValid())
            {
                connectionString = ConnectionString;
                db = new SqlConnection(connectionString);
                try
                {
                    db.Open();

                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при подключении к базе данных: " + ex.Message);

                }


            }

            return true;
        }

        public void BeginTransaction()
        {
            if (!IsConnected)
                return;

            tr = db.BeginTransaction();
        }
        public bool Commit()
        {
            if (!IsConnected)
                return false;
            try
            {
                tr.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return true;
        }

        public void Rollback()
        {
            if (!IsConnected)
                return;

            tr.Rollback();
        }

        public void Disconnected()
        {
            db.Close();
            db.Dispose();
        }

        public bool Save(T _instance)
        {
            if (!IsConnectionStringValid())
            {
                return false;
            }

            switch (_instance.State)
            {
                case ObjectState.New:
                    Insert(_instance);
                    break;
                case ObjectState.Edit:
                    Update(_instance);
                    break;
                case ObjectState.Delete:
                    break;
                default:
                    break;
            }

            return true;
        }

        public bool Insert<T>(T _instance)
        where T : BaseObject
        {
            if (!IsConnected || !IsConnectionStringValid())
            {
                return false;
            }
            Type type = typeof(T);

            string _insertQuery = GetInsertString<T>();

            try
            {
                db.Execute(_insertQuery, _instance);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении записи в таблицу [{type.Name}] :" + ex.Message);
            }

            return true;
        }

        public bool Update<T>(T _instance)
        where T : BaseObject
        {
            if (!IsConnected || !IsConnectionStringValid())
            {
                return false;
            }
            Type type = typeof(T);

            string _updateQuery = GetUpdateString<T>();

            try
            {
                db.Execute(_updateQuery, _instance);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении записи в таблице [{type.Name}] :" + ex.Message);
            }

            return true;
        }

        public bool Save<T>(List<T> _instance)
            where T : BaseObject
        {
            if (!IsConnected || !IsConnectionStringValid())
            {
                return false;
            }

            //Type type = typeof(T);

            foreach (var item in _instance)
            {
                switch (item.State)
                {
                    case ObjectState.New:
                        Insert(item);
                        break;
                    case ObjectState.Edit:
                        Update(item);
                        break;
                    case ObjectState.Delete:
                        break;
                    default:
                        break;
                }
            }
            /*
            string _insertQuery = GetInsertString<T>();
            
            try
            {
                db.Execute(_insertQuery, _instance);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении в таблицу [{type.Name}] :" + ex.Message);

                //LastError = ex.Message;
                //return false;
            }
            */
            return true;
        }

        public List<T> GetObjects<T>(string Where = "")
        where T : BaseObject
        {

            List<T> listObjects = new List<T>();


            if (!IsConnected || !IsConnectionStringValid())
            {
                return listObjects;
            }

            Type t = typeof(T);

            try
            {
                string where = Where == "" ? "" : $"WHERE {Where}";
                string select = $"SELECT * FROM {t.Name} {where}";
                listObjects = db.Query<T>(select).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выборке записей из таблицы [{t.Name}] :" + ex.Message);
                //LastError = ex.Message;

            }

            return listObjects.Select(x => { x.State = ObjectState.Edit; return x; }).ToList();
        }


        public T GetObject<T>(Guid id)
        {
            if (IsConnectionStringValid())
            {

                Type t = typeof(T);

                try
                {
                    return db.Query<T>($"SELECT * FROM {t.Name} WHERE id = @id", new { id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    LastError = ex.Message;
                    throw new Exception($"Ошибка при выборке записи из таблицы [{t.Name}] :" + ex.Message);

                }
            }

            return default(T);
        }



        public bool Delete<T>(string WhereCondition)
        {
            if (IsConnectionStringValid())
            {
                Type t = typeof(T);
                try
                {
                    /*
                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        string where = WhereCondition == String.Empty ? "" : $"WHERE {WhereCondition}";
                        var sqlQuery = $"DELETE FROM {t.Name} {where}";
                        connection.Execute(sqlQuery);
                    }*/
                    string where = WhereCondition == String.Empty ? "" : $"WHERE {WhereCondition}";
                    var sqlQuery = $"DELETE FROM {t.Name} {where}";
                    db.Execute(sqlQuery);

                }
                catch (Exception ex)
                {
                    LastError = ex.Message;
                    throw new Exception($"Ошибка при удалении записей из таблицы [{t.Name}] :" + ex.Message);

                }
            }
            return true;
        }
    }
}
