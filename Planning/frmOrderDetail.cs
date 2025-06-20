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
        string _ordCode;
        public frmOrderDetail(string OrdCode, int? OrdId, int inOut, int? DepId)
        {
            InitializeComponent();
            tblOrderDetail.AutoGenerateColumns = false;
            Populate(OrdId, inOut, DepId);
            _ordCode = OrdCode;
            Text = $"Детализация заказа {OrdCode}";
        }

        private void Populate(int? ordId, int inOut, int? depId)
        {
            LvOrderDetailItemRepository lvOrderDetailItemRepository = new LvOrderDetailItemRepository();
            List<LvOrderDetailItem> orderDetailItems = lvOrderDetailItemRepository.GetOrderDetailItems(depId, inOut, ordId);

            //OrderDetailItem_Manager orderDetailItem_Manager = new OrderDetailItem_Manager();
            //List<OrderDetailItem> orderDetailItems = orderDetailItem_Manager.GetOrderDetailItems(depId, inOut, ordId);
            tblOrderDetail.DataSource = orderDetailItems;

            toolStripLabelRowCount.Text = String.Format("Всего кол-во строк - {0}, единиц товара - {1:f0}", orderDetailItems.Count, orderDetailItems.Sum(i => i.Quantity));
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
            saveFileDialog.FileName = $"заказ_{_ordCode}";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                sl.SetCellValue("A1", $"Код заказа - {_ordCode}");
                sl.SetCellValue("A2", "Код артикула");
                sl.SetCellValue("B2", "Описание");
                sl.SetCellValue("C2", "Количество");
                sl.SetColumnWidth(1,19);
                sl.SetColumnWidth(2,65);
                sl.SetColumnWidth(3,11);
                List<LvOrderDetailItem> data = (List<LvOrderDetailItem>)tblOrderDetail.DataSource;
                int i = 3;
                foreach (var item in data)
                {
                    
                    sl.SetCellValue(i,1, item.PrimaryCode);
                    sl.SetCellValue(i,2, item.ShortDescription);
                    sl.SetCellValue(i,3, (decimal)item.Quantity);
                    i++;
                }

                sl.SaveAs(saveFileDialog.FileName);
            }
            
        }
    }
}
