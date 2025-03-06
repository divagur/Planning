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
using Planning.DataLayer;
namespace Planning
{
    public partial class ChooseOrder : Form
    {
        ShipmentAddResult _selectedResult;

        List<Planning.DataLayer.ShipmentOrder> _shipmentOrders;
        List<Planning.DataLayer.ShipmentOrderPart> _shipmentOrderParts;

        //Planning.DataLayer.Shipment _shipment;
        bool _isOrderParts;
        int? _LVOrderId;
        int? _depositorId;
        bool? _isShIn;
        LVOrder_Manager Order_Manager = new LVOrder_Manager();
        List<LVOrder> listOrders;
        //public ChooseOrder(ShipmentAddResult selectedResult, Planning.DataLayer.Shipment shipment, bool isOrderParts = false, int? LVOrderId = null)
        public ChooseOrder(ShipmentAddResult selectedResult, int? DepositorId, bool IsShIn, List<Planning.DataLayer.ShipmentOrder> _shipmentOrders,
                    bool isOrderParts = false, int? LVOrderId = null)
        {
            InitializeComponent();
            _selectedResult = selectedResult;            
            _depositorId = DepositorId;
            _isShIn = IsShIn;
            _isOrderParts = isOrderParts;
            _LVOrderId = LVOrderId;
            if (!isOrderParts)
                colOstCode.Visible = false;
            PopulateOrders();
        }
        private bool IsShpIn()
        {
            return _isShIn == null || _isShIn == true;
        }

        private List<LVOrder> GetOrderList()
        {
            List<LVOrder> result = new List<LVOrder>();            
            listOrders = Order_Manager.GetList(_depositorId, IsShpIn()?1:0, 0, _LVOrderId);
            
            if (_isOrderParts)
            {
                Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.First(o => o.LvOrderId == _LVOrderId);
                var listExclusionID = _shipmentOrderParts.Where(p => p.ShOrderId == shipmentOrder.Id).Select(p => p.OsLvId).ToList();
                    //shipmentOrder.ShipmentOrderParts.Select(p => (int?)p.OsLvId).ToList();
                result = listOrders.Where(o => !listExclusionID.Contains(o.OstID)).ToList();
            }
            else
            {
                var listExclusionID = _shipmentOrders.Select(o => o.LvOrderId).ToList();
                result = listOrders.Where(o => !listExclusionID.Contains(o.LVID)).ToList();
            }

            return result;
        }
        
        private void PopulateOrders()
        {
            
            listOrders = GetOrderList();
            
            if (!_isOrderParts)
            {
                LVOrderIdComparer lVOrderIdComparer = new LVOrderIdComparer();
                listOrders = listOrders.Distinct(lVOrderIdComparer).ToList();
            }
            tblOrders.AutoGenerateColumns = false;
            tblOrders.DataSource = listOrders;


            
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
