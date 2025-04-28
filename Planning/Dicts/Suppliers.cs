using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class Suppliers : DictFormEx<DataLayer.Supplier, DataLayer.SupplierRepository>
    {

        public Suppliers()
        {
            InitializeComponent();
            GridView = tblSuppliers;
        }

        protected override bool CreateEditForm(DataLayer.Supplier item)
        {
            SupplierEdit frmSupplierEdit = new SupplierEdit(item);
            frmSupplierEdit.ShowDialog();
            return !(frmSupplierEdit.DialogResult == DialogResult.Cancel);
        }
        
    }
}
