using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using Planning.DataLayer;

namespace Planning
{
    public partial class ShipmentAdd : Form
    {
        

        DataLayer.Shipment _shipment;
        DataLayer.Movement _movement;
        ShipmentParam _shipmentAddResult;

        private void LockChangeType(bool Lock)
        {
            
            cmbDepositor.Enabled = !Lock;
            cmbType.Enabled = !Lock;
            btnEdit.Enabled = Lock;
                
            
        }
        public ShipmentAdd(ShipmentParam shipmentAddResult)
        {
            InitializeComponent();
            _shipmentAddResult = shipmentAddResult;
        }

        private int? GetSelectedDepositorId()
        { 
            return cmbDepositor.SelectedItem != null ? ((DataLayer.Depositor)cmbDepositor.SelectedItem).Id : null;
        }

        private int? GetSelectedTimeSlotId()
        {
            return cmbTimeSlot.SelectedItem != null ? ((DataLayer.TimeSlot)cmbTimeSlot.SelectedItem).Id : null;
        }

        private void PopulateList()
        {
            DepositorRepository depositorRepository = new DepositorRepository();
            List<DataLayer.Depositor> depositors = depositorRepository.GetAll();

            cmbDepositor.Items.Clear();
            foreach (var d in depositors)
            {
                cmbDepositor.Items.Add(d);
            }
            cmbDepositor.SelectedIndex = 0;
            int? depositorId = GetSelectedDepositorId();

            TimeSlotRepository timeSlotRepository = new TimeSlotRepository();
            List<DataLayer.TimeSlot> timeSlots = timeSlotRepository.GetByDepositorId(depositorId);
            cmbTimeSlot.Items.Clear();
            foreach (var ts in timeSlots)
            {
                cmbTimeSlot.Items.Add(ts);
            }
        }

        private void PopulateOrders()
        {
            int? DepositorLVId = cmbDepositor.SelectedItem !=null?((DataLayer.Depositor)cmbDepositor.SelectedItem).Id:null;
            int? Type = cmbType.SelectedIndex < 2 ? (int?)cmbType.SelectedIndex : null;

            LvSelectOrderRepository lvSelectOrderRepository = new LvSelectOrderRepository();
            List<LvSelectOrder> lvSelectOrders = lvSelectOrderRepository.GetAll(0, Type, DepositorLVId);
            tblOrders.Rows.Clear();
            foreach (var item in lvSelectOrders)
            {
                int Row = tblOrders.Rows.Add();
                tblOrders.Rows[Row].Cells["colId"].Value = item.Id;
                tblOrders.Rows[Row].Cells["colOstCode"].Value = item.OstCode;
                tblOrders.Rows[Row].Cells["colState"].Value = item.LVStatus;
                tblOrders.Rows[Row].Cells["colDate"].Value = item.ExpDate == null ? "" : item.ExpDate.ToString().Substring(0, 10);
                tblOrders.Rows[Row].Cells["colKlient"].Value = item.Company;
                tblOrders.Rows[Row].Cells["colLVOrderId"].Value = item.Id;
                tblOrders.Rows[Row].Cells["colOstId"].Value = item.OstID;
                tblOrders.Rows[Row].Cells["colIsEDM"].Value = item.IsEDM;
            }
 
        }
       
        private void MoveRow(DataGridView TableSource, DataGridView TableTarged)
        {
            if (TableSource.RowCount <= 0) return;

            int CurrentRow = TableSource.CurrentCell.RowIndex;

            int tagetRow = TableTarged.Rows.Add();

            for(int i = 0; i< TableTarged.ColumnCount; i++)
            {
                TableTarged.Rows[tagetRow].Cells[i].Value = TableSource.Rows[CurrentRow].Cells[i].Value;
            }
            
            
              
            TableSource.Rows.Remove(TableSource.CurrentRow);
        }

