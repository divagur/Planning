using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{

    public class LVOrderIdComparer : IEqualityComparer<LVOrder>
    {
        public bool Equals(LVOrder x, LVOrder y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.LVID == y.LVID;
        }
        public int GetHashCode(LVOrder obj)
        {
            if (obj == null)
            {
                return 0;
            }
            int IDHashCode = obj.LVID.GetHashCode();
            return IDHashCode; 
        }
    }


}
