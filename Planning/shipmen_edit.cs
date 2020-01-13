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
    public partial class shipmen_edit : Form
    {
        Shipment _shipment;

        string IsNull(string Value, string NullValue)
        {
            return (Value == "") ? NullValue : Value;
        }

        public void ClearFields()
        {
            cbTransportCompany.Text = "";
            edShipmentComment.Text = "";
            cmbDelayReasons.Text = "";
            edDelayComment.Text = "";
            cbIsCourier.Checked = false;
            dtSubmissionTime.Value = DateTime.Now;
            dtStartTime.Value = DateTime.Now;
            dtEndDatePlan.Value = DateTime.Now;
            dtEndDateFact.Value = DateTime.Now;
            edDriverFIO.Text = "";
            edDriverPhone.Text = "";
            edForwarderFIO.Text = "";
            edVehicleNumber.Text = "";
            edTrailerNumber.Text = "";
            edStamp.Text = "";
            edAttorneyNumber.Text = "";
            dtAttorneyDate.Value = DateTime.Now;
            edAttorneyIssued.Text = "";
            cmbGate.Text = "";
            cmbTimeSlot.Text = "";
            
            

        }

        
        void PopulateFromList(List<DictData> ListSource, ComboBox ComboBoxTaget)
        {
            if (ListSource == null || ComboBoxTaget == null) return;
            ComboBoxTaget.Items.Clear();
            foreach(DictData dt in ListSource)
            {
                ComboBoxTaget.Items.Add(dt.name);
            }
        }

        public void Populate()
        {
            PopulateFromList(DataService.GetDictAll("Причины_задержки"), cmbDelayReasons);
            PopulateFromList(DataService.GetDictAll("Ворота"), cmbGate);
            //PopulateFromList(DataService.GetDictAll(""))

            cbTransportCompany.Text = "";
            edShipmentComment.Text = _shipment.s_comment;
            cmbDelayReasons.Text = DataService.GetDictNameById("Причины_задержки", _shipment.delay_reasons_id);
            edDelayComment.Text = _shipment.delay_comment;
            cbIsCourier.Checked = _shipment.is_courier;
            //dtSubmissionTime.Value = _shipment.submission_time;
            dtStartTime.Value = _shipment.start_time;
            dtEndDatePlan.Value = _shipment.end_time_plan;
            dtEndDateFact.Value = _shipment.end_time_fact;
            edDriverFIO.Text = _shipment.driver_fio;
            edDriverPhone.Text = _shipment.driver_phone;
            edForwarderFIO.Text = _shipment.forwarder_fio;
            edVehicleNumber.Text = _shipment.vehicle_number;
            edTrailerNumber.Text = _shipment.trailer_number;
            edStamp.Text = _shipment.stamp_number;
            edAttorneyNumber.Text = _shipment.attorney_number;
            dtAttorneyDate.Value = _shipment.attorney_date;
            edAttorneyIssued.Text = _shipment.attorney_issued;
            cmbGate.Text = DataService.GetDictNameById("Ворота",_shipment.gate_id);
            cmbTimeSlot.Text = _shipment.time_slot_id.ToString();
            cbIsCourier.Checked = _shipment.is_courier;

            

        }


        void CopyToShipment()
        {
            //cbTransportCompany.Text = "";
            _shipment.s_comment = edShipmentComment.Text;
            _shipment.delay_reasons_id = DataService.GetDictIdByName("Причины_задержки", cmbDelayReasons.Text);//Convert.ToInt32(IsNull(cmbDelayReasons.Text, "0"));
            _shipment.delay_comment = edDelayComment.Text;
            _shipment.is_courier = cbIsCourier.Checked;
            _shipment.submission_time = Convert.ToDateTime(dtSubmissionTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
            _shipment.start_time = Convert.ToDateTime(dtStartTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
            _shipment.end_time_plan = dtEndDatePlan.Value;
            _shipment.end_time_fact =dtEndDateFact.Value;
            _shipment.driver_fio = edDriverFIO.Text;
            _shipment.driver_phone = edDriverPhone.Text;
            _shipment.forwarder_fio = edForwarderFIO.Text;
            _shipment.vehicle_number = edVehicleNumber.Text;
            _shipment.trailer_number = edTrailerNumber.Text;
            _shipment.stamp_number = edStamp.Text;
            _shipment.attorney_number = edAttorneyNumber.Text;
            _shipment.attorney_date = dtAttorneyDate.Value;
            _shipment.attorney_issued = edAttorneyIssued.Text;
            _shipment.gate_id =Convert.ToInt32(IsNull(cmbGate.Text,"0"));
            _shipment.time_slot_id =Convert.ToInt32(IsNull(cmbTimeSlot.Text,"0"));
        }
        public shipmen_edit(Shipment shipment)
        {
            _shipment = shipment;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CopyToShipment();
            DialogResult = DialogResult.OK;
        }
    }
}
