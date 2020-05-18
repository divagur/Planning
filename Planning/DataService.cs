using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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

    public class DataService
    {
        //public static string connectionString = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        public static string connectionString = "";
        public static Dictionary<string, DictInfo> Dicts = new Dictionary<string, DictInfo>();

        public static List<Shipment> GetAll()
        {
            
            using (IDbConnection db = new SqlConnection(connectionString))

            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();        
                }

                return db.Query<Shipment>(@"SELECT id,lv_id,time_slot_id,s_date,s_comment,o_comment,gate_id,sp_condition,driver_phone,driver_fio,
                                                    vehicle_number,trailer_number,attorney_number,attorney_date,submission_time,start_time,end_time_plan,end_time_fact,
                                                    delay_reasons_id,delay_comment,depositor_id FROM shipments").ToList();
            }
        }

        public static Shipment Get(int Id)
        { 
            Shipment shipment = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                shipment = db.Query<Shipment>("SELECT * FROM shipments WHERE id = @id", new { Id }).FirstOrDefault();
            }
            return shipment;
        }

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

                command.ExecuteScalar();
            }
            return true;
        }
    }
}
