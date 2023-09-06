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
using Excel = Microsoft.Office.Interop.Excel;

namespace Planning
{

    
    public partial class frmShipmentHistory : Form
    {
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
        private int currShpId = 0;
        private int currColorIdx = 0;
        private string currShpItemId;
        //private int currColorItemIdx = 0;
        int _shipmentId = -1;
        bool _isShipment;
        PlanningDbContext _context = DataService.context;

        public frmShipmentHistory()
        {
             InitializeComponent();
        }

        public frmShipmentHistory(int ShipmentId, bool IsShipment):this()
        {
           
            dtBegin.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            cmbShpType.SelectedIndex = 0;
            _shipmentId = ShipmentId;
            _isShipment = IsShipment;
            if (_shipmentId > 0)
            {
                lbShpType.Visible = false;
                cmbShpType.Visible = false;
                lbUser.Visible = false;
                cmbUser.Visible = false;
                btnFind.Left = 251;
                pnFilter.Height = 36;
                cmbShpType.SelectedIndex = 0;
            }
            else
                    cmbUser.Items.AddRange(_context.Users.Select(i=>i.Login).ToArray());
            tblShipmentItemLog.AutoGenerateColumns = false;
        }

        private void CalcRowColor()
        {
            int cellShpId;
            int cellLastShpId = 0;
            int currColorIdx = 0;
            for (int i = 0; i < tblShipmentLog.Rows.Count; i++)
            {
                cellShpId = (int)(tblShipmentLog).Rows[i].Cells["colShpId"].Value;
                if (cellLastShpId != cellShpId)
                {
                    cellLastShpId = cellShpId;
                    currColorIdx = currColorIdx == 0 ? 1 : 0;
                }
                (tblShipmentLog).Rows[i].Cells["BackgroundColor"].Value = currColorIdx;
            }


            
           
        }
        public void Populate()
        {

            string UserId= cmbUser.Text; 
            int ShpType = cmbShpType.SelectedIndex-1;

            SqlHandle sql = new SqlHandle(DataService.connectionString);

            #region ДатыОтгрузки
            if (_shipmentId>=0)
            {
                sql.Connect();
                string table_name = !_isShipment ? "movement_log" : "shipments_log";
                string field_name= !_isShipment ? "movement_id" : "shipment_id";
                sql.TypeCommand = CommandType.Text;
                sql.IsResultSet = true;
                sql.SqlStatement = $@"select min(dml_date) min_dml_date, max(dml_date) max_dml_date
                from {table_name}
                where {field_name} = " + _shipmentId;
                bool Success = sql.Execute() && sql.HasRows() && sql.Read();
                if (Success)
                {                   
                    dtBegin.Value = sql.IsNull(0) ? DateTime.Now: sql.GetDateTimeValue(0, true);  
                    dtEnd.Value = sql.IsNull(1) ? DateTime.Now:sql.GetDateTimeValue(1, true);
                }
                sql.Disconnect();

            }

            #endregion

            DateTime DateFrom = dtBegin.Value;
            DateTime DateTill = dtEnd.Value;

            sql.SqlStatement = "SP_PL_GetShipmentLog";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            object shpType = null;
            if (ShpType >= 0)
                shpType = ShpType;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = _shipmentId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = shpType });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@UserId", Value = UserId });
            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Load(sql.Reader);
            */
            tblShipmentLog.AutoGenerateColumns = false;
            tblShipmentLog.DataSource = sql.DataSet.Tables[0];
            sql.Disconnect();
            CalcRowColor();

            tblShipmentItemLog.AutoGenerateColumns = false;
            tblMovementItemLog.AutoGenerateColumns = false;

            if (tblShipmentLog.Rows.Count > 0)
                ShowShipmentLogDetail();

