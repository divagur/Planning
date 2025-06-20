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
    public partial class FormEdit : Form
    {
        protected byte _formState;

        public FormEdit()
        {
            InitializeComponent();
            //_formState = FormSate;
            //_row = Row;
        }
        protected virtual void Save()
        {

        }

        protected virtual void Cancel()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
