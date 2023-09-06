using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class frmCurrentTask : Form
    {

        public frmCurrentTask()
        {
            InitializeComponent();
        }


        private void tblTaks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timerUpdateTask.Stop();
                Close();
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private DataSet GetCurrentTask(DateTime DateFrom, DateTime? DateTill)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_CurrentTaskQuery";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;

            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });


            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return sql.DataSet;


        }
        private void LoadTask()
        {
            var ds = GetCurrentTask(DateTime.Now, null);
            if (ds == null)
            {
                return;
            }
            /*
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Load(reader);
            */
           
            tblTaks.DataSource = ds.Tables[0];
        }
        private void tblTaks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["colDonePrc"].Index)
                {


                    using (
                        Brush gridBrush = new SolidBrush(this.tblTaks.GridColor),
                        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // Draw the grid lines (only the right and bottom lines;
                            // DataGridView takes care of the others).
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom - 1);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                e.CellBounds.Top, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom);

                            // Draw the inset highlight box.
                            //e.Graphics.DrawRectangle(Pens.Blue, newRect);

                            // Draw the text content of the cell, ignoring alignment.
                            if (e.Value != DBNull.Value)
                            {
                                decimal doneShare = (decimal)((DataGridView)sender).Rows[e.RowIndex].Cells["colDoneShare"].Value * 100;

                                int progressWidth = (Convert.ToInt32(doneShare) * e.CellBounds.Width) / 100;

                                Rectangle newRect = new Rectangle(e.CellBounds.X + 0,
                                    e.CellBounds.Y + 0, progressWidth,
                                    e.CellBounds.Height - 1);

                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Center;
                                stringFormat.LineAlignment = StringAlignment.Center;

                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), newRect);
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                    Brushes.Black, e.CellBounds, stringFormat);// e.CellBounds.X + 2,e.CellBounds.Y + 2 StringFormat.GenericDefault
                            }
                            e.Handled = true;
                        }
                    }
                }
                
            }
        }

        private void frmCurrentTask_Load(object sender, EventArgs e)
        {


            tblTaks.AutoGenerateColumns = false;
            foreach (var item in DataService.setting.CurrentTaskColumns)
            {
                if (tblTaks.Columns.Contains(item.Id))
                {

                    tblTaks.Columns[item.Id].Width = item.Width;
                    tblTaks.Columns[item.Id].Visible = item.Visible;
                }

            }
            Font tblFont = new Font(tblTaks.DefaultCellStyle.Font.FontFamily, (float)DataService.setting.TaskViewFonSize);
            tblTaks.DefaultCellStyle.Font = tblFont;
            tblTaks.ColumnHeadersDefaultCellStyle.Font = tblFont;


            LoadTask();

            timerUpdateTask.Interval = Convert.ToInt32(DataService.setting.TaskUpdateInterval * 1000);
            timerUpdateTask.Start();
            

        }

        public List<string> GetColumns()
        {
            List<string> columns = new List<string>();

            

            foreach (DataGridViewColumn item in tblTaks.Columns)
            {
                columns.Add(item.HeaderText);
            }
            return columns;
        }

        private void timerUpdateTask_Tick(object sender, EventArgs e)
        {
            LoadTask();
        }

        private void tblTaks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void tblTaks_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void tblTaks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tblTaks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var CellColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;
            var CellFontColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["FontColor"].Value;
            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(CellColor);
            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(CellFontColor);
        }
    }
    
}
