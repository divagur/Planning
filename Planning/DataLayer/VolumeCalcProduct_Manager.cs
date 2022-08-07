using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning.DataLayer
{
    class VolumeCalcProduct_Manager
    {

        public List<VolumeCalcProduct> GetList(int? DepositorLVId, List<LVOrder> LVOrders)
        {
            List<VolumeCalcProduct> listProduct = new List<VolumeCalcProduct>();

            DataTable ordId = new DataTable();
            ordId.Columns.Add("ID");
            foreach(var item in LVOrders.Select(i => i.LVID).ToList())
            {
                ordId.Rows.Add(item);
            }
            
            

            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_GetProductList";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IDs", Value = ordId });
           

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

                while (sql.Reader.Read())
                {
                    VolumeCalcProduct poduct = new VolumeCalcProduct();
                    //LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
                    poduct.ordCode = sql.Reader.GetString(0);
                    poduct.prdCode = sql.Reader.GetString(1);
                    poduct.prdName = sql.Reader.GetString(2);
                    poduct.Qty = sql.Reader.GetDecimal(3);
                    poduct.Length = sql.Reader.GetDecimal(4);
                    poduct.Width = sql.Reader.GetDecimal(5);
                    poduct.Height = sql.Reader.GetDecimal(6);
                    poduct.Weight = sql.Reader.GetDecimal(7);
                    poduct.Volume = sql.Reader.GetDecimal(9);

                    listProduct.Add(poduct);

                }
            }

           
            return listProduct;
        }
    }
}
