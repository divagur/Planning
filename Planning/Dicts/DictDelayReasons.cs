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
        List<DataLayer.DelayReason> _delayReasons;
        DataLayer.DelayReasonRepository _delayReasonRepository = new DataLayer.DelayReasonRepository();

        public DictDelayReasons()
        {
            InitializeComponent();
        }

        private void UpdateDataSource()
        {
            
            tblDelayReasons.DataSource = null;
            tblDelayReasons.DataSource = _delayReasons;
            tblDelayReasons.Refresh();
        }

        protected override void Populate()
        {
            tblDelayReasons.AutoGenerateColumns = false;
            _delayReasons = _delayReasonRepository.GetAll();
            UpdateDataSource();
        }
        private DataLayer.DelayReason GetCurrentRowObject()
        {
            return _delayReasons.Find(d => d.Id == Int32.Parse(tblDelayReasons.Rows[tblDelayReasons.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
        }
        protected override void AddRow()
        {
            DataLayer.DelayReason delayReason = new DataLayer.DelayReason();
            frmDelayReasonsEdit frmDelayReasonsEdit = new frmDelayReasonsEdit(delayReason);
            frmDelayReasonsEdit.ShowDialog();
            if (frmDelayReasonsEdit.DialogResult == DialogResult.Cancel)
                return;
            _delayReasons.Add(delayReason);
            _delayReasonRepository.Save(delayReason);
            UpdateDataSource();
        }

        protected override void EditRow()
        {
            if (tblDelayReasons.SelectedCells.Count <= 0) return;
            DataLayer.DelayReason delayReason = GetCurrentRowObject();
            frmDelayReasonsEdit frmDelayReasonsEdit = new frmDelayReasonsEdit(delayReason);
            frmDelayReasonsEdit.ShowDialog();
            if (frmDelayReasonsEdit.DialogResult == DialogResult.Cancel)
                return;
            _delayReasonRepository.Save(delayReason);
            UpdateDataSource();
        }

        protected override void DelRow()
        {
            DataLayer.DelayReason delayReason = GetCurrentRowObject();
            if (MessageBox.Show("Удалить причину задержки?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                delayReason.Delete();
                if (_delayReasonRepository.Save(delayReason))
                {
                    _delayReasons.Remove(delayReason);
                }
                UpdateDataSource();                
            }
        }

    }
}
