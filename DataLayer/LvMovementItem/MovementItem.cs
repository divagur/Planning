using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class LvMovementItem: BaseDataItem
    {
        //int? _lVID;
        string _lVCode;
        string _lVStatus;
        DateTime? _expDate;
        string _company;
        DateTime? _inputDate;
        int? _depLVID;
        string _depCode;

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
        public DateTime? InputDate
        {
            get => _inputDate;
            set
            {
                if (!_inputDate.Equals(value))
                {
                    _inputDate = value;
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
        public string DepCode
        {
            get => _depCode;
            set
            {
                if (_depCode == null || !_depCode.Equals(value))
                {
                    _depCode = value;
                    Edit();

                }
            }
        }
    }
}
