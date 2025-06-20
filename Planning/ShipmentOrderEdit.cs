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
    public partial class ShipmentOrderEdit : Form
    {
        ShipmentOrder _shipmentOrder;
        List<ShipmentOrderPart> _shipmentOrderParts;
        Shipment _shipment;
        public ShipmentOrderEdit(Shipment shipment, ShipmentOrder shipmentOrder,
            List<ShipmentOrderPart> shipmentOrderParts)
        {
            InitializeComponent();
            _shipmentOrder = shipmentOrder;
            _shipmentOrderParts = shipmentOrderParts;
            _shipment = shipment;
            SetViewParam();
        }


        private bool IsShpIn()
        {
            return _shipment != null && (_shipment.ShIn == null || _shipment.ShIn == true);
        }


        public void SetViewParam()
        {
            
            if (_shipment.ShIn == true)
            {
                grpShInParam.Visible =  true;
                this.Height = 316;
                btnClose.Top = 246;
                btnSave.Top = 246;
            }
            else
            {
                grpShInParam.Visible = false;
                this.Height = 217;
                btnClose.Top = 146;
                btnSave.Top = 146;
            }
        }

        private void ShipmentOrderEdit_Load(object sender, EventArgs e)
        {
            txtOrderId.Text = _shipmentOrder.OrderId;
            txtOrderType.Text = _shipmentOrder.OrderType;
            txtOrderComment.Text = _shipmentOrder.Comment;
            
            txtManualLoad.Text = _shipmentOrder.ManualLoad.ToString();
            txtManualUnload.Text = _shipmentOrder.ManualUnload.ToString();
            txtPalletAmount.Text = _shipmentOrder.PalletAmount.ToString();
            cbIsEDM.Checked = _shipmentOrder.IsEdm == null ? false : (bool)_shipmentOrder.IsEdm;
            bool isEnable = _shipmentOrder.IsBinding == null ? false : !(bool)_shipmentOrder.IsBinding;
            txtOrderId.Enabled = isEnable;
            btnGetOrder.Enabled = isEnable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CopyToShipmentOrder();
        }

        private int? GetNumber(TextBox dateControl)
        {
            int value;
            if (dateControl.Text != "" && !Int32.TryParse(dateControl.Text, out value))
            {
                MessageBox.Show("Не верный формат числа", "Ошибка сохранения числового значения", MessageBoxButtons.OK,MessageBoxIcon.Error);
                dateControl.Focus();
                return (int?)null;
            }
            return dateControl.Text == "" ? (int?)null : Convert.ToInt32(dateControl.Text);
        }

        private void CopyToShipmentOrder()
        {
            _shipmentOrder.OrderId = txtOrderId.Text;
            _shipmentOrder.LvOrderCode = txtOrderId.Text;
            _shipmentOrder.OrderType = txtOrderType.Text;
            _shipmentOrder.Comment = txtOrderComment.Text;
            _shipmentOrder.IsEdm = cbIsEDM.Checked;
            _shipmentOrder.ManualLoad = GetNumber(txtManualLoad);
            _shipmentOrder.ManualUnload = GetNumber(txtManualUnload);
            _shipmentOrder.PalletAmount = GetNumber(txtPalletAmount);
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGetOrder_Click(object sender, EventArgs e)
        {
            ShipmentAddResult selectResult = new ShipmentAddResult();
            ChooseOrder frmChooseOrder = new ChooseOrder(selectResult, _shipment.Id, _shipment.DepositorId,_shipment.ShIn,_shipmentOrder);
            if (frmChooseOrder.ShowDialog() == DialogResult.OK && selectResult.Result != null)
            {
                var order = (LvSelectOrder)selectResult.Result;

                txtOrderId.Text = order.LVCode;
                cbIsEDM.Checked = (bool)order.IsEDM;
                _shipmentOrder.LvOrderId = order.Id;
                int? DepositorLVId = _shipment.DepositorId;
                _shipmentOrder.IsBinding = true;
                LvSelectOrderRepository lvSelectOrderRepository = new LvSelectOrderRepository();
                List<LvSelectOrder> OrderParts = lvSelectOrderRepository.GetAll(0,0,DepositorLVId, order.Id,0);
                
                if (OrderParts.Count() == 1)
                {
                    LvSelectOrder lVOrder = OrderParts.FirstOrDefault();
                    ShipmentOrderPart orderPart = new ShipmentOrderPart();                    
                    orderPart.OsLvId = lVOrder.OstID;
                    orderPart.OsLvCode = lVOrder.OstCode;
                    orderPart.ShOrderId = _shipmentOrder.Id;
                    orderPart.IsBinding = true;
                    _shipmentOrderParts.Add(orderPart);
                }
            }
        }
    }
}
