using Planning.DataLayer;
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
    public partial class TransportCompanyKpiDelayForm : DictFormEx<TransportCompanyKpiDelay, TransportCompanyKpiDelayRepository>
    {
        public TransportCompanyKpiDelayForm()
        {
            InitializeComponent();
            GridView = tblTransportCompanyKpiDelay;

        }

        protected override bool CreateEditForm(TransportCompanyKpiDelay item)
        {
            TransportCompanyKpiDelayFormEdit frmTransportCompanyKpiDelayEdit = new TransportCompanyKpiDelayFormEdit(item);
            frmTransportCompanyKpiDelayEdit.ShowDialog();
            return !(frmTransportCompanyKpiDelayEdit.DialogResult == DialogResult.Cancel);
        }

        private void tblTransportCompanyKpiDelay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = Common.MinutesToTimeSpan((int)e.Value);
            }
            
        }
    }
}
