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
        public TimeSlots()
        {
            InitializeComponent();
        }

        protected override void AddRow()
        {
            TimeSlot timeSlot = new TimeSlot();
            var frmTimeSlotEdit = new TimeSlotEdit(timeSlot);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.TimeSlots.Add(timeSlot);
            Save();
        }

        protected override void EditRow()
        {
            TimeSlot timeSlot = _context.TimeSlots.Find(tblTimeSlot.Rows[tblTimeSlot.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmTimeSlotEdit = new TimeSlotEdit(timeSlot);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TimeSlot timeSlot = _context.TimeSlots.Find(tblTimeSlot.Rows[tblTimeSlot.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.TimeSlots.Remove(timeSlot);
                Save();
            }
        }
       

        protected override void Populate()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string sqlText = @"select ts.id ts_id,d.id dep_id, d.name dep_name, ts.slot_time
                                    from 
                                            time_slot ts join depositors d on (ts.depositor_id = d.id)";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblTimeSlot.AutoGenerateColumns = false;
                tblTimeSlot.DataSource = ds.Tables[0];
            }
        }


    }
}
