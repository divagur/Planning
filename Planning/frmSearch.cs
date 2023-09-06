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
    public partial class frmSearch : Form
    {
        List<SearchItem> searchItems = new List<SearchItem>();
        BindingList<SearchItem> bindingListSearchItems;
        BindingSource sourceSearchItems;
        DataTable ds = new DataTable();
        BackgroundWorker workerSearch;
        public frmSearch(DateTime beginDate)
        {
            InitializeComponent();
            Init();

            /*
            bindingListSearchItems = new BindingList<SearchItem>(searchItems);
            sourceSearchItems = new BindingSource(bindingListSearchItems, null);*/

            tblSearchField.AutoGenerateColumns = false;
            tblSearchField.DataSource = searchItems;
            dtEnd.Value = beginDate;

            dtBegin.Value = new DateTime(beginDate.Year, beginDate.Month, 1);
        }

        public void Init()
        {
            SearchItem item1 = new SearchItem();
            item1.No = 1;
            item1.Condition = "";
            item1.FieldName = "Код заказа";
            item1.DBFieldName = "lv_order_code";
            searchItems.Add(item1);

            SearchItem item2 = new SearchItem();
            item2.No = 2;
            item2.FieldName = "Ф.И.О. водителя";
            item2.Operation = "Содержит";
            item2.DBFieldName = "driver_fio";
            searchItems.Add(item2);

            SearchItem item3 = new SearchItem();
            item3.No = 3;
            item3.FieldName = "Клиент";
            item3.Operation = "Содержит";
            item3.DBFieldName = "cmp_ShortName";
            searchItems.Add(item3);

            //bindingListSearchItems = new BindingList<SearchItem>(searchItems);
            //sourceSearchItems = new BindingSource(bindingListSearchItems, null);

        }

        private string StringConditionToSql(string condition)
        {
            string sqlCondition = "";

            switch (condition)
            {
                case "И":
                    sqlCondition = "AND";
                    break;
                case "ИЛИ":
                    sqlCondition = "OR";
                    break;

                default:
                    break;
            }

            return sqlCondition;

        }
        private string SearchItemToSql(SearchItem item, bool useCondition)
        {
            string result = "";

            string sqlCondition = StringConditionToSql(item.Condition);
            string sqlOperatrion ="";

            

            switch (item.Operation)
            {
                case "=":
                case ">":
                case "<":
                    sqlOperatrion = $"{item.Operation} '{item.Value}'";
                    break;
                case "Содержит":
                    sqlOperatrion = $"like '%{item.Value}%'";
                    break;
                case "Между":
                    sqlOperatrion = $"between {item.Value} AND {item.Value}";
                    break;
                default:
                    break;
            }

            if (sqlOperatrion != "" && !String.IsNullOrEmpty(item.Value))
            {
                result =  $" {(useCondition? sqlCondition:String.Empty)} {item.DBFieldName} {sqlOperatrion}";
            }

            return result;
        }
        private string AssemblySqlCondition()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tblSearchField.RowCount; i++)
            {
                
                SearchItem item = searchItems.Find(s => s.No == i+1);
                if (item != null)
                {

                    item.Value = searchItems[i].Value; //tblSearchField.Rows[i].Cells["colValue"].Value.ToString();
                    sb.Append(SearchItemToSql(item, sb.Length > 0));
                }
            }

            return sb.ToString();
        }


        void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            string sqlAddConditioin = AssemblySqlCondition();
            DataSet dataSet = DataService.GetShipment(dtBegin.Value, dtEnd.Value, null, null, -1, sqlAddConditioin == "" ? null : sqlAddConditioin);




            if (dataSet == null)
                return;

            ds = dataSet.Tables[0].Clone();
            ds.Load(dataSet.Tables[0].CreateDataReader());

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                tblShipments.AutoGenerateColumns = false;
                tblShipments.DataSource = ds;
            }

            SetEndActionParam();
        }
        private void Search()
        {
            workerSearch = new BackgroundWorker();
            workerSearch.WorkerSupportsCancellation = true;
            workerSearch.DoWork += bw_DoWork;
            workerSearch.RunWorkerCompleted += bw_RunWorkerCompleted;
            SetStartActionParam();
            tblSearchField.EndEdit();
            workerSearch.RunWorkerAsync();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void tblSearchField_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());
        }
        private void SetStartActionParam()
        {
            picWork.Visible = true;
            tblSearchField.Cursor = Cursors.AppStarting;
            tblShipments.Cursor = Cursors.AppStarting;
            tbExportToExcel.Enabled = false;
            tbCancelSearch.Visible = true;
            tbSearch.Enabled = false;
        }

        private void SetEndActionParam()
        {
            tblSearchField.Cursor = Cursors.Default;
            tblShipments.Cursor = Cursors.Default;
            picWork.Visible = false;
            tbExportToExcel.Enabled = true;
            tbCancelSearch.Visible = false;
            tbSearch.Enabled = true;
        }
        private void tblSearchField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tblSearchField.Rows[tblSearchField.SelectedCells[0].RowIndex].Cells["colValue"].Value = null;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        //void ExcelUnloader_DoWork(object sender, DoWorkEventArgs e)
        private void tbExportToExcel_Click(object sender, EventArgs e)
        {
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();


            List<string> columnOrder = new List<string> {"ShpId","OrdId","ShpDate","SlotTime","InOut","OrdLVCode","OrdLVType","KlientName","OrderStatus","PrcReady","ShpComment","OrdComment","GateName","ShpSpecialCond","ShpDriverPhone","ShpDriverFio","TransportCompanyName","TransportTypeName","ShpVehicleNumber","ShpTrailerNumber","ShpAttorneyNumber",
                    "ShpAttorneyDate","ShpSubmissionTime","ShpStartTime", "ShpEndTimePlan","ShpEndTimeFact","ShpDelayReasonName", "ShpDelayComment", "DepCode", "ShpStampNumber" };
            int[] colNumber = new int[columnOrder.Count];
            Microsoft.Office.Interop.Excel.Range range;

            wait.SetText("Выгрузка результатов поиска....");
           // Excel.Application excelApp = new Excel.Application();
            ExcelPrint excel = new ExcelPrint(null);

           // SqlDataReader dataRows = GetShipment(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);

            //SqlDataReader dataRows = GetShipment(edCurrDay.Value, null, null, null);

            //DataTable dt = new DataTable();
            
            //dt.Load(dataRows);


            wait.SetRange(0, ds.Rows.Count);
            wait.SetPosition(1);


            //Получим индексы колонок в резалсете


            List<DataGridViewColumn> visibleColumns = new List<DataGridViewColumn>();
            
            int visibleIdx = 0;
            for (int i = 0; i < tblShipments.ColumnCount; i++)
            {
                if (!tblShipments.Columns[i].Visible)
                    continue;
                visibleColumns.Add(tblShipments.Columns[i]);
                excel.SetValue(1, visibleIdx+1, 1, tblShipments.Columns[i].HeaderText);
                excel.SetColumnWidth(1, visibleIdx + 1, tblShipments.Columns[i].Width);

                visibleIdx++;
            }

            var headerRange = excel.SelectCells(1, 1, 1, visibleColumns.Count, 1);
            headerRange.WrapText = true;
            headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            headerRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            string[,] printRow = new string[1, visibleColumns.Count];
            int resultRowCount = 0;

            for (int rowIdx = 0; rowIdx < tblShipments.RowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < visibleColumns.Count; colIdx++)
                {
                    string cellValue = (tblShipments[visibleColumns[colIdx].Index, rowIdx].Value).ToString();
                    
                    if (tblShipments.Columns[visibleColumns[colIdx].Index].DataPropertyName == "ShpDate")
                    {
                        cellValue = cellValue.Substring(0, 10);
                    }

                    printRow[0, colIdx] = cellValue;
                }


                excel.SetRowValues(1, resultRowCount+2, visibleColumns.Count, printRow);                
                wait.SetPosition(resultRowCount++);

            }

            
            range = excel.SelectCells(1, 1, 1, visibleColumns.Count, resultRowCount);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.Visible = true;
            wait.Close();

        }


        private void ExcelUnloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            SetEndActionParam();
        }

       
        private void tbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tbCancelSearch_Click(object sender, EventArgs e)
        {
            workerSearch.CancelAsync();
            SetEndActionParam();
        }
    }
}
