using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningTasks
{
    public partial class InputForm : Form
    {

        public InputForm(string Capture, string InputValue)
        {
            InitializeComponent();
            this.Text = Capture;
            edInputString.Text = InputValue;
        }

        public string InputString { get; set; }
        private void btnOk_Click(object sender, EventArgs e)
        {
            InputString = edInputString.Text;
            DialogResult = DialogResult.OK;
        }

        private void CloseForm()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

    }
}
