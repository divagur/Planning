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
    public partial class FormLogin : Form
    {
        Settings _setting;
        public FormLogin(Settings setting)
        {
            InitializeComponent();
            _setting = setting;
        }

        private User GetUserByLogin(string login)
        {

            User user = DataService.context.Users.FirstOrDefault(u=>u.Login == login);

            
            return user;
        }

        private void OkClick()
        {
            /*
            User user = GetUserByLogin(edUserName.Text);
            string hash = DataService.EncryptHash(edPassword.Text);
            bool bSuccess = user!=null && user.Password == DataService.EncryptHash(edPassword.Text);

            if (!bSuccess)
            {
                MessageBox.Show("Не правильное имя пользователя или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _setting.LastLogin = edUserName.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            */
            
            _setting.UserName = edUserName.Text;
            _setting.Password = edPassword.Text;
            //MessageBox.Show($"Подключение к серверу: {DataService.setting.ServerName} базе: {DataService.setting.BaseName} пользователь: {DataService.setting.UserName} ");
            if (DataService.TryDBConnect(DataService.setting.ServerName, DataService.setting.BaseName, DataService.setting.UserName, DataService.setting.Password,false, false))
            {
                //MessageBox.Show("Успешно");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Не правильное имя пользователя или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            edUserName.Text = _setting.LastLogin;
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
