using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class RepStatistic : ReportBase
    {
        public RepStatistic(ReportParams reportParams)
            :base(reportParams)
        {
            InitializeComponent();
        }

        private void InitParams()
        {
            if (edYear.Text == "")
                edYear.Text = DateTime.Now.Year.ToString();
            if (cmbMonthBegin.Text == "")
                cmbMonthBegin.SelectedIndex = 0;
            if (cmbMonthEnd.Text == "")
                cmbMonthEnd.SelectedIndex = 11;
            if (edAdmCoeff.Text == "")
                edAdmCoeff.Text = "20";
        }


        public override void ReportExecute()
        {
            InitParams();
            _reportParams["Year"] = edYear.Text;
            _reportParams["MonthBegin"] = String.Format("{0}{1}",cmbMonthBegin.SelectedIndex<9?"0":"",(cmbMonthBegin.SelectedIndex+1).ToString());
            _reportParams["MonthEnd"] = String.Format("{0}{1}", cmbMonthEnd.SelectedIndex < 9 ? "0":"" , (cmbMonthEnd.SelectedIndex+1).ToString());
            _reportParams["AdmCoeff"] = edAdmCoeff.Text ;
        }

        private void edYear_MouseEnter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                (sender as MaskedTextBox).Select(0, 0);
            });
        }
    }
}
