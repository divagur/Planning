using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningServiceTest
{
    public class LogRow
    {
        public int RowIndex { get; set; }
        public string FileName { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public string FilePath { get; set; }
        public string Body { get; set; }

    }
}
