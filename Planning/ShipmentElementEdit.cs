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

    public partial class ShipmentElementEdit : Form
    {
        ShipmentElement _shipmentElement;
        PlanningDbContext _context;
        public ShipmentElementEdit(ShipmentElement shipmentElement)
        {
            InitializeComponent();
            _shipmentElement = shipmentElement;
            _context = DataService.context;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            _shipmentElement.FieldName = edFieldName.Text;
            _shipmentElement.FieldDbName = edFieldDbName.Text;
            _shipmentElement.FieldType = (int?)cbFieldType.SelectedIndex+1;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShipmentElementEdit_Load(object sender, EventArgs e)
        {
            edFieldName.Text = _shipmentElement.FieldName;
            edFieldDbName.Text = _shipmentElement.FieldDbName;
            cbFieldType.SelectedIndex = _shipmentElement.FieldType==null?-1:(int)_shipmentElement.FieldType - 1;
        }
    }
}
