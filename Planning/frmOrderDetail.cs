using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;

namespace Planning
{
    public partial class frmOrderDetail : Form
    {
        public frmOrderDetail(string OrdCode, int OrdId, int inOut, int DepId)
        {
            InitializeComponent();
            tblOrderDetail.AutoGenerateColumns = false;
            Populate(OrdId, inOut, DepId);
            Text = $"Детализация заказа {OrdCode}";
        }

        private void Populate(int ordId, int inOut, int depId)
        {
            OrderDetailItem_Manager orderDetailItem_Manager = new OrderDetailItem_Manager();
            
            tblOrderDetail.DataSource = orderDetailItem_Manager.GetOrderDetailItems(depId, inOut, ordId);


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonExportExcel_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                sl.SetCellValue("A1", "Код артикула");
                sl.SetCellValue("B1", "Описание");
                sl.SetCellValue("C1", "Количество");
                sl.SetColumnWidth(1,19);
                sl.SetColumnWidth(2,65);
                sl.SetColumnWidth(3,11);
                List<OrderDetailItem> data = (List<OrderDetailItem>)tblOrderDetail.DataSource;
                int i = 2;
                foreach (var item in data)
                {
                    
                    sl.SetCellValue(i,1, item.PrimaryCode);
                    sl.SetCellValue(i,2, item.ShortDescription);
                    sl.SetCellValue(i,3, item.Quantity);
                    i++;
                }

                sl.SaveAs(saveFileDialog.FileName);
            }
            
        }
    }
}
