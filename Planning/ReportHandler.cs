using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Planning
{
    public static class ReportHandler
    {

        public static void PrintShipmentIn(DataLayer.ShipmentMain shipmentMain, string TemplatePath)
        {
            Excel.Range range;

            DataLayer.ShipmentRepository shipmentRepository = new DataLayer.ShipmentRepository();
            DataLayer.Shipment shipment = shipmentRepository.GetById(shipmentMain.ShpId);

            DataLayer.ShipmentOrderRepository shipmentOrderRepository = new DataLayer.ShipmentOrderRepository();
            List<DataLayer.ShipmentOrder> shipmentOrders = shipmentOrderRepository.GetShipmentOrders(shipmentMain.ShpId);
            if (shipment == null)
            {
                return;
            }

            if (shipmentOrders == null)
            {
                MessageBox.Show("Отгрузка не содержит ни одного заказа. Печать не возможна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filter = "ShpId = " + shipmentMain.ShpId.ToString();           
           
            ExcelPrint excel = new ExcelPrint(TemplatePath);

            //Соберем заказы
            string orderLVCode = String.Join("/", shipmentOrders.Select(o => o.LvOrderCode).ToArray());
            //Штрихкод 
            excel.SetValue(1, 2, 1, "*" + shipmentMain.ShpId.ToString() + "*");
            //Прибыл по плану
            excel.SetValue(1, 2, 6, shipmentMain.ShpDate.ToString().Substring(0, 10) + " " + shipmentMain.SlotTime);
            //Прибыл по факту
            excel.SetValue(1, 2, 7, shipmentMain.ShpSubmissionTime);
            //ФИО
            excel.SetValue(1, 2, 8, shipmentMain.ShpDriverFio);
            //№ машины
            string trailerNumber = shipmentMain.ShpTrailerNumber.ToString() != "" ? "/" + shipmentMain.ShpTrailerNumber : "";
            excel.SetValue(1, 2, 9, shipmentMain.ShpVehicleNumber + trailerNumber);
            //№ телефона
            excel.SetValue(1, 2, 10, shipmentMain.ShpDriverPhone);
            //№ номер накладной
            //printRows[0]["OrdLVCode"]
            excel.SetValue(1, 2, 11, orderLVCode);
            //№ ворот
            excel.SetValue(1, 2, 12, shipmentMain.GateName);
            //Время постановки на ворота	
            excel.SetValue(1, 2, 13, shipmentMain.ShpStartTime);
            //№ пломбы
            //excel.SetValue(1, 2, 12, printRows[0]["ShpStampNumber"]);
            //Количество паллет
            int? pallentsCount = shipmentOrders[0].PalletAmount;
            
            excel.SetValue(1, 2, 14, pallentsCount);
            //Убыл: дата, время
            excel.SetValue(1, 2, 15, shipmentMain.ShpEndTimeFact);

            range = excel.SelectCells(1, 1, 1, 1, 1);
            range.Activate();

            excel.Visible = true;
            
        }
        public static void PrintShipmentOut(DataLayer.ShipmentMain shipmentMain, string TemplatePath)
        {
            Excel.Range range;

            DataLayer.ShipmentRepository shipmentRepository = new DataLayer.ShipmentRepository();
            DataLayer.Shipment shipment = shipmentRepository.GetById(shipmentMain.ShpId);

            DataLayer.ShipmentOrderRepository shipmentOrderRepository = new DataLayer.ShipmentOrderRepository();
            List<DataLayer.ShipmentOrder> shipmentOrders = shipmentOrderRepository.GetShipmentOrders(shipmentMain.ShpId);
            if (shipment == null)
            {
                return;
            }


            ExcelPrint excel = new ExcelPrint(TemplatePath);
            //Код отгрузки
            excel.SetValue(1, 5, 2, "*PL" + shipmentMain.ShpId + " *");
            excel.SetValue(1, 5, 3, "PL" + shipmentMain.ShpId);
            //Прибыл по плану
            excel.SetValue(1, 3, 6, shipmentMain.ShpDate.ToString().Substring(0, 10) + " " + shipmentMain.SlotTime);
            //Прибыл по факту
            excel.SetValue(1, 3, 7, shipmentMain.ShpSubmissionTime);
            //ФИО
            excel.SetValue(1, 3, 8, shipmentMain.ShpDriverFio);
            //№ машины
            string trailerNumber = shipmentMain.ShpTrailerNumber != "" ? "/" + shipmentMain.ShpTrailerNumber : "";
            excel.SetValue(1, 3, 9, shipmentMain.ShpVehicleNumber + trailerNumber);
            //№ телефона
            excel.SetValue(1, 3, 10, shipmentMain.ShpDriverPhone);
            //№ ворот	
            excel.SetValue(1, 3, 11, shipmentMain.GateName);
            //Время постановки на ворота	
            excel.SetValue(1, 3, 12, shipmentMain.ShpStartTime);
            //№ пломбы
            excel.SetValue(1, 3, 13, shipmentMain.ShpStampNumber);
            //Время окончание загрузки
            excel.SetValue(1, 3, 14, shipmentMain.ShpEndTimePlan);
            //Убыл: дата, время
            excel.SetValue(1, 3, 15, shipmentMain.ShpEndTimeFact);

            //for (int i = 0; i < printRows.Count(); i++)
            int i = 0;
            foreach (var item in shipmentOrders)
            {
                excel.SetValue(1, 1, 17 + i + 1, item.LvOrderCode);
                excel.SetValue(1, 2, 17 + i++ + 1, shipmentMain.KlientName);
            }

            int rowCount = shipmentOrders.Count();
            range = excel.SelectCells(1, 1, 17, 1, 17 + rowCount);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            range = excel.SelectCells(1, 2, 17, 2, 17 + rowCount);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            range = excel.SelectCells(1, 1, 18, 6, 18 + rowCount - 1);


            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.EntireRow.Font.Bold = false;
            range.Font.Size = 11;
            range = excel.SelectCells(1, 1, 16, 6, 18 + rowCount - 1);

            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            excel.Merge(1, 1, 17 + rowCount + 2, 1, 17 + rowCount + 3);
            range = excel.SelectCells(1, 1, 17 + rowCount + 2, 2, 17 + rowCount + 2);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            range.WrapText = true;
            excel.SetValue(1, 1, 17 + rowCount + 2, "Комментарии к отгрузке:");


            int commentRow = 17 + rowCount + 2;
            if (shipment.IsCourier == true)
            {
                range = excel.SelectCells(1, 2, commentRow, 6, commentRow + 1);
                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 18;
                range.Font.Color = Color.Red;
                range.Interior.Color = Color.Yellow;
                excel.SetValue(1, 2, commentRow, "Необходимо прикрепить комплект документов к грузу");
                commentRow += 2;
            }

            range = excel.SelectCells(1, 2, commentRow, 6, commentRow + 2);
            range.Merge();
            range.Font.Bold = false;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            range.WrapText = true;
            excel.SetValue(1, 2, commentRow, shipmentMain.ShpComment);

            range = excel.SelectCells(1, 1, 17 + rowCount + 2, 6, 17 + rowCount + 6);
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            range = excel.SelectCells(1, 1, 1, 1, 1);
            range.Activate();

            excel.Visible = true;
        }
     }
}
