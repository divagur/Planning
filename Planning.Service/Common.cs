using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataLayer;

namespace Planning.Service
{
    public static class Common
    {
        public static string ServicePath = System.AppDomain.CurrentDomain.BaseDirectory;

        public static void AddEventToLog(string eventLog, string descr)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(ServicePath, "PlanningServieLog.txt"), true))
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

        public static int? GetTransportCompanyId(int TransportCompanyCode, string connectionString)
        {
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(connectionString);
            TransportCompany transportCompany = transportCompanyRepository.GetByCode(TransportCompanyCode);
            return transportCompany == null? null : (int?)transportCompany.Id;
        }

    }
}
