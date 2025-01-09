using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class ShipmentOrderDataAdapter : IDataAdaper
    {
        public string Table => "shipment_orders";

        public string GetSaveSql(EditState editState)
        {
            throw new NotImplementedException();
        }

        public string GetSelectItemSql()
        {
            throw new NotImplementedException();
        }
    }
}
