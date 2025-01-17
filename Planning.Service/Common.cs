using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
