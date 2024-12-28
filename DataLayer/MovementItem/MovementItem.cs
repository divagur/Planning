using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks.DataLayer
{
    public class MovementItem: BaseDataItem
    {
        public int MovementId { get; set; }
        public int DepositorId { get; set; }
        public int TklLVID { get; set; }
    }
}
