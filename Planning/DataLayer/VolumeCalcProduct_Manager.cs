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
        private static List<VolumeCalcProduct> GetProducts(int? DepositorLVId, List<int> listOrdersId, List<string> listVendorCodes, int Mode)
        {
            List<VolumeCalcProduct> listProduct = new List<VolumeCalcProduct>();

            DataTable OrderId = new DataTable();
            OrderId.Columns.Add("ID");
            foreach (var item in listOrdersId)
            {
                OrderId.Rows.Add(item);
            }

            DataTable Codes = new DataTable();
            Codes.Columns.Add("ID");
            foreach (var item in listVendorCodes)
            {
                Codes.Rows.Add(item);
            }

            



            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_GetProductList";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@IDs", Value = OrderId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ProductIDs", Value = Codes });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Mode", Value = Mode });


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
                    VolumeCalcProduct poduct = new VolumeCalcProduct();
                    //LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
                    poduct.ordCode = sql.GetStringValue(0);
                    poduct.prdCode = sql.GetStringValue(1);
                    poduct.prdName = sql.GetStringValue(2);
                    poduct.Qty = sql.GetDecimalValue(3); 
                    poduct.Length = sql.GetDecimalValue(4);
                    poduct.Width = sql.GetDecimalValue(5);
                    poduct.Height = sql.GetDecimalValue(6);
                    poduct.Weight = sql.GetDecimalValue(7);
                    poduct.Volume = sql.GetDecimalValue(9);

                    listProduct.Add(poduct);
                }
                /*
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
                */
            }

            sql.Disconnect();
            return listProduct;
        }
        public static List<VolumeCalcProduct> GetList(int? DepositorLVId, List<LVOrder> LVOrders)
        {
            return GetProducts(DepositorLVId, LVOrders.Select(i => i.LVID).ToList(), new List<string>(), 0);
            /*
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
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ProductIDs", Value = null});
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Mode", Value = 0 });


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

           
            return listProduct;*/
        }


        public static List<VolumeCalcProduct> GetList(int? DepositorLVId, List<string> listVendorCodes)
        {
            return GetProducts(DepositorLVId, new List<int>(), listVendorCodes, 1);
        }

    }
}
