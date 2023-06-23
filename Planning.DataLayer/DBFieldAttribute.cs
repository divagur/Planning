using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class DBFieldAttribute : Attribute
    {
        public string Field { get; }
        public DBFieldAttribute() { }
        public DBFieldAttribute(string field) => Field = field;
    }
}
