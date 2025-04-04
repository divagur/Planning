using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Planning.Kernel;
namespace Planning
{
    public partial class SimpleDict<T,R> : DictForm
        where T: BaseDataItem
        where R: IRepository<T>, new()
    {
        DataSet ds;
        DictSimple _dict;
        SqlDataAdapter adapter;
        BindingList<T> _listDataItemBinding;
        List<T> _listDataItem = new List<T>();
        R _repository = new R();
        bool isChanged = false;
        //SqlConnection connection;
        //string connectionString;// = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        FormEdit _editForm;
        string sql = "";

        public void SetEditForm(FormEdit editForm)
        {
            _editForm = editForm;
            if (_editForm != null)
            {
                tblDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                btnEdit.Visible = true;
            }
        }

        public SimpleDict(DictSimple dict)
        {
            InitializeComponent();
            _dict = dict;
            // _editForm = EditForm;
            btnEdit.Visible = false;
            this.Text = _dict.Title;
           
        }
/*
        public DelayReasons()
        {
           


            
        }
        */
        private void DelayReasons_Load(object sender, EventArgs e)
        {
            InitColumns();
        }
        private void InitColumns()
        {
            foreach (DictColumn dictColumn in _dict.Columns)
            {
                DataGridViewColumn column;
                if (dictColumn.ItemValues == null)
                {
                    switch (dictColumn.DataType)
                    {
                        case SqlDbType.Bit:
                            column = new DataGridViewCheckBoxColumn();
                            break;
                        default:
                            column = new DataGridViewTextBoxColumn();
                            break;
                    }

                }
                else
                {
                    column = new DataGridViewComboBoxColumn();
                    ((DataGridViewComboBoxColumn)column).Items.AddRange(dictColumn.ItemValues);
                }

                column.Name = dictColumn.Id;
                column.HeaderText = dictColumn.Title;
                column.DataPropertyName = dictColumn.DataField;
                column.Visible = dictColumn.IsVisible;
                column.Width = dictColumn.Width;

                tblDataGrid.Columns.Add(column);
                //sqlColumns = (sqlColumns == "") ? dictColumn.DataField : sqlColumns + "," + dictColumn.DataField;
            }
        }

        protected override void AddRow()
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            foreach (var dictCol in _dict.Columns)
            {
                if (dictCol.DefaultValue !=null)
                {
                    row[dictCol.DataField] = dictCol.DefaultValue;
                }
            }
            ds.Tables[0].Rows.Add(row);
        }

        protected override void DelRow()
        {
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in tblDataGrid.SelectedRows)
            {
                tblDataGrid.Rows.Remove(row);
            }
        }

        protected override void EditRow()
        {
            if (_editForm != null)
            {
                _editForm.ShowDialog();
            }
        }
        
        protected override void Populate()
        {
            tblDataGrid.AutoGenerateColumns = false;
            _repository = new R();
            _listDataItem = _repository.GetAll();

            _listDataItemBinding = new BindingList<T>(_listDataItem);
            _listDataItemBinding.ListChanged += _listDataItemBinding_ListChanged;            
            tblDataGrid.DataSource = _listDataItemBinding;
            btnSave.Visible = true;

            /*
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                string sqlColumns = "";

                

                sql = String.Format("select {0} from {1}", sqlColumns, _dict.TableName);
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                
                adapter.Fill(ds);
                tblDataGrid.AutoGenerateColumns = false;
                tblDataGrid.DataSource = ds.Tables[0];
                btnSave.Visible = true;
                //tblDelayReasons.Columns[0].DataPropertyName = "id";
                //tblDelayReasons.Columns[1].DataPropertyName = "name";

                // делаем недоступным столбец id для изменения
                //tblDelayReasons.Columns["id"].Visible = false;
            }
            */
        }

        private void _listDataItemBinding_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted && e.OldIndex>=0)
            {
                _listDataItemBinding[e.OldIndex].Delete();
            }
            isChanged = true;
        }

        protected override void SaveRow()
        {
            if (_repository.Save(_listDataItem))
            {
                isChanged = false;
                for (int i = 0; i < tblDataGrid.Rows.Count; i++)
                {
                    tblDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

            }

            /*
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {

                tblDataGrid.EndEdit();
                tblDataGrid.BindingContext[tblDataGrid.DataSource].EndCurrentEdit();
                adapter.InsertCommand = new SqlCommand();
                adapter.UpdateCommand = new SqlCommand();
                adapter.DeleteCommand = new SqlCommand();
                //adapter.SelectCommand = new SqlCommand();

                connection.Open();
                string insertColumns = "";
                string insertValues = "";
                string pkCondition = "";
                string updateColumns = "";
                foreach (DictColumn column in _dict.Columns)
                {
                    if (!column.IsPK)
                    {
                        insertColumns = (insertColumns == "") ? column.DataField : insertColumns + "," + column.DataField;
                        insertValues = (insertValues == "") ? "@" + column.Id : insertValues + ", @" + column.Id;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@" + column.Id, column.DataType, column.Length, column.DataField));

                        updateColumns = (updateColumns == "") ? column.DataField + "= @" + column.Id : updateColumns + ", " + column.DataField + "= @" + column.Id;
                        adapter.UpdateCommand.Parameters.Add(new SqlParameter("@" + column.Id, column.DataType, column.Length, column.DataField));
                    }
                    else
                    {
                        pkCondition = (pkCondition == "") ? column.DataField + " = @" + column.Id : pkCondition + " and " + column.DataField + " = @" + column.Id;
                        adapter.UpdateCommand.Parameters.Add(new SqlParameter("@" + column.Id, column.DataType, column.Length, column.DataField));
                        adapter.DeleteCommand.Parameters.Add(new SqlParameter("@" + column.Id, column.DataType, column.Length, column.DataField));
                    }
                }

                adapter.InsertCommand.Connection = connection;
                adapter.UpdateCommand.Connection = connection;
                adapter.DeleteCommand.Connection = connection;
                adapter.SelectCommand.Connection = connection;

                adapter.InsertCommand.CommandText = String.Format("insert into {0} ({1}) values ({2})", _dict.TableName, insertColumns, insertValues);
                adapter.UpdateCommand.CommandText = String.Format("update {0} set {1} where {2}", _dict.TableName, updateColumns, pkCondition);
                adapter.DeleteCommand.CommandText = String.Format("delete from {0} where {1}", _dict.TableName, pkCondition);
                try
                {
                    adapter.Update(ds);                    
                    ds.Tables[0].Clear();
                    adapter.Fill(ds);
                    
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                for (int i = 0; i < tblDataGrid.Rows.Count; i++)
                {
                    tblDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                

            }
            */

        }

        private void tblDelayReasons_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tblDelayReasons_CurrentCellChanged(object sender, EventArgs e)
        {


        }

        private void tblDelayReasons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            tblDataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(62,158,255);
            isChanged = true;
        }

        private void SimpleDict_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isChanged)
            {
                if (MessageBox.Show("Внесенные изменения не сохранены, выполнить сохранение?","Внимание",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    SaveRow();
                }
            }
        }
    }
}
