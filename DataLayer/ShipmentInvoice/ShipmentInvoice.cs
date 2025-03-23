using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentInvoice:BaseDataItem
    {
        int? _shpId;
		DateTime? _createDate;
		DateTime? _actualDate;
		string _number;
		string _invoiceType;
        string _customsCode;
        string _supplierCode;
        string _recipientCode;
		string _deliveryType;
        string _containerNumber;
        string _truckNumber;
        string _trailerNumber;
        string _driver;
        int _supplierDeliveryDay;
        string _status;
        string _error;
        public int? ShpId
        {
            get => _shpId;
            set
            {
                if (!_shpId.Equals(value))
                {
                    _shpId = value;
                    Edit();

                }
            }
        }
        public DateTime? CreateDate
        {
            get => _createDate;
            set
            {
                if (!_createDate.Equals(value))
                {
                    _createDate = value;
                    Edit();

                }
            }
        }
        public DateTime? ActualDate
        {
            get => _actualDate;
            set
            {
                if (!_actualDate.Equals(value))
                {
                    _actualDate = value;
                    Edit();

                }
            }
        }
        public string Number
        {
            get => _number;
            set
            {
                //if (!_number.Equals(value))
                //{
                    _number = value;
                    Edit();

                //}
            }
        }
        public string InvoiceType
        {
            get => _invoiceType;
            set
            {
                //if (!_invoiceType.Equals(value))
                //{
                    _invoiceType = value;
                    Edit();

                //}
            }
        }
        public string CustomsCode
        {
            get => _customsCode;
            set
            {
                if (_customsCode == null || !_customsCode.Equals(value))
                {
                    _customsCode = value;
                    Edit();

                }
            }
        }

        public string SupplierCode
        {
            get => _supplierCode;
            set
            {
                if (_supplierCode == null || !_supplierCode.Equals(value))
                {
                    _supplierCode = value;
                    Edit();

                }
            }
        }

        public string RecipientCode
        {
            get => _recipientCode;
            set
            {
                if (_recipientCode ==null || !_recipientCode.Equals(value))
                {
                    _recipientCode = value;
                    Edit();

                }
            }
        }
        public string DeliveryType
        {
            get => _deliveryType;
            set
            {
                //if (!_deliveryType.Equals(value))
                //{
                    _deliveryType = value;
                    Edit();

                //}
            }
        }
        public string ContainerNumber
        {
            get => _containerNumber;
            set
            {
                if (_containerNumber == null || !_containerNumber.Equals(value))
                {
                _containerNumber = value;
                Edit();

                }
            }
        }
        public string TruckNumber
        {
            get => _truckNumber;
            set
            {
                if (_truckNumber == null || !_truckNumber.Equals(value))
                {
                    _truckNumber = value;
                    Edit();

                }
            }
        }
        public string TrailerNumber
        {
            get => _trailerNumber;
            set
            {
                if (_trailerNumber == null || !_trailerNumber.Equals(value))
                {
                    _trailerNumber = value;
                    Edit();

                }
            }
        }
        public string Driver
        {
            get => _driver;
            set
            {
                if (_driver == null || !_driver.Equals(value))
                {
                    _driver = value;
                    Edit();

                }
            }
        }
        public int SupplierDeliveryDay
        {
            get => _supplierDeliveryDay;
            set
            {
                if (!_supplierDeliveryDay.Equals(value))
                {
                    _supplierDeliveryDay = value;
                    Edit();

                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                //if (!_status.Equals(value))
                //{
                    _status = value;
                    Edit();

                //}
            }
        }
        public string Error
        {
            get => _error;
            set
            {
                //if (!_error.Equals(value))
                //{
                    _error = value;
                    Edit();

                //}
            }
        }
    }
}
