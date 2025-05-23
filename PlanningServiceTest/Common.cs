﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataLayer;

namespace PlanningServiceTest
{
    public static class Common
    {

        public static void AddEventToLog(string eventLog, string descr)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "PlanningServieLog.txt"), true))
            {
                writer.WriteLine(String.Format("[{0}][{1}]: {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), eventLog, descr));
                writer.Flush();
            }
        }

        public static int? GetWarehouseId(string WarehouseCode, string connectionString)
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(connectionString);
            Warehouse warehouse = warehouseRepository.GetByCode(WarehouseCode);
            return warehouse == null ? null : (int?)warehouse.Id;
        }

        public static int? GetTransportViewId(string TransportViewName, string connectionString)
        {
            TransportViewRepository transportViewRepository = new TransportViewRepository(connectionString);
            TransportView transportView = transportViewRepository.GetByNameOrCreate(TransportViewName);
            return transportView.Id;
        }
        public static int? GetSupplierId(string SupplierCode, string connectionString)
        {
            SupplierRepository supplierRepository = new SupplierRepository(connectionString);
            Supplier supplier = supplierRepository.GetByCode(SupplierCode);
            return supplier == null ? null : (int?)supplier.Id;
        }
    }
}
