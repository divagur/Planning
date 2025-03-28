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
    public partial class Warehouses : DictForm
    {
        List<DataLayer.Warehouse> _warehouses = new List<DataLayer.Warehouse>();
        DataLayer.WarehouseRepository warehouseRepository = new DataLayer.WarehouseRepository();
        public Warehouses()
        {
            InitializeComponent();
        }

        protected override void Populate()
        {
            tblWarehouse.AutoGenerateColumns = false;
            //repository = new DataLayer.WarehouseRepository();
            _dataSource = warehouseRepository.GetAll().Cast<BaseDataItem>().ToList();
            _warehouses = warehouseRepository.GetAll();
            
            tblWarehouse.DataSource = _warehouses;
            //tblWarehouse.DataSource = _context.Warehouses.ToList();
        }
        protected override void AddRow()
        {
            DataLayer.Warehouse warehouse = new DataLayer.Warehouse();
            WarehouseEdit frmWarehouseEdit = new WarehouseEdit(warehouse);
            frmWarehouseEdit.ShowDialog();
            if (frmWarehouseEdit.DialogResult == DialogResult.Cancel)
                return;
            _warehouses.Add(warehouse);
            warehouseRepository.Save(warehouse);
            UpdateDataSource();
            //DataService.context.Warehouses.Add(warehouse);

            //Save();
        }

        private void UpdateDataSource()
        {
            tblWarehouse.DataSource = null;
            tblWarehouse.DataSource = _warehouses;
            tblWarehouse.Refresh();
        }

        protected override void EditRow()
        {
            if (tblWarehouse.SelectedCells.Count <= 0) return;
            DataLayer.Warehouse warehouse = _warehouses.Find(w=>w.Id == Int32.Parse(tblWarehouse.Rows[tblWarehouse.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
            WarehouseEdit frmWarehouseEdit = new WarehouseEdit(warehouse);
            frmWarehouseEdit.ShowDialog();
            if (frmWarehouseEdit.DialogResult == DialogResult.Cancel)
                return;
            warehouseRepository.Save(warehouse);
            UpdateDataSource();
           // Save();
        }
        protected override void DelRow()
        {
            DataLayer.Warehouse warehouse = _warehouses.Find(w => w.Id == Int32.Parse(tblWarehouse.Rows[tblWarehouse.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
            if (MessageBox.Show("Удалить склад?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                warehouse.Delete();
                _warehouses.Remove(warehouse);
                warehouseRepository.Save(warehouse);
                UpdateDataSource();
            }
        }

        protected override void Save()
        {
            warehouseRepository.Save(_warehouses);
        }
    }

    
}
