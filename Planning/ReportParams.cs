using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    class ReportParamItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class ReportParams
    {
        List<ReportParamItem> _reportParams = new List<ReportParamItem>();
        
        public string this[string index]
        {
            get
            {
                ReportParamItem item = _reportParams.FirstOrDefault(i => i.Name == index);
                return item ==null?"":item.Value;
            }
            set
            {
                ReportParamItem item = _reportParams.FirstOrDefault(i => i.Name == index);
                if (item == null)
                    _reportParams.Add(new ReportParamItem { Name = index, Value = value });
                else
                    item.Value = value;
            }
        }

    }
}
