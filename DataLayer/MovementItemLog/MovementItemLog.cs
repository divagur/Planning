using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class MovementItemLog: BaseDataItem
    {
        string _dmlType;
        DateTime? _dmlDate;
        string _dmlUserName;
        string _dmlCompName;
        int? _movementItemId;
        int? _movementId;
        int? _depositorId;
        int? _tklLVID;

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
        public int? MovementItemId
        {
            get => _movementItemId;
            set
            {

                if (_movementItemId == null || !_movementItemId.Equals(value))
                {
                    _movementItemId = value;
                    Edit();

                }
            }
        }
        public int? MovementId
        {
            get => _movementId;
            set
            {

                if (_movementId == null || !_movementId.Equals(value))
                {
                    _movementId = value;
                    Edit();

                }
            }
        }
        public int? DepositorId
        {
            get => _depositorId;
            set
            {

                if (_depositorId == null || !_depositorId.Equals(value))
                {
                    _depositorId = value;
                    Edit();

                }
            }
        }
        public int? TklLVID
        {
            get => _tklLVID;
            set
            {

                if (_tklLVID == null || !_tklLVID.Equals(value))
                {
                    _tklLVID = value;
                    Edit();

                }
            }
        }
    }
}
