using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class LvMovementItemAdapter : IDataAdaper
    {
        public string Table => "";

        public string GetSaveSql(EditState editState)
        {
            throw new NotImplementedException();
        }

        public string GetSelectItemSql()
        {
            return "SP_PL_GetMovementItems";
        }
    }
}
