using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentOrderPart:BaseDataItem
    {
        int? _shOrderId;
        int? _osLvId;
        string _osLvCode;
        bool? _isBinding;
        int? _manualLoad;
        int? _manualUnload;
        int? _palletAmount;
        int? _shippingPlacesNumber;
        decimal? _orderPartWeight;
        /*
                  
        [shipping_places_number], [order_part_weight]
         */
        public int? ShOrderId
        {
            get => _shOrderId;
            set
            {
                if (_shOrderId == null || !_shOrderId.Equals(value))
                {
                    _shOrderId = value;
                    Edit();

                }
            }
        }
        public int? OsLvId
        {
            get => _osLvId;
            set
            {
                if (!_osLvId.Equals(value))
                {
                    _osLvId = value;
                    Edit();

                }
            }
        }
        public string OsLvCode
        {
            get => _osLvCode;
            set
            {
                if (_osLvCode == null || !_osLvCode.Equals(value))
                {
                    _osLvCode = value;
                    Edit();

                }
            }
        }
        public bool? IsBinding
        {
            get => _isBinding;
            set
            {
                if (!_isBinding.Equals(value))
                {
                    _isBinding = value;
                    Edit();

                }
            }
        }
        public int? ManualLoad
        {
            get => _manualLoad;
            set
            {
                if (!_manualLoad.Equals(value))
                {
                    _manualLoad = value;
                    Edit();

                }
            }
        }
        public int? ManualUnload
        {
            get => _manualUnload;
            set
            {
                if (!_manualUnload.Equals(value))
                {
                    _manualUnload = value;
                    Edit();

                }
            }
        }
        public int? PalletAmount
        {
            get => _palletAmount;
            set
            {
                if (!_palletAmount.Equals(value))
                {
                    _palletAmount = value;
                    Edit();

                }
            }
        }       
        public int? ShippingPlacesNumber
        {
            get => _shippingPlacesNumber;
            set
            {
                if (!_shippingPlacesNumber.Equals(value))
                {
                    _shippingPlacesNumber = value;
                    Edit();

                }
            }
        }
        public decimal? OrderPartWeight
        {
            get => _orderPartWeight;
            set
            {
                if (!_orderPartWeight.Equals(value))
                {
                    _orderPartWeight = value;
                    Edit();

                }
            }
        }

    }
}
