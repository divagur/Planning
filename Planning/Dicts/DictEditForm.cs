using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.Kernel;

namespace Planning
{
    public partial class DictEditForm : Form
    {
        
        public DictEditForm()
        {
            InitializeComponent();
        }
        

        protected virtual bool Save()
        {
            return true;
        }

        protected virtual void CloseEdit()
        {

        }

        protected virtual void Populate()
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DictEditForm_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
