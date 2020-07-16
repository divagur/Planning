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

namespace Planning
{
    public partial class shipmen_edit : Form
    {

        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;

        Shipment _shipment;
        PlanningDbContext _context;
        DataSet ds;
        DictSimple _dict;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string sql = "";
        bool getCalendarTime;

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

        public void ClearFields()
        {
            edSDate.Text = "";
            cmbTransportCompany.Text = "";
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

        


        public void Populate()
        {
            /*
            DataService.PopulateFromList(DataService.GetDictAll("Причины_задержки"), cmbDelayReasons);
            DataService.PopulateFromList(DataService.GetDictAll("Ворота"), cmbGate);
            DataService.PopulateFromList(DataService.GetDictAll("ТаймСлоты"), cmbTimeSlot);
            */


            cmbDelayReasons.Items.Clear();
            foreach (var dr in _context.DelayReasons.ToList())
                cmbDelayReasons.Items.Add(dr.Name);

            cmbGate.Items.Clear();
            foreach (var g in _context.Gateways.ToList()) 
                cmbGate.Items.Add(g.Name);

            cmbTimeSlot.Items.Clear();
            foreach (var ts in _context.TimeSlots.ToList())
            cmbTimeSlot.Items.Add(ts.SlotTime.ToString());

            cmbTransportCompany.Items.Clear();
            foreach (var tc in _context.TransportCompanies.ToList())
                cmbTransportCompany.Items.Add(tc.Name);

            cmbTransportType.Items.Clear();
            foreach (var tt in _context.TransportTypes.ToList())
                cmbTransportType.Items.Add(tt.Name);

            edSDate.Text = _shipment.SDate ==null?DateTime.Now.ToShortDateString():_shipment.SDate.Value.ToShortDateString();
            edShipmentComment.Text = _shipment.SComment;
            cmbDelayReasons.Text = DataService.GetDictNameById("Причины_задержки", _shipment.DelayReasonsId);
            edDelayComment.Text = _shipment.DelayComment;
            cbIsCourier.Checked = _shipment.IsCourier == null?false:(bool)_shipment.IsCourier;
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
            cmbGate.Text = DataService.GetDictNameById("Ворота",_shipment.GateId);
            cmbTimeSlot.Text = _shipment.TimeSlot==null?"":_shipment.TimeSlot.SlotTime.ToString();//DataService.GetDictValueById("ТаймСлоты","slot_time", _shipment.TimeSlotId);
            //cbIsCourier.Checked = (bool)_shipment.IsCourier;
            tblShipmentOrders.AutoGenerateColumns = false;
            tblShipmentOrders.DataSource = _shipment.ShipmentOrders.ToList();
            cmbTransportCompany.Text = DataService.GetDictNameById("ТК", _shipment.TransportCompanyId);
            cmbTransportType.Text = DataService.GetDictNameById("Типы_транспорта", _shipment.TransportTypeId);

            DateTime specTime;
            if (DateTime.TryParse(_shipment.SpecialTime.ToString(),out specTime))
                dtSpecialTime.Value = specTime;

            dtSpecialCond.Visible = cbSpecCondition.Checked;
            //PopulateOrders();

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

        private DateTime? GetDate(TextBox dateControl)
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

        bool CopyToShipment()
        {
            bool success = IsValidDate(edSDate) && IsValidDate(edSubmissionTime) && IsValidDate(edStartTime) && IsValidDate(edEndDate) && IsValidDate(edLeaveTime);
            if (!success)
                return false;

            //cbTransportCompany.Text = "";
            _shipment.SDate = GetDate(edSDate);
            _shipment.SComment = edShipmentComment.Text;
            _shipment.DelayReasonsId = DataService.GetDictIdByName("Причины_задержки", cmbDelayReasons.Text);//Convert.ToInt32(IsNull(cmbDelayReasons.Text, "0"));
            _shipment.TimeSlotId = cbSpecCondition.Checked?(int?)null:DataService.GetDictIdByCondition("ТаймСлоты", $"slot_time='{cmbTimeSlot.Text}'");
            _shipment.SpecialTime = cbSpecCondition.Checked ? TimeSpan.Parse(dtSpecialCond.Value.ToShortTimeString()):(TimeSpan?)null;
            _shipment.DelayComment = edDelayComment.Text;
            _shipment.IsCourier = cbIsCourier.Checked;
            _shipment.SubmissionTime = GetDate(edSubmissionTime);
            _shipment.StartTime = GetDate(edStartTime);
            _shipment.EndTime = GetDate(edEndDate);
            _shipment.LeaveTime = GetDate(edLeaveTime);
            _shipment.DriverFio = edDriverFIO.Text;
            _shipment.DriverPhone = edDriverPhone.Text;
            _shipment.ForwarderFio = edForwarderFIO.Text;
            _shipment.VehicleNumber = edVehicleNumber.Text;
            _shipment.TrailerNumber = edTrailerNumber.Text;
            _shipment.StampNumber = edStamp.Text;
            _shipment.AttorneyNumber = edAttorneyNumber.Text;
            _shipment.AttorneyDate = GetDate(edAttorneyDate);
            _shipment.AttorneyIssued = edAttorneyIssued.Text;
            _shipment.GateId = DataService.GetDictIdByName("Ворота", cmbGate.Text);
            _shipment.TransportCompanyId = DataService.GetDictIdByName("ТК", cmbTransportCompany.Text);
            _shipment.TransportTypeId = DataService.GetDictIdByName("Типы_транспорта", cmbTransportType.Text);
            // _shipment.TimeSlotId =Convert.ToInt32(IsNull(cmbTimeSlot.Text,null));
            return true;
        }
        public shipmen_edit(Shipment shipment)
        {
            
            InitializeComponent();

            _context = DataService.context;
            _shipment = shipment;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CopyToShipment())
                DialogResult = DialogResult.OK;
        }

        private void tbtnAdd_Click(object sender, EventArgs e)
        {

            ShipmentOrder shipmentOrder = new ShipmentOrder();
            var frmShipmentOrderEdit = new ShipmentOrderEdit(shipmentOrder);

            if (frmShipmentOrderEdit.ShowDialog() == DialogResult.OK)
            {
                shipmentOrder.ShipmentId = _shipment.Id;
                shipmentOrder.IsBinding = false;
                _context.ShipmentOrders.Add(shipmentOrder);
                tblShipmentOrders.DataSource = _shipment.ShipmentOrders.ToList();
            }
            //row["shipment_id"] =_shipment.id;
        }

        private void tbtnEdit_Click(object sender, EventArgs e)
        {
            ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmShipmentOrderEdit = new ShipmentOrderEdit(shipmentOrder);

            frmShipmentOrderEdit.ShowDialog();
            if (frmShipmentOrderEdit.DialogResult == DialogResult.Cancel)
                return;
            tblShipmentOrders.Refresh();
        }

        private void tbtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить заказ?", "Подверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentOrder shipmentOrder = _context.ShipmentOrders.Find(tblShipmentOrders.Rows[tblShipmentOrders.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.ShipmentOrders.Remove(shipmentOrder);
                tblShipmentOrders.DataSource = _shipment.ShipmentOrders.ToList();
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

        private void PopulateOrders()
        {
           /* 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter($"select id,order_id,shipment_id,order_type,comment,manual_load,manual_unload,pallet_amount,binding_id from shipment_orders where shipment_id = {_shipment.id}", connection);
                
                ds = new DataSet();
               
                adapter.Fill(ds);
                tblShipmentOrders.AutoGenerateColumns = false;
                tblShipmentOrders.DataSource = ds.Tables[0];
            }
            */
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
                pt.Y = gbTransport.Top + ((Button)sender).Location.Y+((Button)sender).Size.Height + 5;
                pt.X = gbTransport.Left + ((Button)sender).Location.X-pnGetDateTime.Size.Width+((Button)sender).Size.Width;
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
            if (_shipment.ShIn == null || _shipment.ShIn == true)
            {
                btnAddToLV.Visible = false;
                btnBindLV.Visible = false;
            }
        }

        private void monthCalendarSpecial_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void btnAddToLV_Click(object sender, EventArgs e)
        {

                
            if (DataService.AddShipmentToLV(_shipment.Id))
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
            if (BindOrderToLV())
            {
                tblShipmentOrders.DataSource = _shipment.ShipmentOrders.ToList();
                MessageBox.Show("Все заказы привязаны к отгрузке");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void edTrailerNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
