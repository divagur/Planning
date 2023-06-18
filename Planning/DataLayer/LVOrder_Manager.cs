using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    class LVOrder_Manager
    {
        public List<LVOrder> GetList(int? DepositorLVId, int Type)
        {
            List<LVOrder> listLVOrder = new List<LVOrder>();
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "sp_AddLoadingLVList";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Split", Value = 0 });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = Type });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IsAll", Value = 1 });

            try
            {
                sql.Execute();
            }
            catch (Exception)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (sql.Reader.HasRows)
            {

                while (sql.Reader.Read())
                {
                    LVOrder order = new LVOrder();
                    //LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
                    order.LVID = sql.Reader.GetInt32(0);
                    order.LVCode = sql.Reader.GetString(1);
                    order.LVStatus = sql.Reader.GetString(2);
                    order.ExpDate = sql.Reader.GetSqlDateTime(3).ToString() != "Null" ? (DateTime?)DateTime.Parse(sql.Reader.GetSqlDateTime(3).ToString().Substring(0, 10)) : null;
                    order.Company = sql.Reader.GetString(4);
                    order.DepLVID = sql.Reader.GetInt32(5);
                    order.OstID = sql.Reader.GetInt32(6);
                    object objOstCode = sql.Reader.GetString(7);
                    order.OstCode = objOstCode == null? "": (string)objOstCode;
                    listLVOrder.Add(order);

                }
            }
            
            
            return listLVOrder;
        }
    }
}