            /*tblShipmentItemLog.Visible = false;
            tblMovementItemLog.Visible = false;*/

        }

        private void tblShipmentLog_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
            var CellColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;
            var CellShpId = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["colShpId"].Value;


            if (currShpId != CellShpId)
            {
                currShpId = CellShpId;
                currColorIdx = currColorIdx == 0 ? 1 : 0;
            }

            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColors[CellColor];
        }

        private void tblShipmentLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["colDmlType"].Index)
                {
                    string dmlTypeId = (string)((DataGridView)sender).Rows[e.RowIndex].Cells["colDmlTypeId"].Value;
                    if (dmlTypeId == "I")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(64, 50, 231);
                    }
                    else if (dmlTypeId == "U")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(255, 128, 64);
                    }
                    else if (dmlTypeId == "D")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                    }
                }
                else
                {
                    if (e.RowIndex>0 && e.ColumnIndex>0)
                    {
                        object currValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        object prevValue = ((DataGridView)sender).Rows[e.RowIndex-1].Cells[e.ColumnIndex].Value;

                        int shpIdCurr = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["colShpId"].Value;
                        int shpIdPrev = (int)((DataGridView)sender).Rows[e.RowIndex-1].Cells["colShpId"].Value;
                        
                        if (currValue == null || prevValue == null) return; 

                        if (shpIdCurr == shpIdPrev && currValue.ToString() != prevValue.ToString())
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(216, 33, 65);
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(0,0,0);
                        }
                    }
                }
                
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            Excel.Range range;
            ExcelPrint excel = new ExcelPrint("");
            DataRow[] printRows = (tblShipmentLog.DataSource as DataTable).Select();
            
            int startRow = 5;

            int visibleCount = 0;

            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();
            wait.SetRange(0, tblShipmentLog.RowCount);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");

            int headerRow = startRow - 1;
            for (int c = 0; c < tblShipmentLog.Columns.Count; c++)
            {
                if (tblShipmentLog.Columns[c].Visible)
                {
                    excel.SetValue(1, c + 1, headerRow, tblShipmentLog.Columns[c].HeaderText);
                    excel.SetColumnWidth(1, c + 1, tblShipmentLog.Columns[c].Width);
                    visibleCount++;
                }

            }

            string[,] printRow = new string[1, visibleCount];
            string cellValue;
            int visibleIdx;
            //tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colDirection"].Value.ToString()
            for (int r = 0; r < tblShipmentLog.RowCount; r++)
            {
                visibleIdx = 0;
                for (int c = 0; c < tblShipmentLog.Columns.Count; c++)
                {
                    if (tblShipmentLog.Columns[c].Visible && tblShipmentLog.Rows[r].Cells[c].Value != null)
                    {


                        cellValue = tblShipmentLog.Rows[r].Cells[c].Value.ToString();
                        if (tblShipmentLog.Columns[c].Name == "colDmlDate" || tblShipmentLog.Columns[c].Name == "colShpDate")
                            cellValue = cellValue.Substring(0, 10);
                        else if (tblShipmentLog.Columns[c].Name == "colShpSpCondition")
                            cellValue = cellValue == "true" ? "Да" : "Нет";

                        printRow[0, visibleIdx++] = cellValue;
                        
                    }

                }
                excel.SetRowValues(1, startRow + r, visibleCount, printRow);
                wait.SetPosition(r);
            }

           

            range = excel.SelectCells(1, visibleCount / 2 - 3, 2, visibleCount/2+3, 2);
            range.Merge();
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.Value = "История изменения отгрузок с "+dtBegin.Value.ToShortDateString()+" по "+dtEnd.Value.ToShortDateString();

            excel.SetRowHeight(1, headerRow, 50);
            range = excel.SelectCells(1, 1, headerRow, tblShipmentLog.Columns.Count, headerRow);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.WrapText = true;

            range = excel.SelectCells(1, 1, headerRow, visibleCount, headerRow+tblShipmentLog.RowCount);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.Visible = true;
            wait.Close();
        }

        private void tblShipmentLog_Click(object sender, EventArgs e)
        {

        }

        private void tblShipmentLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* if (e.RowIndex < 0)
                 return;
             int shpId = Int32.Parse(tblShipmentLog.Rows[e.RowIndex].Cells["colShpId"].Value.ToString());
             List<ShipmentOrdersLog> listShipmentOrdersLog = _context.ShipmentOrdersLog.Where(i => i.ShipmentId == shpId).OrderBy(o=>o.OrderId).ThenBy(o=>o.DmlDate).ToList();


             if (tblShipmentLog.Rows[e.RowIndex].Cells["colShpIn"].Value == null || tblShipmentLog.Rows[e.RowIndex].Cells["colShpIn"].Value.ToString() == "")
             {
                 tblShipmentItemLog.Visible = false;
                 tblMovementItemLog.Visible = true;
                 tblShipmentItemLog.DataSource = listShipmentOrdersLog;
             }
             else
             {
                 tblShipmentItemLog.Visible = true;
                 tblMovementItemLog.Visible = false;
                 tblShipmentItemLog.DataSource = listShipmentOrdersLog;
             }

             CalcRowColorItem();
            */
            ShowShipmentLogDetail();
        }

        private void CalcRowColorItem()
        {
            string cellOrderId;
            string cellLastOrderId = "";
            currColorIdx = 0;
            for (int i = 0; i < tblShipmentItemLog.Rows.Count; i++)
            {
                if (tblShipmentItemLog.Rows[i].Cells["colShpItemOrderId"].Value == null)
                    continue;

                cellOrderId = tblShipmentItemLog.Rows[i].Cells["colShpItemOrderId"].Value.ToString();
                if (cellLastOrderId != cellOrderId)
                {
                    cellLastOrderId = cellOrderId;
                    currColorIdx = currColorIdx == 0 ? 1 : 0;
                }
                tblShipmentItemLog.Rows[i].Cells["colItemBackgroundColor"].Value = currColorIdx;
            }
        }

        private void tblShipmentItemLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tblShipmentItemLog.Columns["colDmlTypeName"].Index == e.ColumnIndex)
            {
                if (tblShipmentItemLog.Rows[e.RowIndex].Cells["colShpItemDmlType"].Value.ToString() == "I")
                    e.Value = "Создание";
                else if (tblShipmentItemLog.Rows[e.RowIndex].Cells["colShpItemDmlType"].Value.ToString() == "U")
                    e.Value = "Изменение";
                else if (tblShipmentItemLog.Rows[e.RowIndex].Cells["colShpItemDmlType"].Value.ToString() == "D")
                    e.Value = "Удаление";
            }
                
        }

        private void tblShipmentItemLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["colDmlTypeName"].Index)
                {
                    string dmlTypeId = (string)((DataGridView)sender).Rows[e.RowIndex].Cells["colShpItemDmlType"].Value;
                    if (dmlTypeId == "I")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(64, 50, 231);
                    }
                    else if (dmlTypeId == "U")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(255, 128, 64);
                    }
                    else if (dmlTypeId == "D")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                    }
                }
                else
                {
                    if (e.RowIndex > 0 && e.ColumnIndex > 0)
                    {
                        object currValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        object prevValue = ((DataGridView)sender).Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value;

                        string shpIdCurr = ((DataGridView)sender).Rows[e.RowIndex].Cells["colShpItemOrderId"].Value.ToString();
                        string shpIdPrev = ((DataGridView)sender).Rows[e.RowIndex - 1].Cells["colShpItemOrderId"].Value.ToString();

                        if (currValue == null || prevValue == null) return;

                        if (shpIdCurr == shpIdPrev && currValue.ToString() != prevValue.ToString())
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(216, 33, 65);
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(0, 0, 0);
                        }
                    }
                }

            }
        }

        private void tblShipmentItemLog_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
              var CellColorValue = ((DataGridView)sender).Rows[e.RowIndex].Cells["colItemBackgroundColor"].Value;
              var CellShpIdValue = ((DataGridView)sender).Rows[e.RowIndex].Cells["colShpItemOrderId"].Value;


            if (CellColorValue == null || CellShpIdValue == null)
                return;

            int CellColor = (int)CellColorValue;
            string CellShpId = CellShpIdValue.ToString();

              if (currShpItemId != CellShpId)
              {
                  currShpItemId = CellShpId.ToString();
                  currColorIdx = currColorIdx == 0 ? 1 : 0;
              }

              ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColors[CellColor];
        }

        private void ShowShipmentLogDetail()
        {

            int row = tblShipmentLog.CurrentRow ==null?-1:tblShipmentLog.CurrentRow.Index;
            if (row < 0)
                return;
            int shpId = Int32.Parse(tblShipmentLog.Rows[row].Cells["colShpId"].Value.ToString());
            
            if (tblShipmentLog.Rows[row].Cells["colShpIn"].Value == null || tblShipmentLog.Rows[row].Cells["colShpIn"].Value.ToString() == "")
            {
                tblShipmentItemLog.Visible = false;
                tblMovementItemLog.Visible = true;
                //tblMovementItemLog.BringToFront();
                List<MovementItemLog> listShipmentOrdersLog = _context.MovementItemLog.Where(i => i.MovementId == shpId).OrderBy(o => o.MovementItemId).ThenBy(o => o.DmlDate).ToList();
                tblShipmentItemLog.DataSource = listShipmentOrdersLog;
            }
            else
            {
                tblShipmentItemLog.Visible = true;
                //tblShipmentItemLog.BringToFront();
                tblMovementItemLog.Visible = false;
                List<ShipmentOrdersLog> listShipmentOrdersLog = _context.ShipmentOrdersLog.Where(i => i.ShipmentId == shpId).OrderBy(o => o.OrderId).ThenBy(o => o.DmlDate).ToList();
                tblShipmentItemLog.DataSource = listShipmentOrdersLog;
            }
            /*tblShipmentLog.Focus();
            Invalidate();*/
            CalcRowColorItem();
        }
        private void tblShipmentLog_SelectionChanged(object sender, EventArgs e)
        {
            /*DataGridView grid = (sender as DataGridView);
            int row = grid.CurrentRow.Index;
            if (row < 0)
                return;
            int shpId = Int32.Parse(tblShipmentLog.Rows[row].Cells["colShpId"].Value.ToString());
            List<ShipmentOrdersLog> listShipmentOrdersLog = _context.ShipmentOrdersLog.Where(i => i.ShipmentId == shpId).OrderBy(o => o.OrderId).ThenBy(o => o.DmlDate).ToList();
            if (tblShipmentLog.Rows[row].Cells["colShpIn"].Value == null)
            {
                tblShipmentItemLog.Visible = false;
                tblMovementItemLog.Visible = true;
                tblMovementItemLog.BringToFront();
                tblShipmentItemLog.DataSource = listShipmentOrdersLog;
            }
            else
            {
                tblShipmentItemLog.Visible = true;
                tblShipmentItemLog.BringToFront();
                tblMovementItemLog.Visible = false;
                tblShipmentItemLog.DataSource = listShipmentOrdersLog;
            }

            CalcRowColorItem();*/
        }

        private void tblMovementItemLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tblMovementItemLog.Columns["colMvmItemDmlTypeName"].Index == e.ColumnIndex)
            {
                if (tblMovementItemLog.Rows[e.RowIndex].Cells["colMvmntDmlTypeId"].Value.ToString() == "I")
                    e.Value = "Создание";
                else if (tblMovementItemLog.Rows[e.RowIndex].Cells["colMvmntDmlTypeId"].Value.ToString() == "U")
                    e.Value = "Изменение";
                else if (tblMovementItemLog.Rows[e.RowIndex].Cells["colMvmntDmlTypeId"].Value.ToString() == "D")
                    e.Value = "Удаление";
            }
        }
    }
}
