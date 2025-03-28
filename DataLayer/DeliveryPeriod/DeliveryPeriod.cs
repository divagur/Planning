using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DeliveryPeriod: BaseDataItem
    {
        int? _custPostId;
        int? _warehouseId;
        int _deliveryDay;

        public int? CustPostId
        {
            get => _custPostId;
            set
            {
                //if (!_code.Equals(value))
                //{
                _custPostId = value;
                    Edit();

                //}
            }
        }
        public int? WarehouseId
        {
            get => _warehouseId;
            set
            {
                //if (!_name.Equals(value))
                //{
                _warehouseId = value;
                    Edit();

                //}
            }
        }

        public int DeliveryDay
        {
            get => _deliveryDay;
            set
            {
                //if (!_descr.Equals(value))
                //{
                _deliveryDay = value;
                    Edit();

                //}
            }
        }

    }
}