        private void ClearShipment()
        {
            ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository();
            //ShipmentOrderPartRepository shipmentOrderPartRepository = new ShipmentOrderPartRepository();

            List<DataLayer.ShipmentOrder> shipmentOrders = shipmentOrderRepository.GetShipmentOrders(_shipment.Id);
//            List<DataLayer.ShipmentOrderPart> shipmentOrderParts = shipmentOrderPartRepository.GetShipmentOrderParts(shipmentOrders.Select(o => o.Id).ToList());
            foreach (var order in shipmentOrders)
            {
                order.Delete();
            }

            shipmentOrderRepository.Save(shipmentOrders);
        }
        private void ClearMovement()
        {
            MovementItemRepository movementItemRepository = new MovementItemRepository();
            List<DataLayer.MovementItem> movementItems = movementItemRepository.GetByMovementId(_movement.Id);

            foreach (var item in movementItems)
            {
                item.Delete();
            }

            movementItemRepository.Save(movementItems);
        }
        private void Save()
        {
            /*
            if (tblShipmentItem.RowCount == 0)
            {
                return;
            }
            */
            
            
            if (cmbType.SelectedIndex < 2)
            {
                _shipmentAddResult.IsShipment = true;

                _shipment = new DataLayer.Shipment();
                _shipment.SDate = dtSDate.Value;
                _shipment.ShIn = cmbType.Text == "Вход" ? true : false;
                _shipment.DepositorId = GetSelectedDepositorId();
                _shipment.TimeSlotId = GetSelectedTimeSlotId();
                _shipment.IsAddLv = false;
                //bool isAddLv = false;
                _shipment.TransportViewId = GetTransportViewId(DataService.setting.DefaultTransportViewName);
                _shipment.WarehouseId = GetWarehouseId(DataService.setting.DefaultWarehouseCode);

                ShipmentRepository shipmentRepository = new ShipmentRepository();
                ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository();
                ShipmentOrderPartRepository shipmentOrderPartRepository = new ShipmentOrderPartRepository();

                if (_shipment.Id != 0)
                {
                    ClearShipment();
                }

                if (!shipmentRepository.Save(_shipment))
                {
                    MessageBox.Show($"Ошибка при сохранении отгрузки: {shipmentRepository.LastError}");
                    return;
                }


                List<DataLayer.ShipmentOrder> shipmentOrders = new List<DataLayer.ShipmentOrder>();

                for (int i = 0; i < tblShipmentItem.RowCount; i++)
                {

                   // ShipmentOrder shipmentOrder;

                    var lvOrderId = int.Parse(tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value.ToString());
                    
                    DataLayer.ShipmentOrder shipmentOrder = shipmentOrders.FirstOrDefault(o => o.LvOrderId == lvOrderId);
                    if (shipmentOrder == null)
                    {
                        shipmentOrder = new DataLayer.ShipmentOrder();
                        shipmentOrder.ShipmentId = _shipment.Id;
                        shipmentOrder.OrderId = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                        shipmentOrder.LvOrderId = (int?)tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value;
                        shipmentOrder.LvOrderCode = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                        shipmentOrder.IsEdm =tblShipmentItem.Rows[i].Cells["colItemIsEDM"].Value !=null ?
                                (bool?)tblShipmentItem.Rows[i].Cells["colItemIsEDM"].Value : null;
                        shipmentOrder.IsBinding = true;
                        //isAddLv = true;

                        if (!shipmentOrderRepository.Save(shipmentOrder))
                        {
                            MessageBox.Show($"Ошибка при сохранении заказа: {shipmentOrderRepository.LastError}");
                            return;
                        }


                        shipmentOrders.Add(shipmentOrder);
                    }
                    if (cmbType.SelectedIndex == 0)
                    {

                        List<DataLayer.ShipmentOrderPart> shipmentOrderParts = new List<DataLayer.ShipmentOrderPart>();

                        DataLayer.ShipmentOrderPart shipmentOrderPart = new DataLayer.ShipmentOrderPart();
                        shipmentOrderPart.ShOrderId = shipmentOrder.Id;
                        shipmentOrderPart.OsLvCode = tblShipmentItem.Rows[i].Cells["colItemOstCode"].Value.ToString();
                        shipmentOrderPart.OsLvId = (tblShipmentItem.Rows[i].Cells["colItemOstId"].Value as int?);
                        shipmentOrderPart.IsBinding = true;

                        if (!shipmentOrderPartRepository.Save(shipmentOrderPart))
                        {
                            MessageBox.Show($"Ошибка при сохранении расходной партии заказа: {shipmentOrderPartRepository.LastError}");
                            return;
                        }

                        shipmentOrderParts.Add(shipmentOrderPart);
                    }
                   
                }
                
                _shipmentAddResult.Result = _shipment;
               // _context.Shipments.Add(_shipment);
            }
            else if (cmbType.SelectedIndex ==2)
            {
                _shipmentAddResult.IsShipment = false;
                _movement = _shipmentAddResult.Result!=null?(DataLayer.Movement)_shipmentAddResult.Result: new DataLayer.Movement();
                _movement.MDate = dtSDate.Value;
                _movement.TimeSlotId = GetSelectedTimeSlotId();

                if (_movement.Id != 0)
                {
                    ClearMovement();
                }

                MovementRepository movementRepository = new MovementRepository();
                MovementItemRepository movementItemRepository = new MovementItemRepository();

                if (!movementRepository.Save(_movement))
                {
                    MessageBox.Show($"Ошибка при сохранении перемещения: {movementRepository.LastError}");
                    return;
                }


                for (int i = 0; i < tblShipmentItem.RowCount; i++)
                {
                    DataLayer.MovementItem movementItem = new DataLayer.MovementItem();
                    movementItem.MovementId = _movement.Id;
                    movementItem.DepositorId = GetSelectedDepositorId();
                    movementItem.TklLVID = int.Parse(tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value.ToString());
                    //_movement.MovementItems.Add(movementItem);

                    if (!movementItemRepository.Save(movementItem))
                    {
                        MessageBox.Show($"Ошибка при сохранении позиции перемещения: {movementItemRepository.LastError}");
                        return;
                    }

                }
                _shipmentAddResult.Result = _movement;
                //_context.Movements.Add(_movement);
            }
           // _context.SaveChanges();
            
        }

