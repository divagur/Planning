using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public interface IItemPrivilege
    {
        void SetPrivilege(bool IsAppend, bool IsEdit, bool IsDelete);
    }
}
