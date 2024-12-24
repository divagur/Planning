using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks.DataLayer
{
    public class Movement:BaseObject
    {
        public System.DateTime MDate { get; set; }
        public Nullable<int> TimeSlotId { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Comment { get; set; }
        public Nullable<int> DelayReasonsId { get; set; }
        public string DelayComment { get; set; }
        public string Performer { get; set; }
        public bool DefCustomer { get; set; }
        public bool SpCondition { get; set; }
        public Nullable<System.TimeSpan> SpecialTime { get; set; }
    }
}
