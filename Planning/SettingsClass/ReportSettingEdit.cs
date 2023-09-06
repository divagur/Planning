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
    public partial class ReportSettingEdit : Form
    {
        SettingReport _settingReport;
        public ReportSettingEdit(SettingReport settingReport)
        {
            InitializeComponent();
            _settingReport = settingReport;
            edName.Text = _settingReport.Name;
            edTemplate.Text = _settingReport.TemplatePath;
            btnGetTemplate.Tag = edTemplate;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (edName.Text == String.Empty)
            {
                MessageBox.Show("Не задано имя отчета");
                edName.Focus();
                return;
            }
            _settingReport.Name = edName.Text;
            _settingReport.TemplatePath = edTemplate.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnShipmentDlg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                ((TextBox)((Button)sender).Tag).Text = openFileDialog.FileName;
        }
    }
}
