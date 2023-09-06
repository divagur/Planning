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
    public partial class ReportBase : Form
    {

        protected ReportParams _reportParams;

        public ReportBase()
        {
            InitializeComponent();
        }
        
        public ReportBase(ReportParams reportParams)
            :this()
        {

            _reportParams = reportParams;
        }
        
        public virtual void CloseForm()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public virtual void ReportExecute()
        { 
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReportExecute();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
