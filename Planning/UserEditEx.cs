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
        public UserEditEx(User user)
        {
            InitializeComponent();
            _user = user;
            _context = DataService.context;
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

            StringBuilder sqlStatement = new StringBuilder($"CREATE LOGIN { Login }");
            if (!IsWindowsUser)
                sqlStatement.Append("WITH PASSWORD = '{Password}';");

            sqlStatement.Append("CREATE USER {Login} FOR LOGIN {Login}");
            sql.SqlStatement = sqlStatement.ToString();
            return sql.Execute();
        }
        private void AddUserToGroup(DataGridViewRow row)
        {
            _user.UserGroups.Add(_context.UserGroups.Find(row.Cells["colGrpId"].Value));
        }

        protected override void Save()
        {
            if (_user.IsReg==false || _user.IsReg ==null)
            {
                CreateUser(edLogin.Text, edPassword.Text, bool.Parse(cbRegType.SelectedIndex.ToString()));
            }

            _user.Login = edLogin.Text;
            
            RemoveAllGroups();
            foreach (DataGridViewRow row in tblGroup.Rows)
            {
                AddUserToGroup(row);
            }
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



                    tblGroup.Rows.Remove(tblGroup.CurrentRow);
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
