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
        public ShipmentOrderEdit(ShipmentOrder shipmentOrder)
        {
            InitializeComponent();
            _shipmentOrder = shipmentOrder;

        }

        private void ShipmentOrderEdit_Load(object sender, EventArgs e)
        {
            txtOrderId.Text = _shipmentOrder.OrderId;
            txtOrderType.Text = _shipmentOrder.OrderType;
            txtOrderComment.Text = _shipmentOrder.Comment;
            txtManualLoad.Text = _shipmentOrder.ManualLoad.ToString();
            txtManualUnload.Text = _shipmentOrder.ManualUnload.ToString();
            txtPalletAmount.Text = _shipmentOrder.PalletAmount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CopyToShipmentOrder();
        }

        private void CopyToShipmentOrder()
        {
            _shipmentOrder.OrderId = txtOrderId.Text;
            _shipmentOrder.OrderType = txtOrderType.Text;
            _shipmentOrder.Comment = txtOrderComment.Text;
            _shipmentOrder.ManualLoad = Convert.ToInt16(txtManualLoad.Text);
            _shipmentOrder.ManualUnload = Convert.ToInt16(txtManualUnload.Text);
            _shipmentOrder.PalletAmount = Convert.ToInt16(txtPalletAmount.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
