using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.DataLayer;
using Planning.Kernel;
namespace Planning
{
    public partial class FormLogin : Form
    {
        UserRepository userRepository = new UserRepository();

        public FormLogin()
        {
            InitializeComponent();
            
        }

        private void OkClick()
        {
            Common.CurrentUser = userRepository.GetByUserName(edUserName.Text);
            if (Common.CurrentUser == null || (Common.CurrentUser.Password !=null && Common.CurrentUser.Password != Common.CalculateHashGOST(edPassword.Text)))
            {
                MessageBox.Show($"Пользователь {Common.setting.LastLogin} не найден или не верно указан пароль");
                return;
            }

            Common.setting.LastLogin = edUserName.Text;
            //Common.setting.Password = Common.CalculateHashGOST(edPassword.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OkClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            Common.CurrentUser = userRepository.GetByDomainUserName(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            if (Common.CurrentUser != null && Common.CurrentUser.IsWinAuth != null && (bool)Common.CurrentUser.IsWinAuth)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            edUserName.Text = Common.setting.LastLogin;
        }

        private void edUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                OkClick();
            }
        }
    }
}
