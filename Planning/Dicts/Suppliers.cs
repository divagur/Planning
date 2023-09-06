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
    public partial class Suppliers : DictForm
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        protected override void Populate()
        {
            tblSuppliers.AutoGenerateColumns = false;
            tblSuppliers.DataSource = _context.Suppliers.ToList();

        }
        protected override void AddRow()
        {
            Supplier supplier = new Supplier();
            SupplierEdit frmSupplierEdit = new SupplierEdit(supplier);
            frmSupplierEdit.ShowDialog();
            if (frmSupplierEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.Suppliers.Add(supplier);

            Save();
        }

        protected override void EditRow()
        {
            if (tblSuppliers.SelectedCells.Count <= 0) return;
            Supplier supplier = _context.Suppliers.Find(tblSuppliers.Rows[tblSuppliers.CurrentCell.RowIndex].Cells["colId"].Value);
            SupplierEdit frmSupplierEdit = new SupplierEdit(supplier);
            frmSupplierEdit.ShowDialog();
            if (frmSupplierEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            Supplier supplier = _context.Suppliers.Find(tblSuppliers.Rows[tblSuppliers.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить поставщика?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _context.Suppliers.Remove(supplier);
                Save();
            }
        }
    }
}
