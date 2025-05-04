using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;

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
            
            //DataService.SQLGetIntValue("select pallet_amount from shipment_orders where id = " + (int)printRows[0]["OrdID"]);
            excel.SetValue(1, 2, 14, pallentsCount);
            //Убыл: дата, время
            excel.SetValue(1, 2, 15, shipmentMain.ShpEndTimeFact);

            range = excel.SelectCells(1, 1, 1, 1, 1);
            range.Activate();

            excel.Visible = true;
            
        }

    }
}
