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
using System.Diagnostics;
using System.Threading;
using Planning.DataLayer;
using Planning.Kernel;

namespace Planning
{
    public partial class ShipmenEdit : Form
    {

        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;

        Shipment _shipment;
        Movement _movement;
        List<ShipmentOrder> _shipmentOrders;
        List<ShipmentOrderPart> _shipmentOrderParts;

        List<DelayReason> delayReasons;
        List<Gateway> gateways;
        List<TimeSlot> timeSlots;
        List<TransportCompany> transportCompanies;
        List<TransportType> transportTypes;
        List<Supplier> suppliers;
        List<Warehouse> warehouses;
        List<TransportView> transportViews;

        ShipmentOrderRepository shipmentOrderRepository;
        ShipmentOrderPartRepository shipmentOrderPartRepository;
        MovementItemRepository movementItemRepository;
        DataSet ds;
        SqlDataAdapter adapter;
        bool getCalendarTime;
        bool IsShipment;
        bool _isNew;
        string _title;
        StringBuilder sbLog = new StringBuilder();
        List<ShipmentOrderPart> shipmentOrderParts = new List<ShipmentOrderPart>();
        int itemId;
        frmShipmentHistory frmShipmentLog = null;
        Dictionary<int?,int?> newOrderId = new Dictionary<int?, int?>();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || (m.Msg == WM_PARENTNOTIFY &&
                (int)m.WParam == WM_LBUTTONDOWN))
                if (!pnGetDateTime.ClientRectangle.Contains(pnGetDateTime.PointToClient(Cursor.Position)) &&
                    (!btnSubmissionTime.ClientRectangle.Contains(btnSubmissionTime.PointToClient(Cursor.Position))))
                    pnGetDateTime.Hide();
            base.WndProc(ref m);
        }

        string IsNull(string Value, string NullValue)
        {
            return (Value == "") ? NullValue : Value;
        }

        private bool IsShpIn()
        {
            return _shipment!=null && (_shipment.ShIn == null || _shipment.ShIn == true);
        }

        public void ClearFields()
        {
            edSDate.Text = "";
            cmbTransportCompany.Text = "";
            cmbSupplier.Text = "";
            cmbWarehouse.Text = "";
            cmbTransportView.Text = "";
            edShipmentComment.Text = "";
            cmbDelayReasons.Text = "";
            edDelayComment.Text = "";
            cbIsCourier.Checked = false;
            /*
            dtSubmissionTimeEx.Value = DateTime.Now;
            dtStartTimeEx.Value = DateTime.Now;
            dtEndDatePlanEx.Value = DateTime.Now;
            dtEndDateFactEx.Value = DateTime.Now;
            */

            edSubmissionTime.Text = "";
            edStartTime.Text = "";
            edEndDate.Text = "";
            edLeaveTime.Text = "";
            edAttorneyDate.Text = "";


            edDriverFIO.Text = "";
            edDriverPhone.Text = "";
            edForwarderFIO.Text = "";
            edVehicleNumber.Text = "";
            edTrailerNumber.Text = "";
            edStamp.Text = "";
            edAttorneyNumber.Text = "";

            //dtAttorneyDateEx.Value = DateTime.Now;
            
            edAttorneyIssued.Text = "";
            cmbGate.Text = "";
            cmbTimeSlot.Text = "";
            
            

        }

        private void LockFieldInner(Control.ControlCollection controls, List<string> filterExclusion, bool IsLock)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                /*
                if (controls[i] is GroupBox )
                    LockFieldInner((controls[i] as GroupBox).Controls, filterExclusion, IsLock);
                else if (controls[i] is TabControl)
                    LockFieldInner((controls[i] as TabControl).Controls, filterExclusion, IsLock);
                */
                if (controls[i].HasChildren )
                {
                    LockFieldInner(controls[i].Controls, filterExclusion, IsLock);
                }
               else if (!((controls[i] is Label) || (controls[i] is GroupBox)))
                    if (!(filterExclusion != null ? filterExclusion.Contains(controls[i].Name) : false))
                        controls[i].Enabled = IsLock;

            }
        }
        public void LockField(List<string> filterExclusion,bool IsLock)
        {
            LockFieldInner(this.Controls, filterExclusion, IsLock);
        }

        public void AddLogItem(string Text)
        {
            sbLog.AppendLine(Text);
        }

        public void ClearLog()
        {
            sbLog.Clear();
        }

        public void SetTilte(string AddTilte)
        {
            Text = AddTilte != ""?_title + " ["+AddTilte+"]":_title;
        }

        private void PopulateComboBoxField<T>(ComboBox comboBox, List<T> items)
            where T:BaseDataItem
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
        }
        private int? GetComboBoxSelectedId(ComboBox comboBox)
            //where T:BaseDataItem
        {
            return comboBox.SelectedItem != null ? ((BaseDataItem)comboBox.SelectedItem).Id : null;
        }
        public void Populate()
        {

            DelayReasonRepository delayReasonRepository = new DelayReasonRepository();
            GatewayRepository gatewayRepository = new GatewayRepository();
            TimeSlotRepository timeSlotRepository = new TimeSlotRepository();
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository();
            TransportTypeRepository transportTypeRepository = new TransportTypeRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            WarehouseRepository warehouseRepository = new WarehouseRepository();
            TransportViewRepository transportViewRepository = new TransportViewRepository();


            List<DelayReason> delayReasons = delayReasonRepository.GetAll();
            List<Gateway> gateways = gatewayRepository.GetAll();
            List<TimeSlot> timeSlots = timeSlotRepository.GetAll().OrderBy(t => t.SlotTime).ToList();
            List<TransportCompany> transportCompanies = transportCompanyRepository.GetAll().Where(t => t.IsActive == true).ToList();
            List<TransportType> transportTypes = transportTypeRepository.GetAll();
            List<Supplier> suppliers = supplierRepository.GetAll().Where(s => s.IsActive == true).ToList();
            List<Warehouse> warehouses = warehouseRepository.GetAll();
            List<TransportView> transportViews = transportViewRepository.GetAll();

            PopulateComboBoxField(cmbDelayReasons, delayReasons);
            PopulateComboBoxField(cmbGate, gateways);
            PopulateComboBoxField(cmbTimeSlot, timeSlots);
            PopulateComboBoxField(cmbTransportCompany, transportCompanies);
            PopulateComboBoxField(cmbTransportType, transportTypes);
            PopulateComboBoxField(cmbSupplier, suppliers);
            PopulateComboBoxField(cmbWarehouse, warehouses);
            PopulateComboBoxField(cmbTransportView, transportViews);

            if (IsShipment)
            {


                edSDate.Text = _shipment.SDate == null ? DateTime.Now.ToShortDateString() : _shipment.SDate.Value.ToShortDateString();
                edShipmentComment.Text = _shipment.SComment;                
                edDelayComment.Text = _shipment.DelayComment;
                cbIsCourier.Checked = _shipment.IsCourier == null ? false : (bool)_shipment.IsCourier;
                cbSpecCondition.Checked = _shipment.SpCondition == null ? false:(bool)_shipment.SpCondition;
                edSubmissionTime.Text = _shipment.SubmissionTime.ToString();
                edStartTime.Text = _shipment.StartTime.ToString();
                edEndDate.Text = _shipment.EndTime.ToString();
                edLeaveTime.Text = _shipment.LeaveTime.ToString();
                edDriverFIO.Text = _shipment.DriverFio;
                edDriverPhone.Text = _shipment.DriverPhone;
                edForwarderFIO.Text = _shipment.ForwarderFio;
                edVehicleNumber.Text = _shipment.VehicleNumber;
                edTrailerNumber.Text = _shipment.TrailerNumber;
                edStamp.Text = _shipment.StampNumber;
                edAttorneyNumber.Text = _shipment.AttorneyNumber;
                edAttorneyDate.Text = _shipment.AttorneyDate.ToString();
                edAttorneyIssued.Text = _shipment.AttorneyIssued;
                cmbTimeSlot.Text = _shipment.TimeSlot == null ? "" : _shipment.TimeSlot.SlotTime.ToString();
                //cbIsCourier.Checked = (bool)_shipment.IsCourier;                
                cmbDelayReasons.SelectedItem = delayReasons.Find(dr=>dr.Id == delayReasonRepository.GetById(_shipment.DelayReasonsId)?.Id);
                cmbGate.SelectedItem = gateways.Find(g => g.Id == gatewayRepository.GetById(_shipment.GateId)?.Id);
                cmbTransportCompany.SelectedItem = transportCompanies.Find(tc => tc.Id == transportCompanyRepository.GetById(_shipment.TransportCompanyId)?.Id);
                cmbTransportType.SelectedItem = transportTypes.Find(tt=>tt.Id == transportTypeRepository.GetById(_shipment.TransportTypeId)?.Id);
                cmbSupplier.SelectedItem = suppliers.Find(s => s.Id == supplierRepository.GetById(_shipment.SupplierId)?.Id);
                cmbWarehouse.SelectedItem = warehouses.Find(w => w.Id == warehouseRepository.GetById(_shipment.WarehouseId)?.Id);
                cmbTransportView.SelectedItem = transportViews.Find(tv=>tv.Id == transportViewRepository.GetById(_shipment.TransportViewId)?.Id);

                _shipmentOrders = shipmentOrderRepository.GetShipmentOrders(_shipment.Id);

                tblShipmentOrders.AutoGenerateColumns = false;
                tblShipmentOrders.DataSource = _shipmentOrders;
                _shipmentOrderParts = new List<DataLayer.ShipmentOrderPart>();
                if (_shipmentOrders.Count > 0)
                {
                    PopulateOrderPart();
                }
                
                DateTime specTime;
                if (DateTime.TryParse(_shipment.SpecialTime.ToString(), out specTime))
                    dtSpecialTime.Value = specTime;

                dtSpecialCond.Visible = cbSpecCondition.Checked;

            }
            else
            {
                edSDate.Text = _movement.MDate==null?DateTime.Now.ToShortDateString(): _movement.MDate.ToShortDateString();
                edShipmentComment.Text = _movement.Comment;
                cmbDelayReasons.SelectedItem = delayReasonRepository.GetById(_shipment.DelayReasonsId);
                edDelayComment.Text = _movement.DelayComment;
                edDriverFIO.Text = _movement.Performer;
                cmbTimeSlot.Text = _movement.TimeSlot == null ? "" : _movement.TimeSlot.SlotTime.ToString();
                //tblShipmentOrders.AutoGenerateColumns = false;
                //tblShipmentOrders.DataSource = _movement.MovementItems.ToList();
                PopulateMovementItem();

                DateTime specTime;
                if (DateTime.TryParse(_movement.SpecialTime.ToString(), out specTime))
                    dtSpecialTime.Value = specTime;

                dtSpecialCond.Visible = cbSpecCondition.Checked;

            }

        }
        
        private bool IsValidDate(TextBox dateControl)
        {
            DateTime date;

            if (dateControl.Text != "" && !DateTime.TryParse(dateControl.Text, out date))
            {
                MessageBox.Show("Не верный формат даты", "Ошибка даты");
                dateControl.Focus();
                return false;
            }
            return true;
        }

        private DateTime? GetNullableDate(TextBox dateControl)
        {
            DateTime date;
            if (dateControl.Text!="" && !DateTime.TryParse(dateControl.Text, out date))
            {
                MessageBox.Show("Не верный формат даты","Ошибка сохранения даты");
                dateControl.Focus();
                return (DateTime?)null;
            }
            return dateControl.Text == ""?(DateTime?)null:Convert.ToDateTime(dateControl.Text);
        }

        private DateTime GetDate(TextBox dateControl)
        {
            DateTime date;
            if (dateControl.Text != "" && !DateTime.TryParse(dateControl.Text, out date))
            {
                MessageBox.Show("Не верный формат даты", "Ошибка сохранения даты");
                dateControl.Focus();
                return DateTime.Now;
            }
            return dateControl.Text == "" ? DateTime.Now : Convert.ToDateTime(dateControl.Text);
        }

        private List<string> GetUnattachedOrderShipment(int? LVOrdId)
        {
            List<string> result = new List<string>();
            SqlProcParam procParam = new SqlProcParam();
            procParam.Add("@DepID", _shipment.DepositorId);
            procParam.Add("@OrdID", LVOrdId);

            SqlProcExecutor sqlProcExecutor = new SqlProcExecutor();
            try
            {
                result = sqlProcExecutor.ProcExecute<string>("SP_PL_GetUnattachedOrderShipment", procParam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
          
            return result;
        }

        private void CheckUnaccountedOrderParts()
        {
            if (_shipment.EndTime == null)
                return;
            StringBuilder sb = new StringBuilder();
            foreach (var order in _shipmentOrders)
            {
                
                var listOrderPartsCode = GetUnattachedOrderShipment(order.LvOrderId);
                if (listOrderPartsCode.Count>0)
                {
                    
                    foreach (var item in listOrderPartsCode)
                    {
                        sb.AppendLine(String.Format("для заказа с кодом [{0}] есть неучтенная отгрузка с кодом [{1}] ", order.LvOrderCode, item));
                    }
                }
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            
            
        }

        bool CopyToShipment()
        {
            if (IsShipment)
            {
                bool success = IsValidDate(edSDate) && IsValidDate(edSubmissionTime) && IsValidDate(edStartTime) && IsValidDate(edEndDate) && IsValidDate(edLeaveTime);
                if (!success)
                    return false;

                _shipment.SDate = GetNullableDate(edSDate);
                _shipment.SComment = edShipmentComment.Text;
                _shipment.DelayReasonsId = GetComboBoxSelectedId(cmbDelayReasons);
                _shipment.TimeSlotId = cbSpecCondition.Checked ? (int?)null : GetComboBoxSelectedId(cmbTimeSlot);
                _shipment.SpecialTime = cbSpecCondition.Checked ? TimeSpan.Parse(dtSpecialCond.Value.ToShortTimeString()):(TimeSpan?)null;
                _shipment.DelayComment = edDelayComment.Text;
                _shipment.IsCourier = cbIsCourier.Checked;
                _shipment.SubmissionTime = GetNullableDate(edSubmissionTime);
                _shipment.StartTime = GetNullableDate(edStartTime);
                _shipment.EndTime = GetNullableDate(edEndDate);
                _shipment.LeaveTime = GetNullableDate(edLeaveTime);
                _shipment.DriverFio = edDriverFIO.Text;
                _shipment.DriverPhone = edDriverPhone.Text;
                _shipment.ForwarderFio = edForwarderFIO.Text;
                _shipment.VehicleNumber = edVehicleNumber.Text;
                _shipment.TrailerNumber = edTrailerNumber.Text;
                _shipment.StampNumber = edStamp.Text;
                _shipment.AttorneyNumber = edAttorneyNumber.Text;
                _shipment.AttorneyDate = GetNullableDate(edAttorneyDate);
                _shipment.AttorneyIssued = edAttorneyIssued.Text;
                _shipment.GateId = GetComboBoxSelectedId(cmbGate); 
                _shipment.TransportCompanyId = GetComboBoxSelectedId(cmbTransportCompany);
                _shipment.TransportTypeId = GetComboBoxSelectedId(cmbTransportType); 
                _shipment.SupplierId = GetComboBoxSelectedId(cmbSupplier); 
                _shipment.WarehouseId = GetComboBoxSelectedId(cmbWarehouse);
                _shipment.TransportViewId= GetComboBoxSelectedId(cmbTransportView);
                _shipment.SpCondition = cbSpecCondition.Checked;
                //_shipment.IsAddLv = IsAllOrderBindToLv();
                // _shipment.TimeSlotId =Convert.ToInt32(IsNull(cmbTimeSlot.Text,null));
                CheckUnaccountedOrderParts();
                return true;
            }
            else
            {               

                bool success = IsValidDate(edSDate);
                if (!success)
                    return false;
                _movement.MDate = GetDate(edSDate);
                _movement.Comment = edShipmentComment.Text;
                _movement.DelayComment = edDelayComment.Text;
                _movement.DelayReasonsId = GetComboBoxSelectedId(cmbDelayReasons);
                _movement.Performer = edDriverFIO.Text;
                _movement.TimeSlotId = cbSpecCondition.Checked ? (int?)null : GetComboBoxSelectedId(cmbTimeSlot); 
                _movement.SpecialTime = cbSpecCondition.Checked ? TimeSpan.Parse(dtSpecialCond.Value.ToShortTimeString()) : (TimeSpan?)null;
                _movement.SpCondition = cbSpecCondition.Checked;
                return true;
            }
        }
        public ShipmenEdit(DataLayer.Shipment shipment, bool isNew = false)
        {
            
            InitializeComponent();

            _shipment = shipment;
            IsShipment = true;
            itemId = (int)shipment.Id;
            gbMovementItem.Visible = false;
            tbObject.TabPages.Remove(tabOrders);
            _isNew = isNew;
             _title = _shipment.ShIn == false? "Редактирование отгрузки": "Редактирование поставки";
            if (!_isNew)
                _title = _title +" ["+ _shipment.Id.ToString()+"]";
            SetTilte("");
            shipmentOrderRepository = new ShipmentOrderRepository();
            shipmentOrderPartRepository = new ShipmentOrderPartRepository();
            //TabOrderView();
            //AddHistory(shipment.Id);

        }

        public void TabOrderView()
        {
            gbOrderParts.Enabled = _shipment.ShIn == false;
            gbOrderParts.Visible = _shipment.ShIn == false;
            tblShipmentOrders.Columns["colManualLoad"].Visible = _shipment.ShIn == true;
            tblShipmentOrders.Columns["colManualUnload"].Visible = _shipment.ShIn == true;
            tblShipmentOrders.Columns["colPalletCount"].Visible = _shipment.ShIn == true;
            tblShipmentOrders.Columns["colBinding"].Visible = _shipment.ShIn == true;
            if (!gbOrderParts.Visible)
            {
                gbOrders.Dock = DockStyle.Fill;
            }
        }

        public ShipmenEdit(Planning.DataLayer.Movement movement, bool isNew = false)
        {
            InitializeComponent();
            _movement = movement;
            IsShipment = false;
            itemId = (int)movement.Id;
            gbOrders.Visible = false;
            btnAddToLV.Visible = false;
            btnBindLV.Visible = false;
            pnShipment.Visible = false;
            _isNew = isNew;
            this.Text = "Редактирование перемещения ";
            if (!_isNew)
                Text = Text + " [" + _movement.Id.ToString() + "]";
            //AddHistory(movement.Id);
            movementItemRepository = new MovementItemRepository();
            tbObject.TabPages.Remove(tabOrders);
        }

        public void AddHistory(int ItemId)
        {

            if (frmShipmentLog != null)
                return;

            frmShipmentLog = new frmShipmentHistory(ItemId, IsShipment);
            frmShipmentLog.Populate();
            frmShipmentLog.TopLevel = false;
            frmShipmentLog.Visible = true;
            frmShipmentLog.FormBorderStyle = FormBorderStyle.None;

            frmShipmentLog.Dock = DockStyle.Fill;

            tbObject.TabPages["tabHistory"].Controls.Add(frmShipmentLog);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CopyToShipment())
            {
                if (IsShipment)
                {
                    ShipmentRepository shipmentRepository = new ShipmentRepository();
                    if (!SaveShipmentItems())
                    {
                        return;
                    }
                    try
                    {
                        shipmentRepository.Save(_shipment);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении:{ex.Message}");
                    }
          

                }
                else
                {
                    MovementRepository movementRepository = new MovementRepository();   
                    try
                    {
                        movementRepository.Save(_movement);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении:{ex.Message}");
                    }
                }
                DialogResult = DialogResult.OK;
            }
                
        }


        private DataLayer.ShipmentOrder GetSelectedShipmentOrder()
        {
            return _shipmentOrders.Find(o => o.Id == Int32.Parse(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
        }
        private void tbtnAdd_Click(object sender, EventArgs e)
        {
            
            ShipmentOrder shipmentOrder = new ShipmentOrder();
            newOrderId.Add(-(newOrderId.Count() + 1), 0);
            shipmentOrder.Id = newOrderId.Last().Key;

            var frmShipmentOrderEdit = new ShipmentOrderEdit(_shipment, shipmentOrder, _shipmentOrderParts);
            shipmentOrder.ShipmentId = _shipment.Id;
            shipmentOrder.IsBinding = false;
            if (frmShipmentOrderEdit.ShowDialog() == DialogResult.OK)
            {

                _shipmentOrders.Add(shipmentOrder);
                tblShipmentOrders.DataSource = _shipmentOrders;
                //PopulateOrderPart();
            }
            UpdateOrderDataSource();
            UpdateOrderPartDataSource();
            //row["shipment_id"] =_shipment.id;
        }

        private void tbtnEdit_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;
            DataLayer.ShipmentOrder shipmentOrder = GetSelectedShipmentOrder();
            var frmShipmentOrderEdit = new ShipmentOrderEdit(_shipment, shipmentOrder, _shipmentOrderParts);
            
            frmShipmentOrderEdit.ShowDialog();
            if (frmShipmentOrderEdit.DialogResult == DialogResult.Cancel)
                return;
            UpdateOrderDataSource();
            tblShipmentOrders.Refresh();
        }

        private void tbtnDel_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;

            if (MessageBox.Show("Удалить заказ?", "Подверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentOrder shipmentOrder = GetSelectedShipmentOrder();
                shipmentOrder.Delete();
                tblShipmentOrders.DataSource = _shipmentOrders;
            }
            UpdateOrderDataSource();
            UpdateOrderPartDataSource();
        }    

        private void cbSpecCondition_CheckedChanged(object sender, EventArgs e)
        {
            dtSpecialCond.Visible = cbSpecCondition.Checked;
            cmbTimeSlot.Visible = !cbSpecCondition.Checked;
        }

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            if (!pnGetDateTime.Visible)
            {
                
                Point pt = pnGetDateTime.Location;
                //pt.Y = gbTransport.Top + ((Button)sender).Location.Y+((Button)sender).Size.Height + 5;
                //pt.X = gbTransport.Left + ((Button)sender).Location.X-pnGetDateTime.Size.Width+((Button)sender).Size.Width;
                pt.Y = ((Button)sender).Parent.Top  + ((Button)sender).Location.Y+((Button)sender).Size.Height + 5;
                pt.X = ((Button)sender).Parent.Left + ((Button)sender).Location.X-pnGetDateTime.Size.Width+((Button)sender).Size.Width;

                pnGetDateTime.Location = pt;
                pnGetDateTime.Tag = sender;
                DateTime dateStart = ((TextBox)((Button)sender).Tag).Text == "" ? DateTime.Now :DateTime.Parse(((TextBox)((Button)sender).Tag).Text);
                monthCalendarSpecial.SetSelectionRange(dateStart,dateStart);
                getCalendarTime = true;
                
                if (((TextBox)(sender as Button).Tag).Equals(edSDate) || ((TextBox)(sender as Button).Tag).Equals(edAttorneyDate))
                    getCalendarTime = false;
                pnGetDateTime.Show();


                
            }
        }

        private void SelectDate()
        {

            Button btn = (Button)pnGetDateTime.Tag;
            ((TextBox)btn.Tag).Text = monthCalendarSpecial.SelectionRange.Start.ToShortDateString()+
            (getCalendarTime == true?" " + dtSpecialTime.Value.ToShortTimeString():"");
            pnGetDateTime.Hide();

        }
        private void btnCalendarCancel_Click(object sender, EventArgs e)
        {
            pnGetDateTime.Hide();
        }

        private void btnCalendarOk_Click(object sender, EventArgs e)
        {

            SelectDate();
        }

        private void ShipmenEdit_Load(object sender, EventArgs e)
        {
            btnSubmissionTime.Tag = edSubmissionTime;
            btnAttorneyDate.Tag = edAttorneyDate;
            btnStartTime.Tag = edStartTime;
            btnEndDate.Tag = edEndDate;
            btnLeaveTime.Tag = edLeaveTime;
            btnSDate.Tag = edSDate;
            if (IsShpIn())
            {
                btnAddToLV.Visible = false;
                
                //btnBindLV.Visible = false;
            }
            TabOrderView();
            AddHistory((int)_shipment.Id);
        }

        private void btnAddToLV_Click(object sender, EventArgs e)
        {

                
            if (Common.AddShipmentToLV(_shipment.Id))
            {
                _shipment.IsAddLv = true;
                MessageBox.Show("Отгрузка создана в Lvision");
            }
            
        }

        private bool BindOrderToLV()
        {

            SqlProcExecutor sqlProcExecutor = new SqlProcExecutor();

            SqlProcParam sqlProcParams = new SqlProcParam();
            sqlProcParams.Add("@ShpID", _shipment.Id);
            try
            {
                sqlProcExecutor.ProcExecute("SP_PL_BindAllOrders", sqlProcParams);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при связывании заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool SaveShipmentItems()
        {
            int? orderId = 0;
            foreach (var order in _shipmentOrders)
            {
                int? addOrderId = order.Id;
                bool saveIdtoDict = false;
                if (order.Id < 0)
                {
                    if (newOrderId.TryGetValue(order.Id, out orderId))
                    {
                        addOrderId = order.Id;
                        saveIdtoDict = true;
                    }
                }
                if (!shipmentOrderRepository.Save(order))
                {
                    MessageBox.Show("Ошибка при сохранении заказов: " + shipmentOrderRepository.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (saveIdtoDict)
                {
                    newOrderId[addOrderId] = order.Id;
                }

                foreach (var orderPart in _shipmentOrderParts.Where(op=>op.ShOrderId == addOrderId))
                {
                    orderPart.ShOrderId = order.Id;
                    if (!shipmentOrderPartRepository.Save(orderPart))
                    {
                        MessageBox.Show("Ошибка при сохранении расходных партий: " + shipmentOrderPartRepository.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            /*
            if (!shipmentOrderPartRepository.Save(_shipmentOrderParts))
            {
                MessageBox.Show("Ошибка при сохранении расходных партий: " + shipmentOrderPartRepository.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!shipmentOrderRepository.Save(_shipmentOrders))
            {
                MessageBox.Show("Ошибка при сохранении заказов: " + shipmentOrderRepository.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/

            return true;
        }

        private void btnBindLV_Click(object sender, EventArgs e)
        {
            if (!SaveShipmentItems())
            {
                return;
            }

            if (BindOrderToLV())
            {
               
                bool isAllBindings = true;
               
                //var listOrdId = _shipmentOrders.Select(o => (int?)o.Id).ToList();
                _shipmentOrders = shipmentOrderRepository.GetShipmentOrders(_shipment.Id);
                tblShipmentOrders.DataSource = _shipmentOrders;
                PopulateOrderPart();
                foreach (var part in _shipmentOrderParts)
                {
                    if (part.IsBinding == null || part.IsBinding == false)
                    {
                        var shipmentOrder = _shipmentOrders.Find(o => o.Id == part.ShOrderId);
                        MessageBox.Show($"Расходная партия [{part.OsLvId}] заказа [{shipmentOrder.OrderId}] не найдена в Lvision]");
                        isAllBindings = false;
                    }
                }

                foreach (var shipmentOrder in _shipmentOrders)
                {
                    List<ShipmentOrderPart> shipmentOrderPartsTemp = shipmentOrderPartRepository.GetShipmentOrderParts(shipmentOrder.Id);
                    foreach (var part in shipmentOrderPartsTemp)
                    {
                        if (part.IsBinding == null || part.IsBinding == false)
                        {
                            MessageBox.Show($"Расходная партия [{part.OsLvId}] заказа [{shipmentOrder.OrderId}] не найдена в Lvision]");
                            isAllBindings = false;
                        }
                    }

                }
                /*
                foreach (var part in _shipmentOrderParts)
                {
                    if (part.IsBinding == null || part.IsBinding == false)
                    {
                        Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.Find(o => o.Id == part.ShOrderId);
                        MessageBox.Show($"Расходная партия [{part.OsLvId}] заказа [{shipmentOrder.OrderId}] не найдена в Lvision]");
                        isAllBindings = false;
                    }
                }
           
               
               
                if (tblShipmentOrders.SelectedCells != null)
                    PopulateOrderPart();
    */
                if (isAllBindings)
                    MessageBox.Show(IsShpIn()? "Все заказы привязаны к отгрузке":"Все расходные партии привязаны к отгрузке");

            }
        }


        private void PopulateMovementItem()
        {
            tblMovementItem.AutoGenerateColumns = false;

            LvMovementItemRepository lvMovementItemRepository = new LvMovementItemRepository();
            List<LvMovementItem> lvMovementItems  = lvMovementItemRepository.GetAll();

            tblMovementItem.DataSource = lvMovementItems;

            
        }

        private void tbtnMoveItemEdit_Click(object sender, EventArgs e)
        {
            ShipmentParam shipmentAddResult = new ShipmentParam();
            shipmentAddResult.IsShipment = false;
            shipmentAddResult.Result = _movement;
            ShipmentAdd frmShipmentAdd = new ShipmentAdd(shipmentAddResult);
            if (frmShipmentAdd.ShowDialog() == DialogResult.OK)
            {
                PopulateMovementItem();
            }

        }

        private void UpdateOrderDataSource()
        {
            tblShipmentOrders.AutoGenerateColumns = false;
            tblShipmentOrders.DataSource = null;
            tblShipmentOrders.DataSource = _shipmentOrders;
            tblShipmentOrders.Refresh();
        }
        private void UpdateOrderPartDataSource()
        {
            tblOrderParts.AutoGenerateColumns = false;
            tblOrderParts.DataSource = null;
            tblOrderParts.DataSource = _shipmentOrderParts;
            tblOrderParts.Refresh();
        }
        private void PopulateOrderPart()
        {
            _shipmentOrderParts.Clear();

            foreach (var order in _shipmentOrders)
            {
                _shipmentOrderParts.AddRange(shipmentOrderPartRepository.GetShipmentOrderParts(order.Id));
            }

            UpdateOrderPartDataSource();
        }

        private void tblShipmentOrders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (isSelectAction || tblShipmentOrders.CurrentCell == null)
                return;
            isSelectAction = true;
            SelectOrderPart((int)tblShipmentOrders.Rows[e.RowIndex].Cells["colId"].Value);
            isSelectAction = false;
        }

        private void tbtnAddOrderPart_Click(object sender, EventArgs e)
        {

            if (tblShipmentOrders.CurrentCell == null)
                return;
            string ordId = tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
            if (String.IsNullOrEmpty(ordId) || ordId == "0")
                return;

            ShipmentOrder shipmentOrder = _shipmentOrders.FirstOrDefault(o=> o.Id == Int32.Parse(ordId));


            ShipmentOrderPart shipmentOrderPart = new ShipmentOrderPart();
            shipmentOrderPart.ShOrderId = shipmentOrder.Id;
            var frmShipmentOrderPart = new ShipmentOrderPartEdit(_shipment, shipmentOrder, shipmentOrderPart);
           
            shipmentOrderPart.IsBinding = false;
            if (frmShipmentOrderPart.ShowDialog() == DialogResult.OK)
            {

                _shipmentOrderParts.Add(shipmentOrderPart);
                UpdateOrderPartDataSource();
                //PopulateOrderPart();
            }
        }

        private void tbtnEditOrderPart_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;
            Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.Find(o=>o.Id == int.Parse(tblShipmentOrders.Rows[tblShipmentOrders.SelectedRows[0].Index].Cells["colId"].Value.ToString()));

            if (tblOrderParts.CurrentCell == null)
                return;

            if (tblOrderParts.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выберите строку для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //
            DataLayer.ShipmentOrderPart shipmentOrderPart = _shipmentOrderParts.Find(o => o.Id == int.Parse(tblOrderParts.Rows[tblOrderParts.CurrentCell.RowIndex].Cells["colPartsId"].Value.ToString())); 

            var frmShipmentOrderPart = new ShipmentOrderPartEdit(_shipment,shipmentOrder, shipmentOrderPart);
            frmShipmentOrderPart.ShowDialog();
            if (frmShipmentOrderPart.DialogResult == DialogResult.Cancel)
                return;
            tblOrderParts.Refresh();
        }

        private void SelectOrder(int? OrderId)
        {

            tblShipmentOrders.ClearSelection();
            for (int i = 0; i < tblShipmentOrders.RowCount; i++)
            {
                if ((int?)(tblShipmentOrders.Rows[i].Cells["colId"].Value)==OrderId)
                {

                    tblShipmentOrders.Rows[i].Selected = true;
                    tblShipmentOrders.Rows[i].Cells[0].Selected = true;
                    tblShipmentOrders.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
            }

        }
        bool isSelectAction = false;
        private void SelectOrderPart(int? OrderId)
        {
            tblOrderParts.ClearSelection();
            int srollRowIdx = -1;
            for (int i = 0; i < tblOrderParts.RowCount; i++)
            {
                if ((int?)(tblOrderParts.Rows[i].Cells["colPartsOrderCode"].Value) == OrderId)
                {
                    tblOrderParts.Rows[i].Selected = true;
                    tblOrderParts.Rows[i].Cells[0].Selected = true;
                    if (srollRowIdx < 0)
                        srollRowIdx = i;
                    //return;
                }
            }
            if (srollRowIdx >= 0)
                tblOrderParts.FirstDisplayedScrollingRowIndex = srollRowIdx;
        }
        private void tbtnDelOrderPart_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;
            ShipmentOrder shipmentOrder = _shipmentOrders.Find(o => o.Id == int.Parse(tblShipmentOrders.Rows[tblShipmentOrders.SelectedRows[0].Index].Cells["colId"].Value.ToString()));

            if (tblOrderParts.CurrentCell == null)
                return;

            if (tblOrderParts.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выберите строку для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить расходную партию?", "Подверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentOrderPart shipmentOrderPart = _shipmentOrderParts.Find(o=>o.Id == int.Parse(tblOrderParts.Rows[tblOrderParts.CurrentCell.RowIndex].Cells["colPartsId"].Value.ToString()));
                shipmentOrderPart.Delete();
                _shipmentOrderParts.Remove(shipmentOrderPart);
                //PopulateOrderPart();
                UpdateOrderPartDataSource();
            }
        }

        private void tblOrderParts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (isSelectAction || tblShipmentOrders.CurrentCell == null)
                return;
            isSelectAction = true;
            SelectOrder((int)tblOrderParts.Rows[e.RowIndex].Cells["colPartsOrderCode"].Value);
            isSelectAction = false;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sbLog.ToString());
            frmLog frmLog = new frmLog();
            frmLog.SetText(sbLog.ToString());
            frmLog.ShowDialog();


        }

        private void tblShipmentOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (isSelectAction || tblShipmentOrders.CurrentCell == null || tblShipmentOrders.Rows.Count == 0)
                return;
            isSelectAction = true;
            SelectOrderPart((int)tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);
            isSelectAction = false;
        }

        private void tblOrderParts_SelectionChanged(object sender, EventArgs e)
        {

            if (tblShipmentOrders.CurrentCell == null || tblOrderParts.Rows.Count == 0)
                return;

            SelectOrder((int)tblOrderParts.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colPartsOrderCode"].Value);
        }

        private void tbObject_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name =="tabHistory")
            {
                AddHistory(itemId);
            }
        }

        private void cmbSupplier_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DataLayer.Supplier)e.ListItem).Name;
        }

        private void cmbTransportCompany_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DataLayer.TransportCompany)e.ListItem).Name;
        }

        private void cmbWarehouse_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DataLayer.Warehouse)e.ListItem).Name;
        }

        private void cmbTransportView_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DataLayer.TransportView)e.ListItem).Name;
        }

        private void cmbDelayReasons_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((DelayReason)e.ListItem).Name;
        }

        private void cmbTransportType_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((TransportType)e.ListItem).Name;

        }

        private void cmbGate_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((Gateway)e.ListItem).Name;
        }

        private void cmbTimeSlot_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((TimeSlot)e.ListItem).SlotTime.ToString();
        }
    }




}
