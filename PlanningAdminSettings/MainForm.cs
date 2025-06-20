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
using Planning.DataLayer;
using Planning;

namespace PlanningAdminSettings
{
    public partial class MainForm : Form
    {
        PlanningConfig planningConfig;
        PlanningConfigHandle PlanningConfigHandle;
        UserRepository userRepository = new UserRepository();
        User user;
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

            planningConfig.DefaultWarehouseCode = edWarehouseDefault.Text;
            planningConfig.DefaultTransportViewName = edTransportViewDefault.Text;

            PlanningConfigHandle.Save();
            //SaveSystemAdmin();
        }
        public static string CalculateHashGOST(string message)
        {
            GOST G = new GOST(256);
            byte[] messageByte = Encoding.UTF8.GetBytes(message);
            byte[] res = G.GetHash(messageByte);
            return BitConverter.ToString(res).Replace("-", "");
        }
        private void SaveSystemAdmin()
        {

            if (user != null && user.Login !=edAdminLogin.Text)
            {
                user.Delete();  
                userRepository.Save(user);
                user = null;
            }

            if (user == null) 
            {
                user = new User();
                user.Login =edAdminLogin.Text;
                user.IsSystemUser = true;
                user.IsWinAuth = false;
                if (!String.IsNullOrEmpty(edAdminPwd.Text))
                {
                    user.Password = CalculateHashGOST(edAdminPwd.Text);
                }
                userRepository.Save(user);
            }

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            PlanningConfigHandle = new PlanningConfigHandle("PlanningConfig.xml", planningConfig);
            PlanningConfigHandle.Load();
            edServer.Text = planningConfig.ServerName;
            edBase.Text = planningConfig.BaseName;
            edUser.Text = planningConfig.UserName;
            edPassword.Text = planningConfig.Password;

            edWarehouseDefault.Text = planningConfig.DefaultWarehouseCode;
            edTransportViewDefault.Text = planningConfig.DefaultTransportViewName;
            /*
            user = userRepository.GetSystemUser();
            if (user != null)
            {
                edAdminLogin.Text = user.Login;
            }
            */
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
