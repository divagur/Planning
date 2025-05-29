using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentOrderLog:BaseDataItem
    {
        string _dmlType;
        DateTime? _dmlDate;
        string _dmlUserName;
        string _dmlCompName;
        int? _shipmentOrderId;
        string _orderId;
        int? _shipmentId;
        string _orderType;
        string _comment;
        bool? _isBinding;
        int? _manualLoad;
        int? _manualUnload;
        int? _palletAmount;
        int? _bindingId;
        int? _lvOrderId;
        string _lvOrderCode;
        int? _shippingPlacesNumber;
        decimal? _orderWeight;
        bool? _isEdm;

        public string DmlType
        {
            get => _dmlType;
            set
            {
                if (_dmlType == null || !_dmlType.Equals(value))
                {
                    _dmlType = value;
                    Edit();

                }
            }
        }
        public DateTime? DmlDate
        {
            get => _dmlDate;
            set
            {
                if (!_dmlDate.Equals(value))
                {
                    _dmlDate = value;
                    Edit();

                }
            }
        }
        public string DmlUserName
        {
            get => _dmlUserName;
            set
            {
                if (_dmlUserName == null || !_dmlUserName.Equals(value))
                {
                    _dmlUserName = value;
                    Edit();

                }
            }
        }
        public string DmlCompName
        {
            get => _dmlCompName;
            set
            {
                if (_dmlCompName == null || !_dmlCompName.Equals(value))
                {
                    _dmlCompName = value;
                    Edit();

                }
            }
        }
        public int? ShipmentOrderId
        {
            get => _shipmentOrderId;
            set
            {
                if (!_shipmentOrderId.Equals(value))
                {
                    _shipmentOrderId = value;
                    Edit();

                }
            }
        }
        public string OrderId
        {
            get => _orderId;
            set
            {
                if (_orderId == null || !_orderId.Equals(value))
                {
                    _orderId = value;
                    Edit();

                }
            }
        }
        public int? ShipmentId
        {
            get => _shipmentId;
            set
            {
                if (!_shipmentId.Equals(value))
                {
                    _shipmentId = value;
                    Edit();

                }
            }
        }
        public string OrderType
        {
            get => _orderType;
            set
            {
                if (_orderType == null || !_orderType.Equals(value))
                {
                    _orderType = value;
                    Edit();

                }
            }
        }
        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment == null || !_comment.Equals(value))
                {
                    _comment = value;
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
        public int? BindingId
        {
            get => _bindingId;
            set
            {
                if (!_bindingId.Equals(value))
                {
                    _bindingId = value;
                    Edit();

                }
            }
        }
        public int? LvOrderId
        {
            get => _lvOrderId;
            set
            {
                if (!_lvOrderId.Equals(value))
                {
                    _lvOrderId = value;
                    Edit();

                }
            }
        }
        public string LvOrderCode
        {
            get => _lvOrderCode;
            set
            {
                if (_lvOrderCode == null ||  !_lvOrderCode.Equals(value))
                {
                    _lvOrderCode = value;
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
        public decimal? OrderWeight
        {
            get => _orderWeight;
            set
            {
                if (!_orderWeight.Equals(value))
                {
                    _orderWeight = value;
                    Edit();

                }
            }
        }
        public bool? IsEdm
        {
            get => _isEdm;
            set
            {
                if (!_isEdm.Equals(value))
                {
                    _isEdm = value;
                    Edit();

                }
            }
        }

    }
}
