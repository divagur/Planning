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
    public partial class Warehouses : DictForm
    {
        public Warehouses()
        {
            InitializeComponent();
        }

        protected override void Populate()
        {
            tblWarehouse.AutoGenerateColumns = false;
            tblWarehouse.DataSource = _context.Warehouses.ToList();
        }
        protected override void AddRow()
        {
            Warehouse warehouse = new Warehouse();
            WarehouseEdit frmWarehouseEdit = new WarehouseEdit(warehouse);
            frmWarehouseEdit.ShowDialog();
            if (frmWarehouseEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.Warehouses.Add(warehouse);

            Save();
        }

        protected override void EditRow()
        {
            if (tblWarehouse.SelectedCells.Count <= 0) return;
            Warehouse warehouse = _context.Warehouses.Find(tblWarehouse.Rows[tblWarehouse.CurrentCell.RowIndex].Cells["colId"].Value);
            WarehouseEdit frmWarehouseEdit = new WarehouseEdit(warehouse);
            frmWarehouseEdit.ShowDialog();
            if (frmWarehouseEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }
        protected override void DelRow()
        {
            Warehouse warehouse = _context.Warehouses.Find(tblWarehouse.Rows[tblWarehouse.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить склад?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _context.Warehouses.Remove(warehouse);
                Save();
            }
        }
    }

    
}
