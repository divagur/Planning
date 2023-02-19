using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.DataLayer;
using Excel = Microsoft.Office.Interop.Excel;

namespace Planning
{
    public partial class frmVolumeCalc : Form
    {
        List<LVOrder> LVOrders = new List<LVOrder>();
        BindingList<VolumeCalcProduct> bindingListProduct;
        Settings _settings;
        BindingSource sourceProduct;
        VolumeCalc volumeCalc;
        int? DepositorLVId;
        public frmVolumeCalc(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            LoadTemplate();

        }

        private void LoadTemplate()
        {
            cmbConstantTemplate.Items.Clear();

            foreach (var item in DataService.setting.VolumeCalcTemplate)
            {
                cmbConstantTemplate.Items.Add(item.Name);
            }
        }


        private void InitCalc(List<VolumeCalcProduct> listProduct)
        {
            txtWeightOrder.Text = "0.0";
            txtVolumeOrder.Text = "0.0";
            txtPalletAmountOrder.Text = "0.0";

            txtWeightTotal.Text = "0.0";
            txtVolumeTotal.Text = "0.0";
            txtPalletAmountTotal.Text = "0.0";
            txtHeightTotal.Text = "0.0";

            volumeCalc = new VolumeCalc();

            volumeCalc.volumeCalcProducts = listProduct;


            bindingListProduct = new BindingList<VolumeCalcProduct>(volumeCalc.volumeCalcProducts);
            sourceProduct = new BindingSource(bindingListProduct, null);
            tblProducts.AutoGenerateColumns = false;
            tblProducts.DataSource = sourceProduct;
        }
        private void ExportProduct()
        {
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();

            ExcelPrint excel = new ExcelPrint("");
            wait.SetRange(0, volumeCalc.volumeCalcProducts.Count);
            wait.SetPosition(1);
            wait.SetText("Экспорт рассчета: вывод данных....");

            object[,] printRow = new object[1, 9];

            int rowIdx = 0;

            printRow[0, 0] = "";
            printRow[0, 1] = "Кол-во штук";
            printRow[0, 2] = "Вес, шт";
            printRow[0, 3] = "Объем, шт";
            printRow[0, 4] = "Вес, общий";
            printRow[0, 5] = "Объем, общий";
            printRow[0, 6] = "Высота";
            printRow[0, 7] = "Длина";
            printRow[0, 8] = "Ширина";
            excel.SetRowValues(1, rowIdx + 1, 9, printRow);
            rowIdx++;
            
            foreach (var item in volumeCalc.volumeCalcProducts)
            {
                
                printRow[0, 0] = (string)item.prdName;
                /*printRow[0, 1] = item.Qty.ToString("# ##0.00");
                printRow[0, 2] = item.Weight.ToString("# ##0.00");
                printRow[0, 3] = item.Volume.ToString("# ##0.00");
                printRow[0, 4] = item.TotalWeight.ToString("# ##0.00");
                printRow[0, 5] = item.TotalWeight.ToString("# ##0.00");
                printRow[0, 6] = item.Height.ToString("# ##0.00");
                printRow[0, 7] = item.Length.ToString("# ##0.00");
                printRow[0, 8] = item.Width.ToString("# ##0.00");
                */

                printRow[0, 1] = item.Qty;
                printRow[0, 2] = item.Weight;
                printRow[0, 3] = item.Volume;
                printRow[0, 4] = item.TotalWeight;
                printRow[0, 5] = item.TotalWeight;
                printRow[0, 6] = item.Height;
                printRow[0, 7] = item.Length;
                printRow[0, 8] = item.Width;


                excel.SetRowValues(1, rowIdx+1, 9, printRow);
                excel.SetCellFontStyle(1, 1, 1, 9, 1, true, false, false);
                rowIdx++;
                wait.SetPosition(rowIdx);
            }

            excel.SetCellsFormat(1, 1, 1, 1, rowIdx, "@");

          Excel.Range range;

            range = excel.SelectCells(1, 1, 1, 9, rowIdx);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            excel.SetValue(1, 11, 1, "Вес заказа");
            excel.SetValue(1, 12, 1, "Объем заказа");
            excel.SetValue(1, 13, 1, "Кол-во паллет в заказе");

            excel.SetValue(1, 11, 2, volumeCalc.volumeCalcResult.OrderWeight);
            excel.SetValue(1, 12, 2, volumeCalc.volumeCalcResult.OrderVolume);
            excel.SetValue(1, 13, 2, volumeCalc.volumeCalcResult.OrderPalleteAmount);

            excel.SetCellFontStyle(1, 11, 1, 13, 1, true, false, false);
            //			

            excel.SetValue(1, 11, 3, "1. Вес общий:");
            excel.SetValue(1, 12, 3, "2. Объем общий:");
            excel.SetValue(1, 13, 3, "3. Кол-во паллет:");
            excel.SetValue(1, 14, 3, "4. Высота:");

            excel.SetValue(1, 11, 4, volumeCalc.volumeCalcResult.TotalWeight);
            excel.SetValue(1, 12, 4, volumeCalc.volumeCalcResult.TotalVolume);
            excel.SetValue(1, 13, 4, volumeCalc.volumeCalcResult.PalleteAmount);
            excel.SetValue(1, 14, 4, volumeCalc.volumeCalcResult.HeightTotal);

            excel.SetCellFontStyle(1, 11, 3, 14, 3, true, false, false);

            range = excel.SelectCells(1, 11, 1, 14, 4);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;


            excel.SetValue(1, 17, 1, "Вес паллета");
            excel.SetValue(1, 17, 2, "Высота паллета");
            excel.SetValue(1, 17, 3, "Объем паллета");
            excel.SetValue(1, 17, 4, "Габариты паллета");

            excel.SetValue(1, 18, 1, volumeCalc.PalletWeight);
            excel.SetValue(1, 18, 2, volumeCalc.PalletHeight);
            excel.SetValue(1, 18, 3, volumeCalc.PalletVolume);
            excel.SetValue(1, 18, 4, volumeCalc.PalleteDimensions);

            excel.SetCellFontStyle(1, 17, 1, 17, 4, true, false, false);

            range = excel.SelectCells(1, 17, 1, 18, 4);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            for (int i = 0; i < 18; i++)
            {
                excel.SetColumnAutoFit(1, i + 1);
            }

            excel.Visible = true;
            wait.Close();

        }


