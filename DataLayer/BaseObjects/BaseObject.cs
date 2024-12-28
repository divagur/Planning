using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class BaseObject
    {
        public int Id { get; set; }

        public EditState State { get; set; }
    }
}
