using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class ChooseOrder : Form
    {
        ShipmentAddResult _selectedResult;
        Shipment _shipment;
        bool _isOrderParts;
        int? _LVOrderId;
        LVOrder_Manager Order_Manager = new LVOrder_Manager();
        List<LVOrder> listOrders;
        public ChooseOrder(ShipmentAddResult selectedResult, Shipment shipment, bool isOrderParts = false, int? LVOrderId = null)
        {
            InitializeComponent();
            _selectedResult = selectedResult;
            _shipment = shipment;
            _isOrderParts = isOrderParts;
            _LVOrderId = LVOrderId;
            if (!isOrderParts)
                colOstCode.Visible = false;
            PopulateOrders();
        }
        private bool IsShpIn()
        {
            return _shipment != null && (_shipment.ShIn == null || _shipment.ShIn == true);
        }

        private List<LVOrder> GetOrderList()
        {
            List<LVOrder> result = new List<LVOrder>();
            int? DepositorLVId = _shipment.DepositorId;
            listOrders = Order_Manager.GetList(DepositorLVId, IsShpIn()?1:0, 0, _LVOrderId);
            
            if (_isOrderParts)
            {
                ShipmentOrder shipmentOrder = _shipment.ShipmentOrders.First(o => o.LVOrderId == _LVOrderId);
                var listExclusionID = shipmentOrder.ShipmentOrderParts.Select(p => (int?)p.OsLvId).ToList();
                result = listOrders.Where(o => !listExclusionID.Contains(o.OstID)).ToList();
            }
            else
            {
                var listExclusionID = _shipment.ShipmentOrders.Select(o => o.LVOrderId).ToList();
                result = listOrders.Where(o => !listExclusionID.Contains(o.LVID)).ToList();
            }

            return result;
        }
        
        private void PopulateOrders(/*int DepositorLVId, int Type*/)
        {
            if (_shipment == null)
                return;

            
            int? Type = _shipment.ShIn == null ? null : (int?)Convert.ToInt32(_shipment.ShIn);
            listOrders = GetOrderList();
            
            if (!_isOrderParts)
            {
                LVOrderIdComparer lVOrderIdComparer = new LVOrderIdComparer();
                listOrders = listOrders.Distinct(lVOrderIdComparer).ToList();
            }
            tblOrders.AutoGenerateColumns = false;
            tblOrders.DataSource = listOrders;


            /*
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText = "sp_AddLoadingLVList";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@Split", Value = 0 });
                command.Parameters.Add(new SqlParameter { ParameterName = "@In", Value = Type });
                command.Parameters.Add(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });
                tblOrders.Rows.Clear();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    tblOrders.Rows.Clear();
                    while (reader.Read())
                    {
                        int Row = tblOrders.Rows.Add();
                        //object[] readerVal = new object[reader.FieldCount];
                        //reader.GetValues(readerVal);
                        tblOrders.Rows[Row].Cells[0].Value = reader.GetString(1);
                        tblOrders.Rows[Row].Cells[1].Value = reader.GetValue(7);
                        tblOrders.Rows[Row].Cells[2].Value = reader.GetString(2);

                        tblOrders.Rows[Row].Cells[3].Value = reader.GetSqlDateTime(3).ToString() != "Null" ? reader.GetSqlDateTime(3).ToString().Substring(0, 10) : "";
                        tblOrders.Rows[Row].Cells[4].Value = reader.GetString(4);
                        tblOrders.Rows[Row].Cells[5].Value = reader.GetInt32(0);

                        tblOrders.Rows[Row].Cells[6].Value = reader.GetValue(6);
                    }
                }

            }
            */
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tblOrders.CurrentCell !=null)
            {
                _selectedResult.Result = listOrders.Find(o => o.LVID == Int32.Parse(tblOrders.Rows[tblOrders.CurrentCell.RowIndex].Cells["colLVOrderId"].Value.ToString()));
            }
            DialogResult = DialogResult.OK;
        }

        private bool SearchBy(bool FromBegin, Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblOrders.CurrentRow.Index + 1;

            for (int i = startRow; i <= tblOrders.Rows.Count - 1; i++)
                if (condition(i))
                {

                    tblOrders.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblOrders.Rows[i].Cells["colId"];
                    tblOrders.CurrentCell = cell;
                    tblOrders.Rows[i].Selected = true;

                    return true;
                }
            return false;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchBy(true, r => tblOrders.Rows[r].Cells["colId"] != null && tblOrders.Rows[r].Cells["colId"].Value.ToString() == txtOrderId.Text);
        }
    }
}
