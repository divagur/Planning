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

namespace Planning
{
    public partial class SimpleDict : Form
    {
        DataSet ds;
        DictSimple _dict;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        string sql = "";

        public SimpleDict(DictSimple dict)
        {
            InitializeComponent();
            _dict = dict;
            this.Text = _dict.Title;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlColumns = "";

                foreach (DictColumn dictColumn in _dict.Columns)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = dictColumn.Id;
                    column.HeaderText = dictColumn.Title;
                    column.DataPropertyName = dictColumn.DataField;
                    column.Visible = dictColumn.IsVisible;
                    column.Width = dictColumn.Width;
                    
                    tblDelayReasons.Columns.Add(column);
                    sqlColumns = (sqlColumns == "") ? dictColumn.DataField : sqlColumns + "," + dictColumn.DataField;
                }
                sql = String.Format("select {0} from {1}", sqlColumns, _dict.TableName);
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();

                adapter.Fill(ds);
                tblDelayReasons.AutoGenerateColumns = false;
                tblDelayReasons.DataSource = ds.Tables[0];
                //tblDelayReasons.Columns[0].DataPropertyName = "id";
                //tblDelayReasons.Columns[1].DataPropertyName = "name";

                // делаем недоступным столбец id для изменения
                //tblDelayReasons.Columns["id"].Visible = false;
            }
        }
/*
        public DelayReasons()
        {
           


            
        }
        */
        private void DelayReasons_Load(object sender, EventArgs e)
        {


        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter.InsertCommand = new SqlCommand();
                adapter.UpdateCommand = new SqlCommand();
                adapter.DeleteCommand = new SqlCommand();
                connection.Open();
                string insertColumns = "";
                string insertValues = "";
                string pkCondition = "";
                string updateColumns = "";
                foreach(DictColumn column in _dict.Columns)
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
                /*adapter.InsertCommand = new SqlCommand("Insert into delay_reasons(name) values(@Name)", connection);
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 254, "name"));

                adapter.UpdateCommand = new SqlCommand("update delay_reasons set name = @Name where id = @Id", connection);
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 254, "name"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));

                adapter.DeleteCommand = new SqlCommand("delete delay_reasons where id = @Id", connection);
                adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));
                */
                adapter.InsertCommand.Connection = connection;
                adapter.UpdateCommand.Connection = connection;
                adapter.DeleteCommand.Connection = connection;

                adapter.InsertCommand.CommandText = String.Format("insert into {0} ({1}) values ({2})", _dict.TableName, insertColumns, insertValues);
                adapter.UpdateCommand.CommandText = String.Format("update {0} set {1} where {2}", _dict.TableName, updateColumns, pkCondition);
                adapter.DeleteCommand.CommandText = String.Format("delete {0} where {1}", _dict.TableName, pkCondition);
                try
                {
                    adapter.Update(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in tblDelayReasons.SelectedRows)
            {
                tblDelayReasons.Rows.Remove(row);
            }
        }
    }
}
