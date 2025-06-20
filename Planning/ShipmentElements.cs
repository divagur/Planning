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
   
    public partial class ShipmentElements : DictFormEx<DataLayer.ShipmentElement, DataLayer.ShipmentElementRepository>
    {
        List<DataLayer.ShipmentElement> _shipmentElements;
        DataLayer.ShipmentElementRepository _shipmentElementRepository = new DataLayer.ShipmentElementRepository();
        public ShipmentElements()
        {
            InitializeComponent();
            GridView = tblElements;
        }

        protected override bool CreateEditForm(DataLayer.ShipmentElement item)
        {
            var frmShipmentElementEdit = new ShipmentElementEdit(item);

            frmShipmentElementEdit.ShowDialog();
            return !(frmShipmentElementEdit.DialogResult == DialogResult.Cancel);
        }
        

       
    }



}
