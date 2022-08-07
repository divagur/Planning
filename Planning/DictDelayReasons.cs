using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class DictDelayReasons : Planning.DictForm
    {
        public DictDelayReasons()
        {
            InitializeComponent();
        }
        protected override void Populate()
        {
            tblDelayReasons.AutoGenerateColumns = false;
            tblDelayReasons.DataSource = _context.DelayReasons.ToList();
        }
        protected override void AddRow()
        {
            DelayReason delayReason = new DelayReason();
            frmDelayReasonsEdit frmDelayReasonsEdit = new frmDelayReasonsEdit(delayReason);
            frmDelayReasonsEdit.ShowDialog();
            if (frmDelayReasonsEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.DelayReasons.Add(delayReason);


            Save();
        }

        protected override void EditRow()
        {
            if (tblDelayReasons.SelectedCells.Count <= 0) return;
            DelayReason delayReason = _context.DelayReasons.Find(tblDelayReasons.Rows[tblDelayReasons.CurrentCell.RowIndex].Cells["colId"].Value);
            frmDelayReasonsEdit frmDelayReasonsEdit = new frmDelayReasonsEdit(delayReason);
            frmDelayReasonsEdit.ShowDialog();
            if (frmDelayReasonsEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            DelayReason delayReason = _context.DelayReasons.Find(tblDelayReasons.Rows[tblDelayReasons.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить причину задержки?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _context.DelayReasons.Remove(delayReason);
                Save();
            }
        }

    }
}
