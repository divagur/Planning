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
using Planning.Kernel;
namespace Planning
{
    public partial class Warehouses : DictFormEx<DataLayer.Warehouse, DataLayer.WarehouseRepository>
    {
        public Warehouses()
        {
            InitializeComponent();
            GridView = tblWarehouse;
        }

        protected override bool CreateEditForm(DataLayer.Warehouse item)
        {
            WarehouseEdit frmWarehouseEdit = new WarehouseEdit(item);
            frmWarehouseEdit.ShowDialog();
            return !(frmWarehouseEdit.DialogResult == DialogResult.Cancel);
                
        }

    }

    
}
