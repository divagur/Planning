using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Planning
{
    public class OrderDetailItem_Manager
    {
        public List<OrderDetailItem> GetOrderDetailItems(int? DepositorLVId, int InOutType, int ordId, bool isAll = false)
        {
            List<OrderDetailItem> listOrderDetailItems = new List<OrderDetailItem>();

            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "sp_GetOrderDetail";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;           
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = InOutType });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@LVID", Value = ordId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IsAll", Value = isAll });
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

                while (sql.Read())
                {
                    OrderDetailItem order = new OrderDetailItem();
                    order.ID = sql.GetIntValue(0);
                    order.PrimaryCode = sql.GetStringValue(1);
                    order.ShortDescription = sql.GetStringValue(2);
                    order.Quantity = sql.GetDecimalValue(3);
                    order.DetailType = sql.GetIntValue(4);
                    listOrderDetailItems.Add(order);
                }

            }
            return listOrderDetailItems;
        }
    }
}
