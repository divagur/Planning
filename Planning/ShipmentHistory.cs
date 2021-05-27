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

    
    public partial class frmShipmentHistory : Form
    {
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
        private int currShpId = 0;
        private int currColorIdx = 0;
        int _shipmentId = -1;
        PlanningDbContext _context = DataService.context;
        public frmShipmentHistory(int ShipmentId)
        {
            InitializeComponent();
            dtBegin.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            _shipmentId = ShipmentId;
            if (_shipmentId > 0)
            {
                lbShpType.Visible = false;
                cmbShpType.Visible = false;
                lbUser.Visible = false;
                cmbUser.Visible = false;
                btnFind.Left = 251;
                pnFilter.Height = 36;

            }
            else
                    cmbUser.Items.AddRange(_context.Users.Select(i=>i.Login).ToArray());

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

                sql.TypeCommand = CommandType.Text;
                sql.IsResultSet = true;
                sql.SqlStatement = @"select min(dml_date) min_dml_date, max(dml_date) max_dml_date
                from shipments_log
                where shipment_id = " + _shipmentId;
                bool Success = sql.Execute() && sql.Reader!=null && sql.Reader.Read() && sql.Reader.HasRows;
                if (Success)
                {                   
                    dtBegin.Value = sql.Reader.IsDBNull(0) ? DateTime.Now: sql.Reader.GetDateTime(0);  
                    dtEnd.Value = sql.Reader.IsDBNull(1) ? DateTime.Now:sql.Reader.GetDateTime(1);
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

            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Load(sql.Reader);

            tblShipmentLog.AutoGenerateColumns = false;
            tblShipmentLog.DataSource = ds.Tables[0];
            sql.Disconnect();
            CalcRowColor();
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
    }
}
