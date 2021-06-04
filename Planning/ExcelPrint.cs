using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        
        private const int LOGPIXELSX = 88;
        private const int LOGPIXELSY = 90;
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();
        
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private void CreateApp()
        {
            _app = new Excel.Application();
            _app.SheetsInNewWorkbook = 1;
            _app.Workbooks.Add(_template == null ? Type.Missing : _template);
            _workbooks = _app.Workbooks;
            _workbook = _workbooks[1];


        }
        private int GetDPI(int nIndex)
        {
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetDC(hwnd);
            int result = GetDeviceCaps(hdc, nIndex);

            ReleaseDC(hwnd, hdc);
            return result;
        }
        private double PixelToPoint(int Pixel,int nIndex)
        {
            int currentDPI = GetDPI(nIndex);

            return Pixel / Math.Round(currentDPI * 7.33 / 96.0);
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

        public void SetValues(int Sheet, int ColFrom, int RowFrom, int ColTo, int RowTo, object[,] Values)
        {
            Excel.Range printRange = (Excel.Range)_worksheet.Cells[RowFrom, ColFrom];
            printRange = printRange.Resize[RowTo, ColTo];
            printRange.Value = Values;

        }
        public void SetRowValues(int Sheet, int Row, int ColCount, object[,] Values)
        {
            // _workbook.Worksheets[Sheet].Range[Row, 1].Resize[Row, ColCount].Value = Values;
            SelectCells(Sheet, 1, Row, ColCount, Row).Value = Values;
          
            //printRange.Value = Values;
        }

        public void SetColumnWidth(int Sheet, int Col, int cWidth)
        {
            Excel.Worksheet worksheet  = (Excel.Worksheet)_sheets.get_Item(Sheet);
            //Excel.Range range = worksheet.Columns[1,Col];//, System.Type.Missing];
            Excel.Range range = (Excel.Range)_worksheet.Cells[1, Col];
            
            range.EntireColumn.ColumnWidth = PixelToPoint(cWidth, LOGPIXELSY) +1;
        }
        public void SetRowHeight(int Sheet, int Row, int rHeight)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)_sheets.get_Item(Sheet);
            //Excel.Range range = worksheet.Columns[1,Col];//, System.Type.Missing];
            Excel.Range range = (Excel.Range)_worksheet.Cells[Row, 1];

            range.Rows.RowHeight = rHeight*0.75;
        }
    }
}
