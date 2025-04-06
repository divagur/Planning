using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class TimeSlots : DictForm
    {
        List<DataLayer.TimeSlot> _timeSlots = new List<DataLayer.TimeSlot>();
        DataLayer.TimeSlotRepository _timeSlotRepository = new DataLayer.TimeSlotRepository();

        public TimeSlots()
        {
            InitializeComponent();
        }

        private void UpdateDataSource()
        {
            tblTimeSlot.DataSource = null;
            tblTimeSlot.DataSource = _timeSlots;
            tblTimeSlot.Refresh();
        }

        private DataLayer.TimeSlot GetSelectedObject()
        {
           return _timeSlots.Find(t => t.Id == Int32.Parse(tblTimeSlot.Rows[tblTimeSlot.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
        }
        protected override void AddRow()
        {
            DataLayer.TimeSlot timeSlot = new DataLayer.TimeSlot();
            var frmTimeSlotEdit = new TimeSlotEdit(timeSlot);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;

            _timeSlots.Add(timeSlot);
            _timeSlotRepository.Save(timeSlot);
            UpdateDataSource();
        }

        protected override void EditRow()
        {
            DataLayer.TimeSlot timeSlot = GetSelectedObject();
            var frmTimeSlotEdit = new TimeSlotEdit(timeSlot);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;

            _timeSlotRepository.Save(timeSlot);
            UpdateDataSource();
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataLayer.TimeSlot timeSlot = GetSelectedObject();
                timeSlot.Delete();
                _timeSlotRepository.Save(timeSlot);
            }
        }
       

        protected override void Populate()
        {
            tblTimeSlot.AutoGenerateColumns = false;
            _timeSlots = _timeSlotRepository.GetAll();
            UpdateDataSource();
        }


    }
}
