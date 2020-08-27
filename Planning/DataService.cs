using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Configuration;
using System.Windows.Forms;
using Dapper;

namespace Planning
{
    
    public enum EntityState
    {
        Unchanged,
        Added,
        Deleted,
        Edit

    }
    public class DictColumn
    {
        public string Id;
        public string DataField;
        public string Title;
        public bool IsPK;
        public SqlDbType DataType;
        public int Length;
        public int Width = 100;
        public bool IsVisible;
        public List<string> ItemValues;
    }
    public class DictSimple
    {
        public string Name;
        public string Title;
        public List<DictColumn> Columns = new List<DictColumn>();
        public string TableName;
    }

    public class DictData
    {
        public int id { get; set; }
        public string name { get; set; }
        //public string gateway_num { get; set; }
    }

    public class DictInfo
    {
        public string TableName;
        public string NameColumn;
    }

    public class UserAccessItem
    {
        public string FunctionId { get; set; }
        public string FunctionName { get; set; }
        public bool IsView { get; set; }
        public bool IsAppend { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }

    }
/*
    public class UserAccess
    {
        public List<UserAccessItem> User
    }
*/
    public class DataService
    {
        public static PlanningDbContext context;
        //public static string connectionString = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        public static string connectionString = "";
        public static Dictionary<string, DictInfo> Dicts = new Dictionary<string, DictInfo>();
        public static Settings setting = new Settings();
        //public static SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();


