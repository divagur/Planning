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

            txtOrderId.Enabled = !(bool)_shipmentOrder.IsBinding;
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
            _shipmentOrder.ManualLoad = GetNumber(txtManualLoad);
            _shipmentOrder.ManualUnload = GetNumber(txtManualUnload);
            _shipmentOrder.PalletAmount = GetNumber(txtPalletAmount);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
