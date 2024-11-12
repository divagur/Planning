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

namespace PlanningTasks
{
    public partial class frmMain : Form
    {
        List<CurrentTask> currentTasks;
        string[] args;
        bool isConfig = false;
        public frmMain(string[] args)
        {
            this.args = args;
            InitializeComponent();
            isConfig = args != null && !String.IsNullOrEmpty(args.FirstOrDefault(p => p == "/config"));
                
        }


        private void tblTaks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timerUpdateTask.Stop();
                Close();
            }
            else if (e.Alt && e.Control && e.KeyCode == Keys.Space)
            {
                tblTaks.ClearSelection();
                if (FormBorderStyle == FormBorderStyle.None)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                tblTaks.Invalidate();
                tblTaks.Refresh();
            }

        }

        
        private async void LoadTask()
        {
            CurrentTaskRepository currentTaskRepository = new CurrentTaskRepository();
            //currentTasks = currentTaskRepository.GetList(DateTime.Now, null);
            List<CurrentTask> currentTasks = await currentTaskRepository.GetListAsync();
            tblTaks.DataSource = currentTasks;
            //dataGrid.DataSource = currentTasks;
        }

        private void ConfigureTable()
        {
            tblTaks.AutoGenerateColumns = false;
            foreach (var item in Config.VisibleColumns)
            {
                if (tblTaks.Columns.Contains(item.Id))
                {

                    tblTaks.Columns[item.Id].Width = item.Width;
                    tblTaks.Columns[item.Id].Visible = item.Visible;
                    tblTaks.Columns[item.Id].HeaderText = item.Title;
                }

            }
            Font tblFont = new Font(tblTaks.DefaultCellStyle.Font.FontFamily, (float)Config.TaskViewFonSize);
            tblTaks.DefaultCellStyle.Font = tblFont;
            tblTaks.ColumnHeadersDefaultCellStyle.Font = tblFont;

        }
        private void frmCurrentTask_Load(object sender, EventArgs e)
        {

            Config.Load("PlanningTaskConfig.xml");

            ConfigureTable();

            if (isConfig)
                return;
            if (String.IsNullOrEmpty(Config.Server) || String.IsNullOrEmpty(Config.DataBase) 
                || String.IsNullOrEmpty(Config.Login)|| String.IsNullOrEmpty(Config.Password))
            {
                FormLogin frmLogin = new FormLogin();
                if (frmLogin.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            LoadTask();

            timerUpdateTask.Interval = Convert.ToInt32(Config.UpdateInterval*60000);
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

        }

        private void tblTaks_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void tblTaks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                                decimal doneShare = 0;
                                if (((DataGridView)sender).Rows[e.RowIndex].Cells["colDoneShare"].Value != null)
                                {
                                    doneShare = (decimal)((DataGridView)sender).Rows[e.RowIndex].Cells["colDoneShare"].Value * 100;
                                }


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

        private void tblTaks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView tbl = (DataGridView)sender;
            int CellColor = 0;
            Color CellFontColorRGB = Color.Black;
            Color CellColorRGB = Color.White;
            if (tbl.Rows[e.RowIndex].Cells["BackgroundColor"].Value !=null)
            {
                CellColor = (int)tbl.Rows[e.RowIndex].Cells["BackgroundColor"].Value;
            }
            if(tbl.Rows[e.RowIndex].Cells["FontColorRGB"].Value !=null)
            {
                CellFontColorRGB = (Color)tbl.Rows[e.RowIndex].Cells["FontColorRGB"].Value;
            }
            if (tbl.Rows[e.RowIndex].Cells["BackgroundColorRGB"].Value != null)
            {
                CellColorRGB = (Color)tbl.Rows[e.RowIndex].Cells["BackgroundColorRGB"].Value;
            }
            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = CellColorRGB;// Color.FromArgb(CellColor);
            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.ForeColor = CellFontColorRGB;
        }

        private void tblTaks_SelectionChanged(object sender, EventArgs e)
        {
            this.tblTaks.ClearSelection();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isConfig)
            {
                Config.VisibleColumns.Clear();
                foreach (DataGridViewColumn col in tblTaks.Columns)
                {
                    if (!col.Visible)
                        continue;

                    CurrentTaskColumn currentTaskColumn = new CurrentTaskColumn();
                    currentTaskColumn.Title = col.HeaderText;
                    currentTaskColumn.Width = col.Width;
                    currentTaskColumn.Id = col.Name;
                    currentTaskColumn.Visible = col.Visible;
                    Config.VisibleColumns.Add(currentTaskColumn);
                }
                Config.Save();
            }
        }

        private void tblTaks_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!isConfig)
                return;
            InputForm inputForm = new InputForm("Введите имя колонки", tblTaks.Columns[e.ColumnIndex].HeaderText);
            if (inputForm.ShowDialog() == DialogResult.OK && inputForm.InputString != "")
            {
                tblTaks.Columns[e.ColumnIndex].HeaderText = inputForm.InputString;
            }
        }
    }
    
}