        private int? GetWarehouseId(string WarehouseCode)
        {

            WarehouseRepository warehouseRepository = new WarehouseRepository();
            DataLayer.Warehouse warehouse = warehouseRepository.GetByCode(WarehouseCode);
            return warehouse == null ? null : (int?)warehouse.Id;
            
        }

        private int? GetTransportViewId(string TransportViewName)
        {

            TransportViewRepository transportViewRepository = new TransportViewRepository();
            DataLayer.TransportView transportView = transportViewRepository.GetByNameOrCreate(TransportViewName);
            return transportView == null? null:(int?)transportView.Id;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShipmentAdd_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            dtSDate.Value = DateTime.Now;
            PopulateList();
            if (cmbDepositor.Items.Count>0)
                cmbDepositor.SelectedIndex = 0;
            PopulateOrders();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "";
            switch (cmbType.SelectedIndex)
            {
                
                case 0:
                    type = "отгрузки";
                    break;
                case 1:
                    type = "поставки";
                    break;
                case 2:
                    type = "перемещения";
                    break;
                default:
                    break;
            }
            this.Text = "Создание " + type;
            PopulateOrders();


        }

        private void btnToShipment_Click(object sender, EventArgs e)
        {
            MoveRow(tblOrders, tblShipmentItem);
            LockChangeType(true);


        }

        private bool SearchBy(bool FromBegin, Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblOrders.CurrentRow.Index + 1;

            for (int i = startRow; i <= tblOrders.Rows.Count - 1; i++)
               if (condition(i))
                {

                    tblOrders.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblOrders.Rows[i].Cells["colId"];
                    tblOrders.CurrentCell = cell;
                    tblOrders.Rows[i].Selected = true;

                    return true;
                }
            return false;

        }

        private void btnFromShipmentAll_Click(object sender, EventArgs e)
        {

            if (tblShipmentItem.RowCount > 0)
            {
                int i = 0;
                while (tblShipmentItem.RowCount>0)
                {
                    tblShipmentItem.Rows[0].Selected = true;
                    MoveRow(tblShipmentItem, tblOrders);
                    i++;
                }

            } 


            LockChangeType(false);
            //LockChangeType(false);
        }

        private void btnFromShipment_Click(object sender, EventArgs e)
        {

            MoveRow(tblShipmentItem, tblOrders);
            if (tblShipmentItem.RowCount == 0)
                LockChangeType(false);
        }

        private void cmbDepositor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tblOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MoveRow(tblOrders, tblShipmentItem);
            LockChangeType(true);
        }

        private void cmbTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchBy(true, r => tblOrders.Rows[r].Cells["colId"] != null && tblOrders.Rows[r].Cells["colId"].Value.ToString() == txtOrderId.Text);
        }

        private void tblOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtOrderId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void ShipmentAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
        }

        private void cmbDepositor_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DataLayer.Depositor)e.ListItem).Name;
        }
    }
}
