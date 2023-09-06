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
    public partial class frmGetDateTime : Form
    {
        Control _controlParent;
        Form _formParent;
        public frmGetDateTime(Form formParent, Control controlParent)
        {
            InitializeComponent();
            _controlParent = controlParent;
            _formParent = formParent;
        }

        public string GetStringDate()
        {
            return monthCalendarSpecial.SelectionRange.Start.ToShortDateString();
        }

        private void btnCalendarOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCalendarCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmGetDateTime_Shown(object sender, EventArgs e)
        {
            if (_controlParent == null || _formParent == null)
                return;
            Left = _formParent.Left+_controlParent.Left;
            Top = _formParent.Top + _controlParent.Bottom + 35;
        }
    }
}
