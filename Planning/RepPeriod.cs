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
    public partial class RepPeriod : Form
    {
        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;

        ReportParams _reportParams;

        public RepPeriod(ReportParams reportParams)
        {
            InitializeComponent();
            _reportParams = reportParams;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || (m.Msg == WM_PARENTNOTIFY && (int)m.WParam == WM_LBUTTONDOWN))
                if (!pnGetDateTime.ClientRectangle.Contains(pnGetDateTime.PointToClient(Cursor.Position)) &&
                    (!btnPeriodBegin.ClientRectangle.Contains(btnPeriodBegin.PointToClient(Cursor.Position))))
                    pnGetDateTime.Hide();
            base.WndProc(ref m);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _reportParams["PeriodBegin"] = edPeriodBegin.Text;
            _reportParams["PeriodEnd"] = edPeriodEnd.Text;
            _reportParams["ShpType"] = cbType.SelectedIndex.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnPeriodBegin_Click(object sender, EventArgs e)
        {
            frmGetDateTime frmGetDateTime = new frmGetDateTime(this, ((TextBox)((Button)sender).Tag));
            if (frmGetDateTime.ShowDialog() == DialogResult.OK)
            {
                ((TextBox)((Button)sender).Tag).Text = frmGetDateTime.GetStringDate();
            }
            /*
            if (!pnGetDateTime.Visible)
            {
               

                Point pt = pnGetDateTime.Location;
                
                pt.Y = ((Button)sender).Location.Y + ((Button)sender).Size.Height + 5;
                pt.X = ((Button)sender).Location.X - pnGetDateTime.Size.Width + ((Button)sender).Size.Width;
                pnGetDateTime.Location = pt;
                pnGetDateTime.Tag = sender;
                DateTime dateStart = ((TextBox)((Button)sender).Tag).Text == "" ? DateTime.Now : DateTime.Parse(((TextBox)((Button)sender).Tag).Text);
                monthCalendarSpecial.SetSelectionRange(dateStart, dateStart);

                pnGetDateTime.Show();
                


            }*/
        }

        private void RepPeriod_Load(object sender, EventArgs e)
        {
            btnPeriodBegin.Tag = edPeriodBegin;
            btnPeriodEnd.Tag = edPeriodEnd;
            cbType.SelectedIndex = 0;
        }

        private void btnCalendarCancel_Click(object sender, EventArgs e)
        {
            pnGetDateTime.Hide();
        }

        private void btnCalendarOk_Click(object sender, EventArgs e)
        {
            SelectDate();
        }

        private void SelectDate()
        {

            Button btn = (Button)pnGetDateTime.Tag;
            ((TextBox)btn.Tag).Text = monthCalendarSpecial.SelectionRange.Start.ToShortDateString();
            pnGetDateTime.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
