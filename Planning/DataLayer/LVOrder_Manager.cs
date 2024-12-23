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
        public List<LVOrder> GetList(int? DepositorLVId, int Type, int IsAll = 1, int? OrderId = null)
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
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@LVID", Value = OrderId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IsAll", Value = IsAll });

            try
            {
                sql.Execute();
            }
            catch (Exception)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (sql.HasRows())
            {
                
                foreach (DataRow row in sql.DataSet.Tables[0].Rows)
                {
                    LVOrder order = new LVOrder();
                    //LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
                    
                    order.LVID = Int32.Parse(row[0].ToString());
                    order.LVCode = row[1].ToString();
                    order.LVStatus = row[2].ToString();
                    order.ExpDate = row[3].ToString() != "Null" && row[3].ToString() !=""? (DateTime?)DateTime.Parse(row[3].ToString().Substring(0, 10)) : null;
                    order.Company = row[4].ToString();
                    order.DepLVID = row[5] == null? null: (int?)(Int32.Parse(row[5].ToString()));
                    order.OstID = row[6] == null || row[6].ToString() =="" ? null : (int?)(Int32.Parse(row[6].ToString()));
                    object objOstCode = row[7].ToString();
                    order.IsEdm = row[8].ToString() == "Null" || string.IsNullOrEmpty(row[8].ToString()) ? false:(bool?)(bool.Parse(row[8].ToString()));
                    order.OstCode = objOstCode == null ? "" : (string)objOstCode;
                    
                    listLVOrder.Add(order);
                }
                /*
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
                */
            }
            
            
            return listLVOrder;
        }
    }
}
