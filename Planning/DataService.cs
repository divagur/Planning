using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Planning
{
    public static class DataService
    {
        public static List<Shipment> GetAll()
        {
            
            using (IDbConnection db = new SqlConnection("Data Source =ПОЛЬЗОВАТЕЛЬ-ПК\\SQLEXPRESS2017; Initial Catalog = Planning; User ID = SYSADM; Password = SYSADM;"))

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
    }
}
