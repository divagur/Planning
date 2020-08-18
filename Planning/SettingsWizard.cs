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
    public partial class SettingsWizard : Form
    {
        private List<Panel> steps = new List<Panel>();
        Settings _settings;
        public SettingsWizard(Settings settings)
        {
            InitializeComponent();
            steps.Add(pnConnect);
            steps.Add(pnReport);
            _settings = settings;
            ShowStep(0);
            tvStep.SelectedNode = tvStep.Nodes[0];
            
        }

        public void ShowStep(int Index)
        {
            foreach (Panel pn in steps)
            {
                pn.Visible = false;
            }
            Panel panel = steps[Index];

            panel.Visible = true;
            panel.Dock = DockStyle.Fill;
        }

        private void tvStep_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowStep( int.Parse(e.Node.Tag.ToString()));
        }

        private void SettingsWizard_Load(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                return;
            }
            edServer.Text = _settings.ServerName;
            edBase.Text = _settings.BaseName;
            edUser.Text = _settings.UserName;
            edPassword.Text = _settings.Password;
            edShipmentTemplate.Text = _settings.ShipmentReport;
            edReceiptTemplate.Text = _settings.ReceiptReport;
        }

        private void btnShipmentDlg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog()==DialogResult.OK)       
                edShipmentTemplate.Text = openFileDialog.FileName;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ServerName = edServer.Text;
            _settings.BaseName = edBase.Text;
            _settings.UserName = edUser.Text;
            _settings.Password = edPassword.Text;
            _settings.ShipmentReport = edShipmentTemplate.Text;
            _settings.ReceiptReport = edReceiptTemplate.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnReceiptDlg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                edReceiptTemplate.Text = openFileDialog.FileName;
        }
    }
}
