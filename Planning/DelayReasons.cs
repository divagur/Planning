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
    public partial class DelayReasons : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=ПОЛЬЗОВАТЕЛЬ-ПК\SQLEXPRESS2017;Initial Catalog=Planning;User ID=SYSADM; Password = SYSADM";
        string sql = "SELECT id,name FROM delay_reasons";

        public DelayReasons()
        {
            InitializeComponent();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
               
                adapter.Fill(ds);
                tblDelayReasons.AutoGenerateColumns = false;
                tblDelayReasons.DataSource = ds.Tables[0];
                tblDelayReasons.Columns[0].DataPropertyName = "id";
                tblDelayReasons.Columns[1].DataPropertyName = "name";
                // делаем недоступным столбец id для изменения
                //tblDelayReasons.Columns["id"].Visible = false;
            }
        }

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
                connection.Open();
                adapter.InsertCommand = new SqlCommand("Insert into delay_reasons(name) values(@Name)", connection);
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 254, "name"));

                adapter.UpdateCommand = new SqlCommand("update delay_reasons set name = @Name where id = @Id", connection);
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 254, "name"));
                adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));

                adapter.DeleteCommand = new SqlCommand("delete delay_reasons where id = @Id", connection);
                adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "id"));

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
