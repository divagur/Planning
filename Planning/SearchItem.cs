using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class SearchItem
    {
        public int No { get; set; }
        public string Condition { get; set; } = "И";
        public string FieldName { get; set; }
        public string Operation { get; set; } = "=";
        public string Value { get; set; } = "";

        public string DBFieldName { get; set; } = "";
    
    }
}
