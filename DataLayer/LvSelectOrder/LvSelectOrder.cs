using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class LvSelectOrder: BaseDataItem
    {
        //int? _lVID;
        string _lVCode;
        string _lVStatus;
        DateTime? _expDate;
        string _company;
        int? _depLVID;
        int? _ostID;
        string _ostCode;
        bool? _isEDM;
        string _operatorComment;
        string _warehouseComment;

        public string LVCode
        {
            get => _lVCode;
            set 
            {
                if (_lVCode == null || !_lVCode.Equals(value))
                {
                    _lVCode = value;
                    Edit();

                }
            }
        }
        public string LVStatus
        {
            get => _lVStatus;
            set
            {
                if (_lVStatus == null || !_lVStatus.Equals(value))
                {
                    _lVStatus = value;
                    Edit();

                }
            }
        }
        public DateTime? ExpDate
        {
            get => _expDate;
            set
            {
                if (!_expDate.Equals(value))
                {
                    _expDate = value;
                    Edit();

                }
            }
        }
        public string Company
        {
            get => _company;
            set
            {
                if (_company == null || !_company.Equals(value))
                {
                    _company = value;
                    Edit();

                }
            }
        }
        public int? DepLVID
        {
            get => _depLVID;
            set
            {
                if (!_depLVID.Equals(value))
                {
                    _depLVID = value;
                    Edit();

                }
            }
        }
        public int? OstID
        {
            get => _ostID;
            set
            {
                if (!_ostID.Equals(value))
                {
                    _ostID = value;
                    Edit();

                }
            }
        }
        public string OstCode
        {
            get => _ostCode;
            set
            {
                if (_ostCode == null || !_ostCode.Equals(value))
                {
                    _ostCode = value;
                    Edit();

                }
            }
        }
        public bool? IsEDM
        {
            get => _isEDM;
            set
            {
                if (!_isEDM.Equals(value))
                {
                    _isEDM = value;
                    Edit();

                }
            }
        }
        public string OperatorComment
        {
            get => _operatorComment;
            set
            {
                if (_operatorComment == null || !_operatorComment.Equals(value))
                {
                    _operatorComment = value;
                    Edit();

                }
            }
        }
        public string WarehouseComment
        {
            get => _warehouseComment;
            set
            {
                if (_warehouseComment == null || !_warehouseComment.Equals(value))
                {
                    _warehouseComment = value;
                    Edit();

                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is LvSelectOrder selectOrder) return Id == selectOrder.Id;
            return false;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
