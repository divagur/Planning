using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.DataLayer;
namespace Planning
{

    public class LVOrderIdComparer : IEqualityComparer<LvSelectOrder>
    {
        public bool Equals(LvSelectOrder x, LvSelectOrder y)
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
        public int GetHashCode(LvSelectOrder obj)
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
