using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PlanningTasks.DataLayer
{
    [Table("depositors")]
    public class Depositor:BaseObject
    {
        
        public string Name { get; set; }
        public string LvBase { get; set; }
        public Nullable<int> LvId { get; set; }
    }
}
