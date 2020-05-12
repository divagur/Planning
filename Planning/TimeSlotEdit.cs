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
        TimeSlot _timeSlot;
        PlanningDbContext _context;

        public TimeSlotEdit(TimeSlot timeSlot, PlanningDbContext context)
        {
            InitializeComponent();
            _timeSlot = timeSlot;
            _context = context;
            DataService.PopulateFromList(DataService.GetDictAll("Депозиторы"), cmbDepositor);

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
            _timeSlot.DepositorId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);

            DialogResult = DialogResult.OK;
        }

        private void TimeSlotEdit_Load(object sender, EventArgs e)
        {
            cmbDepositor.Items.Clear();
            foreach (var d in _context.Depositors.ToList())
                cmbDepositor.Items.Add(d.Name);
            cmbDepositor.Text = DataService.GetDictNameById("Депозиторы", _timeSlot.DepositorId);
            edTimeSlot.Text = _timeSlot.SlotTime.ToString();
        }
    }
}
