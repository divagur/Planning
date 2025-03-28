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
    public partial class CustomPostEdit : DictEditForm
    {
        DataLayer.CustomPost _customPost;
        List<DataLayer.DeliveryPeriod> _deliveryPeriods = new List<DataLayer.DeliveryPeriod>();
        DataLayer.DeliveryPeriodRepository _deliveryPeriodRepository = new DataLayer.DeliveryPeriodRepository();

        //PlanningDbContext _context;
        public CustomPostEdit(DataLayer.CustomPost customPost)
        {
            InitializeComponent();
            _customPost = customPost;
            //_context = DataService.context;
        }
        protected override bool Save()
        {
            if (txtCode.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым кодом", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _customPost.Code = txtCode.Text;
            _customPost.Name = txtName.Text;
            _customPost.Descr = txtDescr.Text;

            RemoveAllDelivery();
            foreach (DataGridViewRow row in tblDelivery.Rows)
            {
                if (row.Cells["colWarehouseId"].Value != null)
                {
                    DeliveryPeriod deliveryPeriod = new DeliveryPeriod();
                    deliveryPeriod.CustomPostId = _customPost.Id;// (int)row.Cells["colCustomPostId"].Value;
                    deliveryPeriod.WarehouseId = (int)row.Cells["colWarehouseId"].Value;
                    deliveryPeriod.DeliveryDay = Int32.Parse(row.Cells["colDeliveryDay"].Value.ToString());
                    //_context.DeliveryPeriods.Add(deliveryPeriod);
                }
     
            }

            return true;
        }
        private void RemoveAllDelivery()
        {
            /*
            foreach (DataGridViewRow row in tblDelivery.Rows)
            {
                _customPost.DeliveryPeriods.Remove(_context.DeliveryPeriods.Find(row.Cells["colId"].Value));
            }
            */
        }
        protected override void Populate()
        {
            txtCode.Text = _customPost.Code;
            txtName.Text = _customPost.Name;
            txtDescr.Text = _customPost.Descr;
            //tblDelivery.DataSource = _customPost.DeliveryPeriods;
            _deliveryPeriods = _deliveryPeriodRepository.GetByCustomPostCode(_customPost.Code);
            tblDelivery.AutoGenerateColumns = false;
            

            DataLayer.WarehouseRepository warehouseRepository = new DataLayer.WarehouseRepository();
            List<DataLayer.Warehouse> warehouses = warehouseRepository.GetAll();
            BindingList<DataLayer.DeliveryPeriod> deliveryPeriodsBinding = new BindingList<DataLayer.DeliveryPeriod>(_deliveryPeriods);
            tblDelivery.DataSource = deliveryPeriodsBinding;
            
            colWarehouse.DataSource = warehouses;
            colWarehouse.DisplayMember = "Name";
            colWarehouse.DataPropertyName = "WarehouseId";
            colWarehouse.ValueMember = "Id";
            
            /*
            foreach (var item in warehouses)
            {
                colWarehouse.Items.Add(item.Name);
            }
            */
            /*
            foreach (var item in _customPost.DeliveryPeriods)
            {
                int rowIdx = tblDelivery.Rows.Add();
                tblDelivery.Rows[rowIdx].Cells["colId"].Value = item.Id;
                tblDelivery.Rows[rowIdx].Cells["colCustomPostId"].Value = item.CustomPostId;
                tblDelivery.Rows[rowIdx].Cells["colWarehouseId"].Value = item.WarehouseId;
                tblDelivery.Rows[rowIdx].Cells["colDeliveryDay"].Value = item.DeliveryDay;
                tblDelivery.Rows[rowIdx].Cells["colWarehouse"].Value = DataService.GetDictNameById("Склады", item.WarehouseId);

            }
            */
        }

        private void UpdateDataSourceDeliveryPeriod()
        {
            tblDelivery.DataSource = null;
            tblDelivery.DataSource = _deliveryPeriods;
            tblDelivery.Refresh();

            /*
            colWarehouse.DataSource = warehouses;
            colWarehouse.DisplayMember = "Name";
            colWarehouse.DataPropertyName = "WarehouseId";
            colWarehouse.ValueMember = "Id";
            */

        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            //tblDelivery.Rows.Add();
            DataLayer.DeliveryPeriod deliveryPeriod = new DataLayer.DeliveryPeriod();
            deliveryPeriod.CustPostId = _customPost.Id;
            deliveryPeriod.DeliveryDay = 1;
            _deliveryPeriods.Add(deliveryPeriod);
            UpdateDataSourceDeliveryPeriod();
            //_customPost.DeliveryPeriods.Add(deliveryPeriod);
            //_context.DeliveryPeriods.Add(deliveryPeriod);

        }

        private void btnDelDelivery_Click(object sender, EventArgs e)
        {
            /*
            foreach (DataGridViewRow row in tblDelivery.SelectedRows)
            {
                if (row.Cells["colId"].Value != null)
                {
                    DeliveryPeriod deliveryPeriod = _customPost.DeliveryPeriods.First(g => g.Id == Int32.Parse(row.Cells["colId"].Value.ToString()));
                    if (deliveryPeriod != null)
                    {
                        _customPost.DeliveryPeriods.Remove(deliveryPeriod);
                        
                    }
                    tblDelivery.Rows.Remove(row);
                }
            } 
            */
        }

        private void tblDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex < 0 || tblDelivery.Columns[e.ColumnIndex].Name != "colWarehouse")
                return;
            string value = (string)tblDelivery.Rows[e.RowIndex].Cells["colWarehouse"].Value;
            var Warehouses = _context.Warehouses.Where(x => x.Name == value).First();
            tblDelivery.Rows[e.RowIndex].Cells["colWarehouseId"].Value = Warehouses.Id;
            */
        }
    }
}