        private void ImportProduct()
        {
            string importFileName = "";
            if (openFileImport.ShowDialog() == DialogResult.OK)
            {
                importFileName = openFileImport.FileName;

                if (importFileName == String.Empty)
                {
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelBook = null;
                try
                {
                    excelBook = excelApp.Workbooks.Open(importFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при импорте", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                Excel._Worksheet excelSheet = excelBook.Sheets[1];
                Excel.Range excelRange = excelSheet.UsedRange;
                Dictionary<String, decimal> dictProduct = new Dictionary<string, decimal>();
                bool Success = true;
                
                int startCol = Math.Min(_settings.volumeCalcParams.ImportColVendorCode, Math.Min(_settings.volumeCalcParams.ImportColName, _settings.volumeCalcParams.ImportColAmount));
                int endCol = Math.Max(_settings.volumeCalcParams.ImportColVendorCode, Math.Max(_settings.volumeCalcParams.ImportColName, _settings.volumeCalcParams.ImportColAmount));
                
                int rowIdx = _settings.volumeCalcParams.ImportStartRow;
                while (Success)
                {
                    Excel.Range cellFrom = (Excel.Range)excelSheet.Cells[rowIdx, startCol];
                    Excel.Range cellTo = (Excel.Range)excelSheet.Cells[rowIdx, endCol];
                    var arrData = (object[,])excelSheet.get_Range(cellFrom, cellTo).Value;
                    if (arrData[1, _settings.volumeCalcParams.ImportColVendorCode] == null)
                    {
                        break;
                    }
                    string vendorCode = arrData[1,_settings.volumeCalcParams.ImportColVendorCode].ToString();
                    
                    string AmountString = arrData[1, _settings.volumeCalcParams.ImportColAmount].ToString();
                    decimal Amount = decimal.Parse(AmountString);

                    if (!dictProduct.ContainsKey(vendorCode))
                    {
                        dictProduct.Add(vendorCode, Amount);
                    }
                    rowIdx++;

                }


                int LVDepId = 59;
                var codes = dictProduct.Keys.ToList();
                List<VolumeCalcProduct> listProduct = VolumeCalcProduct_Manager.GetList(LVDepId, codes);
                foreach (var product in listProduct)
                {
                    if (dictProduct.ContainsKey(product.prdCode))
                    {
                        product.Qty = dictProduct[product.prdCode];
                    }
                }
                InitCalc(listProduct);

            }
        }
        private bool IsProductEmpty()
        {
            return volumeCalc == null || volumeCalc.volumeCalcProducts == null || volumeCalc.volumeCalcProducts.Count == 0;
        }
        private void btnChooseOrder_Click(object sender, EventArgs e)
        {
            
            frmSelectOrders frmSelectOrd = new frmSelectOrders(LVOrders);

            

            if (frmSelectOrd.ShowDialog() == DialogResult.OK)
            {
               

                if (LVOrders == null || LVOrders.Count == 0)
                    return;

                int? LVDepId = LVOrders.First().DepLVID;

               
                InitCalc(VolumeCalcProduct_Manager.GetList(LVDepId, LVOrders));
                /*
                volumeCalc = new VolumeCalc();

                volumeCalc.volumeCalcProducts = product_Manager.GetList(LVDepId, LVOrders);
               

                bindingListProduct = new BindingList<VolumeCalcProduct>(volumeCalc.volumeCalcProducts);
                sourceProduct = new BindingSource(bindingListProduct, null);
                tblProducts.AutoGenerateColumns = false;
                tblProducts.DataSource = sourceProduct;
                */
            }
            UptadeToolBar();
        }


        private void btnCalc_Click(object sender, EventArgs e)
        {
            volumeCalc.PalletWeight = decimal.Parse(txtPalletWeight.Text);
            volumeCalc.PalletHeight = decimal.Parse(txtPalletHeigth.Text);
            volumeCalc.PalletVolume = decimal.Parse(txtPalletVolume.Text);
            volumeCalc.PalleteDimensions = decimal.Parse(txtPalletDimension.Text);


            if (volumeCalc.Calculate())
            {
                txtWeightOrder.Text = volumeCalc.volumeCalcResult.OrderWeight.ToString("# ##0.00");
                txtVolumeOrder.Text = volumeCalc.volumeCalcResult.OrderVolume.ToString("# ##0.00");
                txtPalletAmountOrder.Text = volumeCalc.volumeCalcResult.OrderPalleteAmount.ToString("# ##0.00");

                txtWeightTotal.Text = volumeCalc.volumeCalcResult.TotalWeight.ToString("# ##0.00");
                txtVolumeTotal.Text = volumeCalc.volumeCalcResult.TotalVolume.ToString("# ##0.00");
                txtPalletAmountTotal.Text = volumeCalc.volumeCalcResult.PalleteAmount.ToString("# ##0.00");
                txtHeightTotal.Text = volumeCalc.volumeCalcResult.HeightTotal.ToString("# ##0.00");
            }
            else
            {
                MessageBox.Show(volumeCalc.volumeCalcResult.ErrorMessage,"Ошибка рассчета");
            }

        }

        private void UptadeToolBar()
        {
            btnCalc.Enabled = !IsProductEmpty();
            btnExport.Enabled = !IsProductEmpty();
        }

        private void txtPalletWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 46 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportProduct();
            UptadeToolBar();
        }

        private void cmbConstantTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConstantTemplate.Text == "")
                return;
            
            VolumeCalcConstant item = DataService.setting.VolumeCalcTemplate.Find(i => i.Name == cmbConstantTemplate.Text);
            if (item !=null)
            {
                txtPalletWeight.Text = item.PalletWeight.ToString();
                txtPalletHeigth.Text = item.PalletHeight.ToString();
                txtPalletVolume.Text = item.PalletVolume.ToString();
                txtPalletDimension.Text = item.PalleteDimensions.ToString();
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            if (cmbConstantTemplate.Text == "")
            {
                MessageBox.Show("Имя шаблона не может быть пустым");
                cmbConstantTemplate.Focus();
                return;
            }
                

            VolumeCalcConstant item = DataService.setting.VolumeCalcTemplate.Find(i => i.Name == cmbConstantTemplate.Text);
            if (item ==null)
            {
                item = new VolumeCalcConstant();
                item.Name = cmbConstantTemplate.Text;
                DataService.setting.VolumeCalcTemplate.Add(item);

            }

            
            item.PalletWeight = decimal.Parse(txtPalletWeight.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            item.PalletHeight = decimal.Parse(txtPalletHeigth.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            item.PalletVolume = decimal.Parse(txtPalletVolume.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            item.PalleteDimensions = decimal.Parse(txtPalletDimension.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            DataService.settingsHandle.SetParamList<VolumeCalcConstant>("VolumeCalcTemplates", "Template", DataService.setting.VolumeCalcTemplate);

            LoadTemplate();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportProduct();
        }
    }
}
