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
namespace PlanningAdminSettings
{
    public partial class MainForm : Form
    {
        PlanningConfig planningConfig;
        PlanningConfigHandle PlanningConfigHandle;
        public MainForm()
        {
            InitializeComponent();
            planningConfig = new PlanningConfig();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            planningConfig.ServerName = edServer.Text;
            planningConfig.BaseName = edBase.Text;
            planningConfig.UserName = edUser.Text;
            planningConfig.Password = edPassword.Text;
            PlanningConfigHandle.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PlanningConfigHandle = new PlanningConfigHandle("PlanningConfig.xml", planningConfig);
            PlanningConfigHandle.Load();
            edServer.Text = planningConfig.ServerName;
            edBase.Text = planningConfig.BaseName;
            edUser.Text = planningConfig.UserName;
            edPassword.Text = planningConfig.Password;
        }
    }
}
