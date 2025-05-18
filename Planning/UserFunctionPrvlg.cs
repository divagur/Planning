using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class UserFunctionPrvlg
    {
        public int? FunctionId { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public bool IsView { get; set; } = false;
        public bool IsAppend { get; set; } = false;
        public bool IsEdit { get; set; } = false;
        public bool IsDelete { get; set; } = false;
    }
}
