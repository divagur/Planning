using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class UserEditEx : DictEditForm
    {
        User _user;
        PlanningDbContext _context;
        bool _isNew;
        public UserEditEx(User user, bool IsNew)
        {
            InitializeComponent();
            _user = user;
            _context = DataService.context;
            _isNew = IsNew;
            cbRegType.SelectedIndex = 1;
            edLogin.Enabled = IsNew;
            edPassword.Enabled = IsNew;
            cbRegType.Enabled = IsNew;
        }


        private void RemoveAllGroups()
        {
           foreach (DataGridViewRow row in tblGroup.Rows)
            {
                _user.UserGroups.Remove(_context.UserGroups.Find(row.Cells["colGrpId"].Value));
            }
        }
        private bool CreateUser(string Login, string Password, bool IsWindowsUser)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);

            StringBuilder sqlStatement = new StringBuilder($"CREATE LOGIN { Login } ");
           
            if (!IsWindowsUser)
                sqlStatement.Append($"WITH PASSWORD = '{Password}, CHECK_POLICY = OFF';");
            sql.SqlStatement = sqlStatement.ToString();

            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sqlStatement.Clear();
            sqlStatement.Append($"CREATE USER {Login} FOR LOGIN {Login};");
            sql.SqlStatement = sqlStatement.ToString();

            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sqlStatement.Clear();
            sqlStatement.Append($" EXEC [sp_addrolemember] 'pl_user', '{Login}';");
            sql.SqlStatement = sqlStatement.ToString();
            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        

        private bool AlterLogin(string Login, string NewPassword)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);

            sql.SqlStatement = $"ALTER USER {Login} WITH PASSWORD = '{NewPassword}'";

            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql.SqlStatement = $"ALTER LOGIN {Login} WITH PASSWORD = '{NewPassword}'";

            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void AddUserToGroup(DataGridViewRow row)
        {
            _user.UserGroups.Add(_context.UserGroups.Find(row.Cells["colGrpId"].Value));
        }

        private bool CanSave()
        {
            if (tblGroup.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь не входит ни в одну из групп", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool AddUserToDepositors()
        {
            bool success = true;
            foreach(Depositor dep in _context.Depositors)
            {
                if (dep.LvBase != null)
                    success = success && DataService.CreateDBUser(dep.LvBase, edLogin.Text, edLogin.Text);
            }
            return success;
        }
        protected override bool Save()
        {
            if (!CanSave())
                return false;
            
            if (_isNew)
            {
                if (!DataService.CreateLogin(edLogin.Text, edPassword.Text, cbRegType.SelectedIndex == 0 ? true:false))
                {
                    return false;
                }
                //MessageBox.Show("Создание пользователя");
                if (!DataService.CreateDBUser(DataService.setting.BaseName, edLogin.Text, edLogin.Text))
                {
                    return false;
                }
                //MessageBox.Show("Создание пользователя у депозиторов");
                if (!AddUserToDepositors())
                {
                    return false;
                }
            }
            else if (_user.RegType == 1)
            {
                if (!AlterLogin(edLogin.Text,edPassword.Text))
                {
                    return false;
                }
            }
            

            _user.Login = edLogin.Text;
           // _user.Password = DataService.EncryptHash(edPassword.Text);
            RemoveAllGroups();
            foreach (DataGridViewRow row in tblGroup.Rows)
            {
                AddUserToGroup(row);
            }
            return true;
        }

        protected override void Populate()
        {
            edLogin.Text = _user.Login;
            foreach(UserGroup grp in _context.UserGroups)
            {
                colGrp.Items.Add(grp.Name);
            }

            foreach(UserGroup grp in _user.UserGroups)
            {
                int rowIdx = tblGroup.Rows.Add();
                tblGroup.Rows[rowIdx].Cells["colGrpId"].Value = grp.Id;
                tblGroup.Rows[rowIdx].Cells["colGrp"].Value = grp.Name;
            }
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblGroup.Rows.Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in tblGroup.Rows)
            {
                if (row.Selected)
                {
                    //UserGrpPrvlg userGrpPrvlg = _context.UserGrpPrvlgs.First(g=>g.GrpId == Int32.Parse(row.Cells["colGrpId"].Value.ToString()));
                    UserGroup userGroup =_user.UserGroups.First(g=>g.Id == Int32.Parse(row.Cells["colGrpId"].Value.ToString()));
                    if (userGroup != null)
                    {
                        _user.UserGroups.Remove(userGroup);
                        tblGroup.Rows.Remove(tblGroup.CurrentRow);
                    }

                }
                    
            }
            
        }

        private void tblGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex ==1)
                return;
            string value = (string)tblGroup.Rows[e.RowIndex].Cells["colGrp"].Value;
            var userGrp = _context.UserGroups.Where(x => x.Name == value).First();
            tblGroup.Rows[e.RowIndex].Cells["colGrpId"].Value = userGrp.Id;
        }

        private void cbRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbRegType.SelectedIndex)
            {
                case 0:
                    edPassword.Enabled = false;
                    break;
                case 1:
                    edPassword.Enabled = true;
                    break;
            }
        }
    }
}
