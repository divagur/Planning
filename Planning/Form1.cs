using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Planning
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tblShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            tblShipments.DataSource = DataService.GetAll();
        }

        private void miDictDelayReasons_Click(object sender, EventArgs e)
        {
            DelayReasons frmDelayReasons = new DelayReasons();
            frmDelayReasons.Show();
        }
    }
}
