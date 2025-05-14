using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.DataLayer;
namespace Planning
{
    public partial class UserGroupEdit : DictEditForm

    {
        DataLayer.UsersGroup _userGroup;      
        BindingList<UserGrpPrvlgView> _grpPrvlg;

        public UserGroupEdit(DataLayer.UsersGroup userGroup)
        {
            InitializeComponent();
            _userGroup = userGroup;
            tblGrpPrvlg.AutoGenerateColumns = false;
        }
        
        protected override void Populate()
        {
            edGrpName.Text = _userGroup.Name;
            _grpPrvlg = new BindingList<UserGrpPrvlgView>(UserGrpPrvlgViewRepository.GetAll(_userGroup.Id));
            
            tblGrpPrvlg.DataSource = _grpPrvlg;
        }



        protected override bool Save()
        {
            if (edGrpName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _userGroup.Name = edGrpName.Text;
            List<UserGrpPrvlgView> userGrpPrvlgsView = new List<UserGrpPrvlgView>(_grpPrvlg);
            try
            {
                UserGrpPrvlgViewRepository.Save(_userGroup.Id, userGrpPrvlgsView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении настроек группы:{ex.Message}");
                return false;
            }
            
            return true;
        }
        
       
    }
}
