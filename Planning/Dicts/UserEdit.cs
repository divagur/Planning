using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Planning.DataLayer;
namespace Planning
{
    public partial class UserEdit : DictEditForm
    {
        DataLayer.User _user;
        List<DataLayer.UsersGroup> usersGroups;
        public UserEdit(DataLayer.User user)
        {
            InitializeComponent();
            _user = user;            
            /*
            edLogin.Enabled = IsNew;
            edPassword.Enabled = IsNew;
            cbRegType.Enabled = IsNew;
            */
        }


        private void RemoveAllGroups()
        {
            UserGroupLnkRepository userGroupLnkRepository = new UserGroupLnkRepository();
            List<DataLayer.UserGroupLnk> userGroupLnks = userGroupLnkRepository.GetByUserId(_user.Id);

            foreach (var grp in userGroupLnks)
            {
                grp.Delete();
            }
            userGroupLnkRepository.Save(userGroupLnks);
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

        protected override bool Save()
        {
            if (!CanSave())
                return false;
            
            
            _user.Login = edLogin.Text;
            if (!String.IsNullOrEmpty(_user.Password))
            {
                _user.Password = Common.CalculateHashGOST(edPassword.Text);
            }            
            _user.IsWinAuth = cbIsWindowsAuth.Checked;
            _user.DomainUserName = edWindowsUserName.Text;
            RemoveAllGroups();

            UserGroupLnkRepository userGroupLnkRepository = new UserGroupLnkRepository();

            foreach (DataGridViewRow row in tblGroup.Rows)
            {
                if (row.Cells["colGrpId"].Value !=null)
                {
                    UserGroupLnk userGroupLnk = new UserGroupLnk();
                    userGroupLnk.UserId = _user.Id;
                    userGroupLnk.GroupId = (int)row.Cells["colGrpId"].Value;
                    if (! userGroupLnkRepository.Save(userGroupLnk))
                    {
                        MessageBox.Show($"Ошибка при сохранении пользователя:{userGroupLnkRepository.LastError}");
                        return false;
                    }
                }
            }
            return true;
        }

        private void SetFieldEnable()
        {
            edLogin.Enabled = !cbIsWindowsAuth.Checked;
            edPassword.Enabled = !cbIsWindowsAuth.Checked;
            edWindowsUserName.Enabled = cbIsWindowsAuth.Checked;
        }

        protected override void Populate()
        {
            edLogin.Text = _user.Login;
            cbIsWindowsAuth.Checked =_user.IsWinAuth == null?false:(bool)_user.IsWinAuth;
            edWindowsUserName.Text = _user.DomainUserName;

            SetFieldEnable();

            UsersGroupRepository usersGroupRepository = new UsersGroupRepository();
            usersGroups = usersGroupRepository.GetAll();

            foreach (var grp in usersGroups)
            {
                colGrp.Items.Add(grp.Name);
            }

            UserGroupLnkRepository userGroupLnkRepository = new UserGroupLnkRepository();
            List<DataLayer.UserGroupLnk> userGroupLnks = userGroupLnkRepository.GetByUserId(_user.Id);

            foreach (var grp in userGroupLnks)
            {
                int rowIdx = tblGroup.Rows.Add();
                tblGroup.Rows[rowIdx].Cells["colId"].Value = grp.Id;
                tblGroup.Rows[rowIdx].Cells["colGrpId"].Value = grp.GroupId;
                tblGroup.Rows[rowIdx].Cells["colUserId"].Value = grp.UserId;
                var group = usersGroups.FirstOrDefault(g=> g.Id == grp.GroupId);
                tblGroup.Rows[rowIdx].Cells["colGrp"].Value = group == null?"":group.Name;
            }
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblGroup.Rows.Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tblGroup.SelectedRows)
            {
                if (row.Cells["colId"].Value != null)
                {
                    tblGroup.Rows.Remove(row);
                }
            }

        }

        private void tblGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || tblGroup.Columns[e.ColumnIndex].Name != "colGrp")
                return;
            string value = (string)tblGroup.Rows[e.RowIndex].Cells["colGrp"].Value;
            var userGrp = usersGroups.Where(x => x.Name == value).First();
            tblGroup.Rows[e.RowIndex].Cells["colGrpId"].Value = userGrp.Id;
        }


        private void cbIsWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            SetFieldEnable();
        }
    }
}
