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
		string _sourceCode;
		string _recipientCode;
		string _deliveryType;
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
        public string SourceCode
        {
            get => _sourceCode;
            set
            {
                //if (!_sourceCode.Equals(value))
                //{
                    _sourceCode = value;
                    Edit();

                //}
            }
        }
        public string RecipientCode
        {
            get => _recipientCode;
            set
            {
                //if (!_recipientCode.Equals(value))
                //{
                    _recipientCode = value;
                    Edit();

                //}
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
