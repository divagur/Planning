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
    public partial class DictDelayReasons : DictFormEx<DataLayer.DelayReason, DataLayer.DelayReasonRepository>
    {

        public DictDelayReasons()
        {
            InitializeComponent();
            GridView = tblDelayReasons;
        }

        protected override bool CreateEditForm(DataLayer.DelayReason item)
        {
            frmDelayReasonsEdit frmDelayReasonsEdit = new frmDelayReasonsEdit(item);
            frmDelayReasonsEdit.ShowDialog();
            return !(frmDelayReasonsEdit.DialogResult == DialogResult.Cancel);
        }

    }
}
