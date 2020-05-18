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
    public partial class SettingsEdit : Form
    {
        Settings _settings;
        public SettingsEdit(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ServerName = edServer.Text;
            _settings.BaseName = edBase.Text;
            _settings.UserName = edUser.Text;
            _settings.Password = edPassword.Text;
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SettingsEdit_Load(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                return;
            }
            edServer.Text = _settings.ServerName;
            edBase.Text = _settings.BaseName;
            edUser.Text = _settings.UserName;
            edPassword.Text = _settings.Password;
        }
    }
}
