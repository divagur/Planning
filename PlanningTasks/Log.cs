using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks
{
    static class Log
    {
        public static void AddErrorEvent(string EventDecr)
        {
            if (!File.Exists("Log.txt"))
            {
                File.Create("Log.txt");
            }
                      
            List<string> lines = File.ReadLines("Log.txt").ToList();
            lines.Add($"![{DateTime.Now}]:{EventDecr}");
            File.WriteAllLines("Log.txt", lines);
        }
    }
}
