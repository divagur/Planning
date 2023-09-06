using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class RepTC : ReportBase
    {
        public RepTC(ReportParams reportParams)
           : base(reportParams)
        {
            InitializeComponent();
            btnPeriodBegin.Tag = edPeriodBegin;
            btnPeriodEnd.Tag = edPeriodEnd;
        }

        private void btnPeriodBegin_Click(object sender, EventArgs e)
        {
            frmGetDateTime frmGetDateTime = new frmGetDateTime(this, ((TextBox)((Button)sender).Tag));
            if (frmGetDateTime.ShowDialog() == DialogResult.OK)
            {
                ((TextBox)((Button)sender).Tag).Text = frmGetDateTime.GetStringDate();
            }
        }
        public override void ReportExecute()
        {
            _reportParams["PeriodBegin"] = edPeriodBegin.Text;
            _reportParams["PeriodEnd"] = edPeriodEnd.Text;
        }
    }
}