        public static Shipment Add(Shipment shipment)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = @"INSERT INTO shipments (lv_id,time_slot_id,s_comment,o_comment,gate_id,sp_condition,driver_phone,driver_fio,
                                                    vehicle_number,trailer_number,attorney_number,attorney_date,submission_time,start_time,end_time_plan,end_time_fact,
                                                    delay_reasons_id,delay_comment,depositor_id) 
                                VALUES(@lv_id,@time_slot_id,@s_comment,@o_comment,@gate_id,@sp_condition,@driver_phone,@driver_fio,
                                                    @vehicle_number,@trailer_number,@attorney_number,@attorney_date,@submission_time,@start_time,@end_time_plan,@end_time_fact,
                                                    @delay_reasons_id,@delay_comment,@depositor_id); 
                                SELECT CAST(SCOPE_IDENTITY() as int)";
/*
                var sqlQuery = @"INSERT INTO shipments (lv_id,time_slot_id,s_comment,o_comment,gate_id,sp_condition,driver_phone,driver_fio,
                                                    vehicle_number,trailer_number,attorney_number,submission_time,start_time,end_time_plan,
                                                    delay_reasons_id,delay_comment,depositor_id) 
                                VALUES(@lv_id,@time_slot_id,@s_comment,@o_comment,@gate_id,@sp_condition,@driver_phone,@driver_fio,
                                                    @vehicle_number,@trailer_number,@attorney_number,@submission_time,@start_time,@end_time_plan,
                                                    @delay_reasons_id,@delay_comment,@depositor_id); 
                                SELECT CAST(SCOPE_IDENTITY() as int)";
*/
                int? Id = db.Query<int>(sqlQuery, shipment).FirstOrDefault();
                //shipment.id = (int)Id;
            }

            return shipment;
        }

        public static bool Update(Shipment shipment)
        {
            int updateRowCount;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = @"UPDATE shipments SET lv_id = @lv_id,time_slot_id = @time_slot_id,s_comment = @s_comment,o_comment = @o_comment,gate_id = @gate_id,
                                                    sp_condition =@sp_condition,driver_phone = @driver_phone,driver_fio =@driver_fio, vehicle_number = @vehicle_number,
                                                    trailer_number = @trailer_number,attorney_number = @attorney_number,
                                                    attorney_date = @attorney_date,submission_time = @submission_time,start_time = @start_time,end_time_plan = @end_time_plan,
                                                    end_time_fact = @end_time_fact,
                                                    delay_reasons_id = @delay_reasons_id,delay_comment = @delay_comment,depositor_id = @depositor_id,
                                                    is_courier = @is_courier
                                WHERE id = @Id";
                updateRowCount = db.Execute(sqlQuery, shipment);
            }
            return updateRowCount > 0;
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM shipments WHERE id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public static List<DictData> GetDictAll(string DictName)
        {

            DictInfo DictInfo;
                
             if (!Dicts.TryGetValue(DictName, out DictInfo))
                return null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<DictData>($"SELECT id, {DictInfo.NameColumn} FROM {DictInfo.TableName}").ToList();
            }
        }
        public static void PopulateFromList(List<DictData> ListSource, ComboBox ComboBoxTaget)
        {
            if (ListSource == null || ComboBoxTaget == null) return;
            ComboBoxTaget.Items.Clear();
            foreach (DictData dt in ListSource)
            {
                ComboBoxTaget.Items.Add(dt.name);
            }
        }
        public static int? GetDictIdByName(string DictName, string NameValue)
        {
            DictInfo DictInfo;

            if (!Dicts.TryGetValue(DictName, out DictInfo))
                return null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<int?>($"SELECT id FROM {DictInfo.TableName} where name = '{NameValue}'").FirstOrDefault();
            }
        }
        public static int? GetDictIdByCondition(string DictName, string Condition)
        {
            DictInfo DictInfo;

            if (!Dicts.TryGetValue(DictName, out DictInfo))
                return 0;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<int?>("SELECT id FROM "+DictInfo.TableName+" where "+Condition).FirstOrDefault();
            }
        }
        public static string GetDictNameById(string DictName, int? IdValue)
        {
            DictInfo DictInfo;

            if (!Dicts.TryGetValue(DictName, out DictInfo))
                return "???";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<string>($"SELECT name FROM {DictInfo.TableName} where id = '{IdValue}'").FirstOrDefault();
            }
        }
        public static string GetDictValueById(string DictName,string FieldValue, int? IdValue)
        {
            DictInfo DictInfo;

            if (!Dicts.TryGetValue(DictName, out DictInfo))
                return "???";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<string>($"SELECT {FieldValue} FROM {DictInfo.TableName} where id = '{IdValue}'").FirstOrDefault();
            }
        }

        public static int? SQLGetIntValue(string SQLExpr)
        {

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                return db.Query<int>(SQLExpr).FirstOrDefault();
            }
            
        }

        public static bool AddShipmentToLV(int ShipmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText = "SP_PL_CreateShipmentInLV";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@ShID", Value = ShipmentId });
                try
                {
                    command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при создании отгрузки: "+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
            return true;
        }

        public static string GetEntityConnectionString(string connectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder();

            // WARNING
            // Check app config and set the appropriate DBModel
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = connectionString + ";MultipleActiveResultSets=True;App=EntityFramework;";
            entityBuilder.Metadata = @"res://*/DbPlaning.csdl|res://*/DbPlaning.ssdl|res://*/DbPlaning.msl";
            
            return entityBuilder.ToString();
        }


        public static List<UserAccessItem> GetPrvlg(string UserLogin)
        {
            
            List<UserAccessItem> dict = new List<UserAccessItem>();
            using (IDbConnection db = new SqlConnection(connectionString))

            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query<UserAccessItem>($"select id FunctionId, name FunctionName,is_view IsView,is_append IsAppend,is_edit IsEdit,is_delete IsDelete from fn_GetPrvlg('{UserLogin}')").ToList();
            }
            
            
        }
        public static bool IsLoginExist(string Login)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);

            sql.SqlStatement = $"select name from sys.server_principals  where type = 'S' and name = '{Login}' ";
            sql.IsResultSet = true;
            bool success =sql.Connect() && sql.Execute();

            success = sql.Reader.HasRows && sql.Reader.Read() && (bool)(sql.Reader.GetSqlString(0) != null);

            sql.Disconnect();

            return success;
        }

        public static bool IsUserExist(string DB, string User)
        {
            bool success;
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.Connect();
            /*
            sql.SqlStatement = $"USE {DB}";
            sql.IsResultSet = false;
            success = sql.Execute();
*/
            sql.IsResultSet = true;
            sql.SqlStatement = $"select  count(*) from {DB}.sys.database_principals where type = 'S' and name = '{User}'";
            success = sql.Execute();
            success = sql.Reader.Read() && (bool)(sql.Reader.GetSqlInt32(0) > 0);
            /*
            sql.SqlStatement = $"USE {DataService.setting.BaseName}";
            sql.IsResultSet = false;
            sql.Execute();
            */


            sql.Disconnect();
            return success;
        }


        public static bool CreateLogin(string Login, string Pswd, bool IsWindowsUser)
        {
            /*if (IsLoginExist(Login))
                return true;
            SqlHandle sql = new SqlHandle(DataService.connectionString);

            StringBuilder sqlStatement = new StringBuilder($"CREATE LOGIN { Login } ");

            if (!IsWindowsUser)
                sqlStatement.Append($"WITH PASSWORD = '{Pswd}, CHECK_POLICY = OFF';");
            sql.SqlStatement = sqlStatement.ToString();
            sql.Connect();

            bool success = sql.Execute();
            
            if  (!success)  
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sql.Disconnect();

            return success;
            */

            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.SqlStatement = "CreateLogin";
           
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Login", Value = Login });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Psw", Value = Pswd });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IsWnd", Value = IsWindowsUser });

            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sql.Disconnect();
            return success;
        
        }

        public static bool CreateDBUser(string DB, string User, string Login)
        {
            if (IsUserExist(DB, User))
                return true;
            bool success;
            
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            StringBuilder sqlStatement = new StringBuilder($"USE {DB};  CREATE USER [{Login}] FOR LOGIN [{Login}]");
            
            sql.SqlStatement = sqlStatement.ToString();
            
            success = sql.Connect() && sql.Execute();
            
            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql.SqlStatement = "sp_addrolemember";
            sql.Parameters.Add(new SqlParameter { ParameterName = "@rolename" });
            sql.Parameters.Add(new SqlParameter { ParameterName = "@membername" });
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = false;

            sql.Parameters["@rolename"].Value = "db_datareader";
            sql.Parameters["@membername"].Value = User;
            success = sql.Execute();
            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            sql.Parameters["@rolename"].Value = "db_datawriter";
            //sql.Parameters["@membername"].Value = User;

            success = sql.Execute();
            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (DB == DataService.setting.BaseName)
            {
                sql.Parameters["@rolename"].Value = "pl_user";
                success = sql.Execute();
                if (!success)
                {
                    MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            sql.TypeCommand = CommandType.Text;
            sql.SqlStatement = $"USE { DataService.setting.BaseName}";
            success = sql.Execute();


            sql.Disconnect();
            return true;
/*
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DB", Value = DB });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@User", Value = User });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Login", Value = Login });
            sql.SqlStatement = "CreateUser";
            bool success = sql.Connect() && sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
    */        
            return success;
        }


        public static bool DropUser(string Login)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);

            sql.SqlStatement = $"DROP USER IF EXISTS  {Login}";
            sql.Connect();
            bool success = sql.Execute();
            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            /*
            sql.SqlStatement = $"DROP LOGIN  {Login}";

            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            sql.Disconnect();
            return success;
        }
        public static string BuildConnectionString(string Server, string DB, string Login, string Pswd, bool IsWnd)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = Server;
            connectionString.InitialCatalog = DB;
            connectionString.IntegratedSecurity = IsWnd;
            if (!IsWnd)
            {
                connectionString.UserID = Login;
                connectionString.Password = Pswd;
            }

            return connectionString.ToString();
        }
        public static bool TryDBConnect(string Server, string DB, string Login, string Pswd,bool IsWnd, bool ShowError)
        {
            if (Server == null || DB == null || Login == null)
                return false;
            using (SqlConnection connection = new SqlConnection(BuildConnectionString(Server, DB, Login, Pswd, IsWnd)))
            {
                try
                {
                    connection.Open();
                    
                }
                catch (SqlException ex)
                {
                    if (ShowError)
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    return false;
                }
                finally
                {
                    connection.Close();
                }

            }
            return true;
        }
    }
}
