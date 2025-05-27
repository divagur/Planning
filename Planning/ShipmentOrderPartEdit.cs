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
    public partial class ShipmentOrderPartEdit : Form
    {
       DataLayer.ShipmentOrderPart _shipmentOrderPart;
       DataLayer.ShipmentOrder _shipmentOrder;
       DataLayer.Shipment _shipment;
        public ShipmentOrderPartEdit(DataLayer.Shipment shipment, DataLayer.ShipmentOrder shipmentOrder, DataLayer.ShipmentOrderPart shipmentOrderPart)
        {
            InitializeComponent();
            _shipmentOrderPart = shipmentOrderPart;
            _shipmentOrder = shipmentOrder;
            _shipment = shipment;
        }

        private int? GetNumber(TextBox dateControl)
        {
            int value;
            if (dateControl.Text != "" && !Int32.TryParse(dateControl.Text, out value))
            {
                MessageBox.Show("Не верный формат числа", "Ошибка сохранения числового значения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateControl.Focus();
                return (int?)null;
            }
            return dateControl.Text == "" ? (int?)null : Convert.ToInt32(dateControl.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void CopyToShipmentOrderPart()
        {
            
            _shipmentOrderPart.OsLvCode = edOrderPartId.Text;

            
             _shipmentOrderPart.ManualLoad = GetNumber(txtManualLoad);
             _shipmentOrderPart.ManualUnload = GetNumber(txtManualUnload);
             _shipmentOrderPart.PalletAmount = GetNumber(txtPalletAmount);
            
        }
        private void ShipmentOrderPartsEdit_Load(object sender, EventArgs e)
        {
            edOrderId.Text = _shipmentOrder.LvOrderCode;
            edOrderPartId.Text = _shipmentOrderPart.OsLvCode;
           txtManualLoad.Text = _shipmentOrderPart.ManualLoad.ToString();
           txtManualUnload.Text = _shipmentOrderPart.ManualUnload.ToString();
           txtPalletAmount.Text = _shipmentOrderPart.PalletAmount.ToString();
            bool isEnable = _shipmentOrderPart.IsBinding == null ? false : !(bool)_shipmentOrderPart.IsBinding;
            edOrderPartId.Enabled = isEnable;
            btnGetOrderParts.Enabled = isEnable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CopyToShipmentOrderPart();
        }

        private void btnGetOrderParts_Click(object sender, EventArgs e)
        {
            ShipmentAddResult selectResult = new ShipmentAddResult();
            ChooseOrder frmChooseOrder = new ChooseOrder(selectResult, _shipment.Id,
                _shipment.DepositorId, _shipment.ShIn, _shipmentOrder, true, _shipmentOrder.LvOrderId);
            if (frmChooseOrder.ShowDialog() == DialogResult.OK && selectResult.Result != null)
            {
                var order = (LVOrder)selectResult.Result;
                edOrderPartId.Text = order.OstCode;
                _shipmentOrderPart.OsLvId = order.OstID;
                _shipmentOrderPart.IsBinding = true;
            }
        }
    }
}
