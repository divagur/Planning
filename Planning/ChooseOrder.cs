using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        List<ShipmentOrder> _shipmentOrders;
        ShipmentOrder _shipmentOrder;
        List<ShipmentOrderPart> _shipmentOrderParts;

        //Planning.DataLayer.Shipment _shipment;
        bool _isOrderParts;
        int? _LVOrderId;
        int? _depositorId;
        int? _shipmentId;
        bool? _isShIn;

        LvSelectOrderRepository LvSelectOrderRepository = new LvSelectOrderRepository();
        List<LvSelectOrder> listOrders;

        //LVOrder_Manager Order_Manager = new LVOrder_Manager();
        //List<LVOrder> listOrders;
        //public ChooseOrder(ShipmentAddResult selectedResult, Planning.DataLayer.Shipment shipment, bool isOrderParts = false, int? LVOrderId = null)
        public ChooseOrder(ShipmentAddResult selectedResult,int? ShipmentId, int? DepositorId, bool? IsShIn, ShipmentOrder shipmentOrder,
                    bool isOrderParts = false, int? LVOrderId = null)
        {
            InitializeComponent();
            _selectedResult = selectedResult;            
            _depositorId = DepositorId;
            _isShIn = IsShIn;
            _shipmentOrder = shipmentOrder;
            _isOrderParts = isOrderParts;
            _LVOrderId = LVOrderId;
            _shipmentId = ShipmentId;
            if (!isOrderParts)
                colOstCode.Visible = false;
            PopulateOrders();
        }
        private bool IsShpIn()
        {
            return _isShIn == null || _isShIn == true;
        }

        private List<LvSelectOrder> GetOrderList()
        {
            List<LvSelectOrder> result = new List<LvSelectOrder>();
            // listOrders = Order_Manager.GetList(_depositorId, IsShpIn()?1:0, 0, _LVOrderId);
           
            listOrders = LvSelectOrderRepository.GetAll(0, IsShpIn() ? 1 : 0, _depositorId,  _LVOrderId,0);
            if (_isOrderParts)
            {
                //Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.First(o => o.LvOrderId == _LVOrderId);
                ShipmentOrderPartRepository shipmentOrderPartRepository = new ShipmentOrderPartRepository();
                _shipmentOrderParts = shipmentOrderPartRepository.GetShipmentOrderParts(_shipmentOrder.Id);

                var listExclusionID = _shipmentOrderParts.Where(p => p.ShOrderId == _shipmentOrder.Id).Select(p => p.OsLvId).ToList();
                    //shipmentOrder.ShipmentOrderParts.Select(p => (int?)p.OsLvId).ToList();
                result = listOrders.Where(o => !listExclusionID.Contains(o.OstID)).ToList();
            }
            else
            {

                ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository();

                List<ShipmentOrder> shipmentOrders = shipmentOrderRepository.GetShipmentOrders(_shipmentId);

                var listExclusionID = shipmentOrders.Select(o => o.LvOrderId).ToList();
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
                //listOrders = listOrders.Distinct(lVOrderIdComparer).ToList();
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
                if (tblOrders.Rows[tblOrders.CurrentCell.RowIndex].Cells["colLVOrderId"].Value != null)
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
