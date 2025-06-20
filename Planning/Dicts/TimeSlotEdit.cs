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
    public partial class TimeSlotEdit : Form
    {

        DataLayer.TimeSlot _timeSlot;
        

        List<DataLayer.Depositor> _depositors = new List<DataLayer.Depositor>();


        public TimeSlotEdit(DataLayer.TimeSlot timeSlot)
        {
            InitializeComponent();
            _timeSlot = timeSlot;

            Populate();
        }

        private void Populate()
        {
            DataLayer.DepositorRepository depositorRepository = new DataLayer.DepositorRepository();
            _depositors = depositorRepository.GetAll();
            cmbDepositor.Items.Clear();           

            foreach (var item in _depositors)
            {
                cmbDepositor.Items.Add(item.Name);
            }

            DataLayer.Depositor depositor = _depositors.Find(d => d.Id == _timeSlot.DepositorId);
            cmbDepositor.Text = depositor == null ? null : depositor.Name;
            edTimeSlot.Text = _timeSlot.SlotTime.ToString();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //_timeSlot.Name = edTimeSlot.Text;
            _timeSlot.SlotTime = edTimeSlot.Text =="  :  :"?(TimeSpan?)null:TimeSpan.Parse(edTimeSlot.Text);

            DataLayer.Depositor depositor = _depositors.Find(d=>d.Name == cmbDepositor.Text);
            _timeSlot.DepositorId = depositor == null ? null : depositor.Id;

            DialogResult = DialogResult.OK;
        }

        private void TimeSlotEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
