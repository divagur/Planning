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

namespace Planning
{
    public partial class UserGroupEdit : Form

    {
        private UserGroup _userGroup;
        PlanningDbContext _context;
        public UserGroupEdit(UserGroup userGroup)
        {
            InitializeComponent();
            _userGroup = userGroup;
            _context = DataService.context;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
        }
        
        private void Populate()
        {
            edGrpName.Text = _userGroup.Name;
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($@"select f.id func_id, f.name func_name,ugp.grp_id, ugp.is_view, ugp.is_append, ugp.is_edit, ugp.is_delete
                 from
                    functions f
                    left
                    join
                    user_grp_prvlg ugp
                    on(f.id = ugp.func_id and ugp.grp_id = {_userGroup.Id})", connection);
                
                DataSet ds = new DataSet();
               
                adapter.Fill(ds);
                tblGrpPrvlg.AutoGenerateColumns = false;
                tblGrpPrvlg.DataSource = ds.Tables[0];
            }
        }

        private void Save()
        {
            _userGroup.Name = edGrpName.Text;
           /* try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorText = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errorText = errorText + "Object: " + validationError.Entry.Entity.ToString() + "\n\r";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errorText = errorText + err.ErrorMessage + "\n\r";

                    }
                }
                MessageBox.Show(errorText);
            }
            */
            SaveChild();

        }
        private bool? RowToBool(object Row)
        {
            return Row.ToString() == "" ? false : bool.Parse(Row.ToString());
        }
        private bool InsertDataRow(DataRow Row)
        {
            /*
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = $@"insert into user_grp_prvlg(func_id, grp_id, is_view, is_append, is_edit, is_delete)
                                                        values('{Row["func_id"]}',{_userGroup.Id},'{Row["is_view"]}','{Row["is_append"]}', '{Row["is_edit"]}','{Row["is_delete"]}')";
            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            UserGrpPrvlg ugp = new UserGrpPrvlg();
            ugp.GrpId = _userGroup.Id;
            ugp.FuncId = (string)Row["func_id"];
            ugp.IsView = RowToBool(Row["is_view"]);
            ugp.IsAppend = RowToBool(Row["is_append"]);
            ugp.IsEdit = RowToBool(Row["is_edit"]);
            ugp.IsDelete = RowToBool(Row["is_delete"]);

            _context.UserGrpPrvlgs.Add(ugp);
            return true;

           
        } 
        private void SaveChild()
        {
            tblGrpPrvlg.EndEdit();
            tblGrpPrvlg.BindingContext[tblGrpPrvlg.DataSource].EndCurrentEdit();

            _context.UserGrpPrvlgs.RemoveRange(_context.UserGrpPrvlgs.Where(x => x.GrpId == _userGroup.Id).ToList());

/*
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "delete from user_grp_prvlg where grp_id =" + _userGroup.Id.ToString();
            if (!sql.Execute())
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           */ 
            foreach (DataRow row in (tblGrpPrvlg.DataSource as DataTable).Rows)
            {
                if (!InsertDataRow(row))
                    return;
            }

        }
        private void UserGroupEdit_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
