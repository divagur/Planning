using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class ShipmentMainAdapter : IDataAdaper
    {
        public string Table => "";

        public string GetSaveSql(EditState editState)
        {
            throw new NotImplementedException();
        }

        public string GetSelectItemSql()
        {
           
            return "SP_PL_MainQueryP";
        }
    }
}