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
        string connectionString = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        string sql = "";


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
            cbTransportCompany.Text = "";
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


            cbTransportCompany.Text = "";
            edSDate.Text = _shipment.SDate ==null?DateTime.Now.ToShortDateString():_shipment.SDate.Value.ToShortDateString();
            edShipmentComment.Text = _shipment.SComment;
            cmbDelayReasons.Text = DataService.GetDictNameById("Причины_задержки", _shipment.DelayReasonsId);
            edDelayComment.Text = _shipment.DelayComment;
            cbIsCourier.Checked = _shipment.IsCourier == null?false:(bool)_shipment.IsCourier;
            edSubmissionTime.Text = _shipment.SubmissionTime.ToString();
            //dtSubmissionTime.Text = _shipment.SubmissionTime.ToString();
            edStartTime.Text = _shipment.StartTime.ToString();
            edEndDate.Text = _shipment.EndTime.ToString();
            edLeaveTime.Text = _shipment.LeaveTime.ToString();
            //dtEndDatePlan.Text = _shipment.EndTimePlan.ToString();
            //dtEndDateFact.Text = _shipment.EndTimeFact.ToString();
            edDriverFIO.Text = _shipment.DriverFio;
            edDriverPhone.Text = _shipment.DriverPhone;
            edForwarderFIO.Text = _shipment.ForwarderFio;
            edVehicleNumber.Text = _shipment.VehicleNumber;
            edTrailerNumber.Text = _shipment.TrailerNumber;
            edStamp.Text = _shipment.StampNumber;
            edAttorneyNumber.Text = _shipment.AttorneyNumber;
            //dtAttorneyDate.Text = _shipment.AttorneyDate.ToString();
            edAttorneyDate.Text = _shipment.AttorneyDate.ToString();
            edAttorneyIssued.Text = _shipment.AttorneyIssued;
            cmbGate.Text = DataService.GetDictNameById("Ворота",_shipment.GateId);
            cmbTimeSlot.Text = DataService.GetDictNameById("ТаймСлоты", _shipment.TimeSlotId);
            //cbIsCourier.Checked = (bool)_shipment.IsCourier;
            tblShipmentOrders.AutoGenerateColumns = false;
            tblShipmentOrders.DataSource = _shipment.ShipmentOrders.ToList();

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
            // _shipment.TimeSlotId =Convert.ToInt32(IsNull(cmbTimeSlot.Text,null));
            return true;
        }
        public shipmen_edit(Shipment shipment, PlanningDbContext context)
        {
            
            InitializeComponent();

            _context = context;
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
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);

            ShipmentOrder shipmentOrder = new ShipmentOrder();
            var frmShipmentOrderEdit = new ShipmentOrderEdit(shipmentOrder);

            frmShipmentOrderEdit.ShowDialog();
            if (frmShipmentOrderEdit.DialogResult == DialogResult.Cancel)
                return;
            _context.ShipmentOrders.Add(shipmentOrder);
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
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in tblShipmentOrders.SelectedRows)
            {
                tblShipmentOrders.Rows.Remove(row);
            }
        }

        public void SaveOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                pnGetDateTime.Show();


                
            }
        }

        private void SelectDate()
        {

            Button btn = (Button)pnGetDateTime.Tag;
            ((TextBox)btn.Tag).Text = monthCalendarSpecial.SelectionRange.Start.ToShortDateString() + " " + dtSpecialTime.Value.ToShortTimeString();
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
        }

        private void monthCalendarSpecial_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
