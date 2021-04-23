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
    public partial class frmProgressBar : Form
    {
        public frmProgressBar(int minValue, int maxValue)
        {
            InitializeComponent();
            progressBar.Minimum = minValue;
            progressBar.Maximum = maxValue;
        }

        private void frmProgressBar_Load(object sender, EventArgs e)
        {

        }
        public void SetText(string Text)
        {
            lbWaitMessage.Text = Text;
        }
        public void SetRange(int minValue, int maxValue)
        {
            progressBar.Minimum = minValue;
            progressBar.Maximum = maxValue;
        }
        public void SetPosition(int Position)
        {

            if (Position < progressBar.Minimum || Position > progressBar.Maximum) return;
            progressBar.Value = Position;
        }

        public void IncPosition()
        {

            if (progressBar.Value < progressBar.Minimum || progressBar.Value > progressBar.Maximum) return;
            progressBar.Value++;
        }

    }
}
