using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Planning
{
    class ExcelPrint
    {
        string _template;
        
        Excel.Application _app;
        private Excel.Workbooks _workbooks;
        private Excel.Workbook _workbook;
        private Excel.Sheets _sheets;
        private Excel.Worksheet _worksheet;
        private Excel.Range _cells;
        private void CreateApp()
        {
            _app = new Excel.Application();
            _app.SheetsInNewWorkbook = 1;
            _app.Workbooks.Add(_template == null ? Type.Missing : _template);
            _workbooks = _app.Workbooks;
            _workbook = _workbooks[1];


        }
        public ExcelPrint(string template)
        {
            _template = template;
            CreateApp();
        }
        public bool Visible
        {
            set
               {
                _app.Visible = value;
                _app.WindowState = Excel.XlWindowState.xlMaximized;
                }
        }

        public void SetValue(int Sheet, int Col,int Row, object Value)
        {
            /*
            _sheets = _workbook.Worksheets;
            _worksheet = (Excel.Worksheet)_sheets.get_Item(Sheet);
            _cells = (Excel.Range)_worksheet.Cells[Row, Col];
            */
            _cells = SelectCells(Sheet, Col, Row, Col, Row);
            _cells.Value2 = Value;

        }
       public Excel.Range SelectCells(int Sheet, int ColFrom, int RowFrom, int ColTo, int RowTo)
       {
            _sheets = _workbook.Worksheets;
            _worksheet = (Excel.Worksheet)_sheets.get_Item(Sheet);
            
            Excel.Range cellFrom = (Excel.Range)_worksheet.Cells[RowFrom, ColFrom];
            Excel.Range cellTo = (Excel.Range)_worksheet.Cells[RowTo, ColTo];
            return _worksheet.get_Range(cellFrom, cellTo);
       }
        public void SetBorder(int Sheet, int ColFrom, int RowFrom, int ColTo, int RowTo, Excel.XlLineStyle LineStyle )
        {
            SelectCells(Sheet,ColFrom, RowFrom, ColTo, RowTo).Borders.LineStyle = LineStyle;
        }

        public void Merge(int Sheet, int ColFrom, int RowFrom, int ColTo, int RowTo)
        {
            Excel.Range range = SelectCells(Sheet, ColFrom, RowFrom, ColTo, RowTo);
            range.Merge(Type.Missing);
        }
    }
}
