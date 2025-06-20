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
    public partial class CustomPostEdit : DictEditForm
    {
        DataLayer.CustomPost _customPost;
       
        DataLayer.DeliveryPeriodRepository _deliveryPeriodRepository = new DataLayer.DeliveryPeriodRepository();
        List<DataLayer.Warehouse> _warehouses;
        public CustomPostEdit(DataLayer.CustomPost customPost)
        {
            InitializeComponent();
            _customPost = customPost;
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

            CustomPostRepository customPostRepository = new CustomPostRepository();
            customPostRepository.Save(_customPost);
            RemoveAllDelivery();
            List<DataLayer.DeliveryPeriod> _deliveryPeriods = new List<DataLayer.DeliveryPeriod>();
            foreach (DataGridViewRow row in tblDelivery.Rows)
            {
                if (row.Cells["colWarehouseId"].Value != null)
                {
                    DataLayer.DeliveryPeriod deliveryPeriod = new DataLayer.DeliveryPeriod();
                    deliveryPeriod.CustPostId = _customPost.Id;// (int)row.Cells["colCustomPostId"].Value;
                    deliveryPeriod.WarehouseId = (int)row.Cells["colWarehouseId"].Value;
                    deliveryPeriod.DeliveryDay = Int32.Parse(row.Cells["colDeliveryDay"].Value.ToString());
                    _deliveryPeriods.Add(deliveryPeriod);
                }
     
            }
            _deliveryPeriodRepository.Save(_deliveryPeriods);

            return true;
        }
        private void RemoveAllDelivery()
        {
            
            List<DataLayer.DeliveryPeriod> _deliveryPeriods = new List<DataLayer.DeliveryPeriod>();
            _deliveryPeriods = _deliveryPeriodRepository.GetByCustomPostCode(_customPost.Code);

            foreach (var item in _deliveryPeriods)
            {
                item.Delete();
            }
            _deliveryPeriodRepository.Save(_deliveryPeriods);

        }
        protected override void Populate()
        {
            txtCode.Text = _customPost.Code;
            txtName.Text = _customPost.Name;
            txtDescr.Text = _customPost.Descr;
            //tblDelivery.DataSource = _customPost.DeliveryPeriods;
            
            tblDelivery.AutoGenerateColumns = false;
            

            DataLayer.WarehouseRepository warehouseRepository = new DataLayer.WarehouseRepository();
            _warehouses = warehouseRepository.GetAll();
            
            /*
            BindingList<DataLayer.DeliveryPeriod> deliveryPeriodsBinding = new BindingList<DataLayer.DeliveryPeriod>(_deliveryPeriods);
            tblDelivery.DataSource = deliveryPeriodsBinding;
            
            colWarehouse.DataSource = warehouses;
            colWarehouse.DisplayMember = "Name";
            colWarehouse.DataPropertyName = "WarehouseId";
            colWarehouse.ValueMember = "Id";
            */
            
            foreach (var item in _warehouses)
            {
                colWarehouse.Items.Add(item.Name);
            }
            List<DataLayer.DeliveryPeriod> _deliveryPeriods = new List<DataLayer.DeliveryPeriod>();
            _deliveryPeriods = _deliveryPeriodRepository.GetByCustomPostCode(_customPost.Code);

            foreach (var item in _deliveryPeriods)
            {
                int rowIdx = tblDelivery.Rows.Add();
                tblDelivery.Rows[rowIdx].Cells["colId"].Value = item.Id;
                tblDelivery.Rows[rowIdx].Cells["colCustomPostId"].Value = item.CustPostId;
                tblDelivery.Rows[rowIdx].Cells["colWarehouseId"].Value = item.WarehouseId;
                tblDelivery.Rows[rowIdx].Cells["colDeliveryDay"].Value = item.DeliveryDay;
                var warehouse =  _warehouses.FirstOrDefault(w=>w.Id == item.WarehouseId);
                tblDelivery.Rows[rowIdx].Cells["colWarehouse"].Value = warehouse == null ? "" : warehouse.Name;

            }
            
        }

        private void UpdateDataSourceDeliveryPeriod()
        {
            /*
            tblDelivery.DataSource = null;
            tblDelivery.DataSource = _deliveryPeriods;
            tblDelivery.Refresh();
            */
        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            tblDelivery.Rows.Add();
        }

        private void btnDelDelivery_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in tblDelivery.SelectedRows)
            {
                if (row.Cells["colId"].Value != null)
                {
                    tblDelivery.Rows.Remove(row);
                }
            } 
            
        }

        private void tblDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //|| tblDelivery.Columns[e.ColumnIndex].Name != "colWarehouse"
            if (e.RowIndex < 0 || tblDelivery.Columns[e.ColumnIndex].Name != "colWarehouse")
                return;
            string value = (string)tblDelivery.Rows[e.RowIndex].Cells["colWarehouse"].Value;
            var Warehouses = _warehouses.Where(x => x.Name == value).First();
            tblDelivery.Rows[e.RowIndex].Cells["colWarehouseId"].Value = Warehouses.Id;

            /*
             DataLayer.DeliveryPeriod deliveryPeriod = _deliveryPeriods.Find(dp => dp.Id == Int32.Parse(tblDelivery.Rows[e.RowIndex].Cells["colId"].Value.ToString()));
             if (deliveryPeriod == null)
                 return;
            if (tblDelivery.Columns[e.ColumnIndex].Name == "colWarehouse")
            {
                string value = (string)tblDelivery.Rows[e.RowIndex].Cells["colWarehouse"].Value;
                var Warehouses = _warehouses.Where(x => x.Name == value).First();
                tblDelivery.Rows[e.RowIndex].Cells["colWarehouseId"].Value = Warehouses.Id;
                deliveryPeriod.WarehouseId = Warehouses.Id;
            }
            else if (tblDelivery.Columns[e.ColumnIndex].Name == "colDeliveryDay")
            {
                string deliveryDayStr = tblDelivery.Rows[e.RowIndex].Cells["colDeliveryDay"].Value.ToString();
                int deliveryDay = String.IsNullOrEmpty(deliveryDayStr)?0:Int32.Parse(deliveryDayStr);

                deliveryPeriod.DeliveryDay = Int32.Parse(tblDelivery.Rows[e.RowIndex].Cells["colDeliveryDay"].Value.ToString());
            }
            */
        }
    }
}
