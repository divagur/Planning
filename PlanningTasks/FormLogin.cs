using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PlanningTasks
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void OkClick()
        {
            Config.Server = edServer.Text;
            Config.DataBase = edDB.Text;
            Config.Login = edUserName.Text;
            Config.Password = edPassword.Text;
            SqlHandle sqlHandle = new SqlHandle(Config.ConnectionString);
            if (!sqlHandle.Connect())
            {
                MessageBox.Show(sqlHandle.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.AddErrorEvent(sqlHandle.LastError);
                //DialogResult = DialogResult.Cancel;
            }
            else
            {

                Config.Save();
                DialogResult = DialogResult.OK;
                Close();
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
            edServer.Text = Config.Server;
            edDB.Text = Config.DataBase;
            edUserName.Text = Config.Login;
            edPassword.Text = Config.Password;
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
