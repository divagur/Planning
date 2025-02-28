using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class LvAttr: BaseDataItem
    {
        public Nullable<bool> LvaIn { get; set; }
        public Nullable<int> LvaAttrLvId { get; set; }
        public Nullable<bool> LvaUseOrdAttr { get; set; }
        public string LvaDB { get; set; }
        public string LvaField { get; set; }
        public Nullable<int> PlDepId { get; set; }
        public Nullable<int> PlElemId { get; set; }
        public Nullable<int> she_id { get; set; }
    }
}
