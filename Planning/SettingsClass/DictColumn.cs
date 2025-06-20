using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class DictColumn
    {
        public string Id;
        public string DataField;
        public string Title;
        public bool IsPK;
        public SqlDbType DataType;
        public int Length;
        public int Width = 100;
        public bool IsVisible;
        public List<string> ItemValues;
        public object DefaultValue;

    }
}
