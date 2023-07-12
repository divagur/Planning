using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class ShipmentOrderEdit : Form
    {
        ShipmentOrder _shipmentOrder;
        Shipment _shipment;
        public ShipmentOrderEdit(Shipment shipment, ShipmentOrder shipmentOrder)
        {
            InitializeComponent();
            _shipmentOrder = shipmentOrder;
            _shipment = shipment;

        }

        private void ShipmentOrderEdit_Load(object sender, EventArgs e)
        {
            txtOrderId.Text = _shipmentOrder.OrderId;
            txtOrderType.Text = _shipmentOrder.OrderType;
            txtOrderComment.Text = _shipmentOrder.Comment;
            /*
            txtManualLoad.Text = _shipmentOrder.ManualLoad.ToString();
            txtManualUnload.Text = _shipmentOrder.ManualUnload.ToString();
            txtPalletAmount.Text = _shipmentOrder.PalletAmount.ToString();
            */
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
            _shipmentOrder.lv_order_code = txtOrderId.Text;
            _shipmentOrder.OrderType = txtOrderType.Text;
            _shipmentOrder.Comment = txtOrderComment.Text;
           /*
            _shipmentOrder.ManualLoad = GetNumber(txtManualLoad);
            _shipmentOrder.ManualUnload = GetNumber(txtManualUnload);
            _shipmentOrder.PalletAmount = GetNumber(txtPalletAmount);
           */
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGetOrder_Click(object sender, EventArgs e)
        {
            ShipmentAddResult selectResult = new ShipmentAddResult();
            ChooseOrder frmChooseOrder = new ChooseOrder(selectResult, _shipment);
            if (frmChooseOrder.ShowDialog() == DialogResult.OK && selectResult.Result != null)
            {
                var order = (LVOrder)selectResult.Result;

                txtOrderId.Text = order.LVCode;
                _shipmentOrder.LVOrderId = order.LVID;
                int? DepositorLVId = _shipment.DepositorId;

                LVOrder_Manager Order_Manager = new LVOrder_Manager();

                var OrderParts = Order_Manager.GetList(DepositorLVId, 0, 0, order.LVID);
                if (OrderParts.Count() == 1)
                {
                    LVOrder lVOrder = OrderParts.FirstOrDefault();
                    ShipmentOrderPart orderPart = new ShipmentOrderPart();
                    orderPart.OsLvId = lVOrder.OstID;
                    orderPart.OsLvCode = lVOrder.OstCode;

                    _shipmentOrder.ShipmentOrderParts.Add(orderPart);
                }
            }
        }
    }
}
