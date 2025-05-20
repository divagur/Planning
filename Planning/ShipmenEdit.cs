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

namespace Planning
{
    public partial class ShipmenEdit : Form
    {

        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;

        Planning.DataLayer.Shipment _shipment;
        Planning.DataLayer.Movement _movement;
        List<Planning.DataLayer.ShipmentOrder> _shipmentOrders;
        List<Planning.DataLayer.ShipmentOrderPart> _shipmentOrderParts;
        PlanningDbContext _context;
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
            /*
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (!((this.Controls[i] is Label) || (this.Controls[i] is GroupBox)))
                    if (!(filterExclusion != null ? filterExclusion.Contains(this.Controls[i].Name) : false))
                        this.Controls[i].Enabled = IsLock;
            
             
            }*/
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

        private void PopulateComboBoxField(ComboBox comboBox, List<string> items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
        }

        public void Populate()
        {


            PopulateComboBoxField(cmbDelayReasons, _context.DelayReasons.Select(l=>l.Name).ToList());
            PopulateComboBoxField(cmbGate, _context.Gateways.Select(l => l.Name.ToString()).ToList());
            PopulateComboBoxField(cmbTimeSlot, _context.TimeSlots.OrderBy(t => t.SlotTime).Select(l => l.SlotTime.ToString()).ToList());
            PopulateComboBoxField(cmbTransportCompany, _context.TransportCompanies.Where(t => t.IsActive == true).Select(l => l.Name).ToList());
            PopulateComboBoxField(cmbTransportType, _context.TransportTypes.Select(l => l.Name).ToList());
            PopulateComboBoxField(cmbSupplier, _context.Suppliers.Where(t => t.IsActive == true).Select(l => l.Name).ToList());
            PopulateComboBoxField(cmbWarehouse, _context.Warehouses.Select(l => l.Name).ToList());
            PopulateComboBoxField(cmbTransportView, _context.TransportViews.Select(l => l.Name).ToList());

            if (IsShipment)
            {


                edSDate.Text = _shipment.SDate == null ? DateTime.Now.ToShortDateString() : _shipment.SDate.Value.ToShortDateString();
                edShipmentComment.Text = _shipment.SComment;
                cmbDelayReasons.Text = DataService.GetDictNameById("Причины_задержки", _shipment.DelayReasonsId);
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
                cmbGate.Text = DataService.GetDictNameById("Ворота", _shipment.GateId);
                cmbTimeSlot.Text = _shipment.TimeSlot == null ? "" : _shipment.TimeSlot.SlotTime.ToString();
                //DataService.GetDictValueById("ТаймСлоты","slot_time", _shipment.TimeSlotId);
                //cbIsCourier.Checked = (bool)_shipment.IsCourier;

                cmbTransportCompany.Text = DataService.GetDictNameById("ТК", _shipment.TransportCompanyId);
                cmbTransportType.Text = DataService.GetDictNameById("Типы_транспорта", _shipment.TransportTypeId);
                cmbSupplier.Text = DataService.GetDictNameById("Поставщики", _shipment.SupplierId);
                cmbWarehouse.Text = DataService.GetDictNameById("Склады", _shipment.WarehouseId);
                cmbTransportView.Text = DataService.GetDictNameById("Виды_транспорта", _shipment.TransportViewId);

                ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository();
                _shipmentOrders = shipmentOrderRepository.GetAll();

                tblShipmentOrders.AutoGenerateColumns = false;
                tblShipmentOrders.DataSource = _shipmentOrders;

                ShipmentOrderPartRepository shipmentOrderPartRepository = new ShipmentOrderPartRepository();
                _shipmentOrderParts = shipmentOrderPartRepository.GetShipmentOrderParts(_shipmentOrders.Select(o=>o.Id).ToList());
                tblOrderParts.AutoGenerateColumns = false;
                tblOrderParts.DataSource = null;
                tblOrderParts.DataSource = _shipmentOrderParts;
                /*
                if (_shipment.ShipmentOrders.Count > 0)
                {


                    BindOrderPart(_shipment.ShipmentOrders.ToList()[0].Id);

               }
                */
                DateTime specTime;
                if (DateTime.TryParse(_shipment.SpecialTime.ToString(), out specTime))
                    dtSpecialTime.Value = specTime;

                dtSpecialCond.Visible = cbSpecCondition.Checked;
                //PopulateOrders();

            }
            else
            {
                edSDate.Text = _movement.MDate==null?DateTime.Now.ToShortDateString(): _movement.MDate.ToShortDateString();
                edShipmentComment.Text = _movement.Comment;
                cmbDelayReasons.Text = DataService.GetDictNameById("Причины_задержки", _movement.DelayReasonsId);
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
        private bool IsValidOrderParts()
        {
            foreach (var order in _shipmentOrders)
            {
                if (_shipmentOrderParts.Where(p=>p.ShOrderId == order.Id).Count() == 0)
                {
                    MessageBox.Show($"У заказа {order.LvOrderCode} нет ни одной раходной партии", "Ошибка при сохранении", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
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

            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_GetUnattachedOrderShipment";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = _shipment.DepositorId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = LVOrdId });

            try
            {
                sql.Execute();
            }
            catch (Exception)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (sql.HasRows())
            {

                while (sql.Read())
                {
                    string lvOstCode = sql.GetStringValue(2);
                    result.Add(lvOstCode);

                }
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
                _shipment.DelayReasonsId = DataService.GetDictIdByName("Причины_задержки", cmbDelayReasons.Text);//Convert.ToInt32(IsNull(cmbDelayReasons.Text, "0"));
                _shipment.TimeSlotId = cbSpecCondition.Checked?(int?)null:DataService.GetDictIdByCondition("ТаймСлоты", $"slot_time='{cmbTimeSlot.Text}'");
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
                _shipment.GateId = DataService.GetDictIdByName("Ворота", cmbGate.Text);
                _shipment.TransportCompanyId = DataService.GetDictIdByName("ТК", cmbTransportCompany.Text);
                _shipment.TransportTypeId = DataService.GetDictIdByName("Типы_транспорта", cmbTransportType.Text);
                _shipment.SupplierId = DataService.GetDictIdByName("Поставщики", cmbSupplier.Text);
                _shipment.WarehouseId = DataService.GetDictIdByName("Склады", cmbWarehouse.Text);
                _shipment.TransportViewId= DataService.GetDictIdByName("Виды_транспорта", cmbTransportView.Text);
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
                _movement.DelayReasonsId = DataService.GetDictIdByName("Причины_задержки", cmbDelayReasons.Text);
                _movement.Performer = edDriverFIO.Text;
                _movement.TimeSlotId = cbSpecCondition.Checked ? (int?)null : DataService.GetDictIdByCondition("ТаймСлоты", $"slot_time='{cmbTimeSlot.Text}'");
                _movement.SpecialTime = cbSpecCondition.Checked ? TimeSpan.Parse(dtSpecialCond.Value.ToShortTimeString()) : (TimeSpan?)null;
                _movement.SpCondition = cbSpecCondition.Checked;
                return true;
            }
        }
        public ShipmenEdit(Planning.DataLayer.Shipment shipment, bool isNew = false)
        {
            
            InitializeComponent();

            _context = DataService.context;
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
            _context = DataService.context;
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
                DialogResult = DialogResult.OK;
            }
                
        }

        private void tbtnAdd_Click(object sender, EventArgs e)
        {

            Planning.DataLayer.ShipmentOrder shipmentOrder = new Planning.DataLayer.ShipmentOrder();
            var frmShipmentOrderEdit = new ShipmentOrderEdit(_shipment, shipmentOrder, _shipmentOrderParts);
            shipmentOrder.ShipmentId = _shipment.Id;
            shipmentOrder.IsBinding = false;
            if (frmShipmentOrderEdit.ShowDialog() == DialogResult.OK)
            {

                //_context.ShipmentOrders.Add(shipmentOrder);
                _shipmentOrders.Add(shipmentOrder);
                tblShipmentOrders.DataSource = _shipmentOrders;
                BindOrderPart((int)shipmentOrder.Id);
            }
            //row["shipment_id"] =_shipment.id;
        }

        private void tbtnEdit_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;
            //ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);
            Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.Find(o => o.Id == Int32.Parse(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
            var frmShipmentOrderEdit = new ShipmentOrderEdit(_shipment, shipmentOrder, _shipmentOrderParts);
            
            frmShipmentOrderEdit.ShowDialog();
            if (frmShipmentOrderEdit.DialogResult == DialogResult.Cancel)
                return;
            tblShipmentOrders.Refresh();
        }

        private void tbtnDel_Click(object sender, EventArgs e)
        {
            if (tblShipmentOrders.CurrentCell == null)
                return;

            if (MessageBox.Show("Удалить заказ?", "Подверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);
                Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.Find(o => o.Id == Int32.Parse(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
                shipmentOrder.Delete();
                //_context.ShipmentOrders.Remove(shipmentOrder);
                tblShipmentOrders.DataSource = _shipmentOrders;
            }
        }

        public void SaveOrders()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                adapter.InsertCommand = new SqlCommand();
                adapter.UpdateCommand = new SqlCommand();
                adapter.DeleteCommand = new SqlCommand();
                connection.Open();

              
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar, 32 , "order_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShipmentId", SqlDbType.Int, 0, "shipment_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderType", SqlDbType.VarChar, 64, "order_type"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 500, "comment"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ManualLoad", SqlDbType.Int, 0, "manual_load"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ManualUnload", SqlDbType.Int, 0, "manual_unload"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@PalletAmount", SqlDbType.Int, 0, "pallet_amount"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@BindingId", SqlDbType.Int, 0, "binding_id"));



                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OrderId1", SqlDbType.VarChar, 32, "order_id"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShipmentId", SqlDbType.Int, 0, "shipment_id"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OrderType", SqlDbType.VarChar, 64, "order_type"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 500, "comment"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ManualLoad", SqlDbType.Int, 0, "manual_load"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ManualUnload", SqlDbType.Int, 0, "manual_unload"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PalletAmount", SqlDbType.Int, 0, "pallet_amount"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BindingId", SqlDbType.Int, 0, "binding_id"));


                
                adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));

                adapter.InsertCommand.Connection = connection;
                adapter.UpdateCommand.Connection = connection;
                adapter.DeleteCommand.Connection = connection;


                adapter.InsertCommand.CommandText = @"Insert into shipment_orders(order_id,shipment_id,order_type,comment,manual_load,manual_unload,pallet_amount,binding_id) 
                                                        values(@OrderId,@ShipmentId,@OrderType,@Comment,@ManualLoad,@ManualUnload,@PalletAmount,@BindingId)";
                adapter.UpdateCommand.CommandText = @"update shipment_orders set order_id = @OrderId1,order_type = @OrderType, comment = @Comment, manual_load = @ManualLoad,
                                                          manual_unload = @ManualUnload, pallet_amount = @PalletAmount where id = 1";


                adapter.DeleteCommand.CommandText= "delete from shipment_orders where id = @Id";
                adapter.Update(ds);
                
                try
                {
                    adapter.Update(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message+" " +ex.InnerException.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
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

        private void shipmen_edit_Load(object sender, EventArgs e)
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

        private void monthCalendarSpecial_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void btnAddToLV_Click(object sender, EventArgs e)
        {

                
            if (DataService.AddShipmentToLV((int)_shipment.Id))
            {
                _shipment.IsAddLv = true;
                MessageBox.Show("Отгрузка создана в Lvision");
            }
            
        }

        private bool BindOrderToLV()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText = "SP_PL_BindAllOrders";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@ShpID", Value = _shipment.Id });
                try
                {
                    command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при связывании заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        private void btnBindLV_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
            if (BindOrderToLV())
            {
               
                bool isAllBindings = true;
               
                var listOrdId = _shipmentOrders.Select(o => (int?)o.Id).ToList();
                var ordParts = _context.ShipmentOrderParts.Where(s => listOrdId.Contains(s.ShOrderId)).ToList();
                /*foreach (var item in _context.ShipmentOrderParts.Where(s=> _shipment.ShipmentOrders.Select(o=>o.Id).ToList().Contains((int)s.ShOrderId)))
                {
                    _context.Entry(item).Reload();
                }
                */
                /*
                foreach (var shipmentOrder in _shipmentOrders)
                {
                    _context.Entry(shipmentOrder).Reload();

                    foreach (var part in shipmentOrder.ShipmentOrderParts)
                    {
                        _context.Entry(part).Reload();

                        if (part.IsBinding == null || part.IsBinding == false)
                        {
                            MessageBox.Show($"Расходная партия [{part.OsLvId}] заказа [{shipmentOrder.OrderId}] не найдена в Lvision]");
                            isAllBindings = false;
                        }
                    }

                }
                */
                foreach (var part in _shipmentOrderParts)
                {
                    if (part.IsBinding == null || part.IsBinding == false)
                    {
                        Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.Find(o => o.Id == part.ShOrderId);
                        MessageBox.Show($"Расходная партия [{part.OsLvId}] заказа [{shipmentOrder.OrderId}] не найдена в Lvision]");
                        isAllBindings = false;
                    }
                }
               
               
                tblShipmentOrders.DataSource = _shipmentOrders;
                if (tblShipmentOrders.SelectedCells != null)
                    BindOrderPart((int)tblShipmentOrders.Rows[tblShipmentOrders.SelectedCells[0].RowIndex].Cells["colId"].Value);
                if (isAllBindings)
                    MessageBox.Show(IsShpIn()? "Все заказы привязаны к отгрузке":"Все расходные партии привязаны к отгрузке");
                //_shipment.IsAddLv = isAllBindings;
            }
        }

        private bool IsAllOrderBindToLv()
        {
            //bool isAllBindings = false;
            int orderNoBindCount = _shipmentOrders.Count(o => o.IsBinding == null || o.IsBinding == false);

            int orderPartNoBindCount = _shipmentOrderParts.Count(o => o.IsBinding == null || o.IsBinding == false);
            

            bool isAllOrderBind = _shipmentOrders.Count() > 0;
            bool isAllOrderPartBind = true;
            foreach (var shipmentOrder in _shipmentOrders)
            {                
                isAllOrderBind = isAllOrderBind && shipmentOrder.IsBinding == true;

                foreach (var part in _shipmentOrderParts.Where(p=>p.ShOrderId == shipmentOrder.Id))
                {
                    isAllOrderPartBind = isAllOrderPartBind && part.IsBinding == true;

                }

            }
            return isAllOrderBind && isAllOrderPartBind;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void edTrailerNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReloadShipment()
        {
            //_context.Entry(_shipment).Reload();
            //foreach (var order in _shipment.ShipmentOrders)
            //{
            //    _context.Entry(order).Reload();


            //}
        }

        private void PopulateMovementItem()
        {
            tblMovementItem.AutoGenerateColumns = false;
            SqlHandle sqlHandle1 = new SqlHandle(DataService.connectionString);
            sqlHandle1.SqlStatement = "SP_PL_GetMovementItems";
            sqlHandle1.Connect();
            sqlHandle1.TypeCommand = CommandType.StoredProcedure;
            sqlHandle1.IsResultSet = true;
            SqlHandle sqlHandle2 = sqlHandle1;
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@MovementID";
            sqlParameter.Value = (object)this._movement.Id;
            sqlHandle2.AddCommandParametr(sqlParameter);
            if (!sqlHandle1.Execute())
            {
                int num = (int)MessageBox.Show(sqlHandle1.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                /*
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add();
                dataSet.Tables[0].Load((IDataReader)sqlHandle1.Reader);
                */
                this.tblMovementItem.DataSource = sqlHandle1.DataSet.Tables[0];
            }
        }

        private void tbtnMoveItemEdit_Click(object sender, EventArgs e)
        {
            ShipmentParam shipmentAddResult = new ShipmentParam();
            shipmentAddResult.IsShipment = false;
            shipmentAddResult.Result = _movement;
            ShipmentAdd frmShipmentAdd = new ShipmentAdd(shipmentAddResult);
            if (frmShipmentAdd.ShowDialog() == DialogResult.OK)
            {
                _context.SaveChanges();
                PopulateMovementItem();
            }

        }

        private void BindOrderPart(int OrderId)
        {
            /*
            ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(OrderId);
            if (shipmentOrder == null)
                return;
            */
            if (_shipmentOrders == null || _shipmentOrders.Count == 0)
                return;
            /*
            shipmentOrderParts.Clear();

            foreach (var item in _shipmentOrders)
            {
                shipmentOrderParts.AddRange(item.ShipmentOrderParts);
            }*/
            tblOrderParts.AutoGenerateColumns = false;
            tblOrderParts.DataSource = null;
            tblOrderParts.DataSource = _shipmentOrderParts;
            tblOrderParts.Refresh();
        }

        private void tblShipmentOrders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (isSelectAction || tblShipmentOrders.CurrentCell == null)
                return;
            isSelectAction = true;
            SelectOrderPart((int)tblShipmentOrders.Rows[e.RowIndex].Cells["colId"].Value);
            isSelectAction = false;
            //BindOrderPart((int)tblShipmentOrders.Rows[e.RowIndex].Cells["colId"].Value);
        }

        private void tbtnAddOrderPart_Click(object sender, EventArgs e)
        {

            if (tblShipmentOrders.CurrentCell == null)
                return;
            string ordId = tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
            if (String.IsNullOrEmpty(ordId) || ordId == "0")
                return;
            int ordIdInt = Int32.Parse(ordId);
            Planning.DataLayer.ShipmentOrder shipmentOrder = _shipmentOrders.FirstOrDefault(o=> o.Id == ordIdInt);


            Planning.DataLayer.ShipmentOrderPart shipmentOrderPart = new Planning.DataLayer.ShipmentOrderPart();
            shipmentOrderPart.ShOrderId = shipmentOrder.Id;
            var frmShipmentOrderPart = new ShipmentOrderPartEdit(_shipment, shipmentOrder, shipmentOrderPart);
           
            shipmentOrderPart.IsBinding = false;
            if (frmShipmentOrderPart.ShowDialog() == DialogResult.OK)
            {

                _shipmentOrderParts.Add(shipmentOrderPart);
                BindOrderPart((int)shipmentOrder.Id);
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
            Planning.DataLayer.ShipmentOrderPart shipmentOrderPart = _shipmentOrderParts.Find(o => o.Id == int.Parse(tblOrderParts.Rows[tblOrderParts.CurrentCell.RowIndex].Cells["colPartsId"].Value.ToString())); 

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
            ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);

            if (tblOrderParts.CurrentCell == null)
                return;

            if (tblOrderParts.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выберите строку для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить расходную партию?", "Подверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentOrderPart shipmentOrderPart = shipmentOrder.ShipmentOrderParts.ToList().Find(o=>o.Id == int.Parse(tblOrderParts.Rows[tblOrderParts.CurrentCell.RowIndex].Cells["colPartsId"].Value.ToString()));
                shipmentOrder.ShipmentOrderParts.Remove(shipmentOrderPart);
                BindOrderPart(0);
                //tblOrderParts.DataSource = shipmentOrder.ShipmentOrderParts.ToList();
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
    }




}
