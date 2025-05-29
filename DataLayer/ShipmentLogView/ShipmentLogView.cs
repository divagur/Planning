using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentLogView:BaseDataItem
    {

        int? _dmlId;
        string _dmlType;
        string _dmlTypeName;
        DateTime? _dmlDate;
        string _dmlUserName;
        string _dmlCompName;
        int? _shipmentId;
        TimeSpan? _slotTime;
	    DateTime? _sDate;
        string _sComment;
        string _oComment;
        string _gateName;
        bool? _spCondition;
        string _driverPhone;
        string _driverFio;
        string _vehicleNumber;
        string _trailerNumber;
        string _attorneyNumber;
        DateTime? _attorneyDate;
        DateTime? _submissionTime;
        DateTime? _startTime;
        DateTime? _endTime;
        DateTime? _leaveTime;
        string _delayReasonName;
        string _delayComment;
        int? _depositorId;
        bool? _isCourier;
        string _forwarderFio;
        string _stampNumber;
        string _attorneyIssued;
        bool? _sIn;
        bool? _isAddLv;
        string _transportCompanyName;
        string _transportTypeName;
        string _supplierName;
        string _customPostName;
        string _warehouseName;
        string _transportViewName;
        string _depositorName;
        int? _depLvId;
        string _depLvDb;
        int? _fontColor;
        int? _backgroundColor;
        int? _logNum;
        string _inOut;
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
        public string DmlTypeName
        {
            get => _dmlTypeName;
            set
            {
                if (_dmlTypeName == null || !_dmlTypeName.Equals(value))
                {
                    _dmlTypeName = value;
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
        public TimeSpan? SlotTime
        {
            get => _slotTime;
            set
            {
                if (!_slotTime.Equals(value))
                {
                    _slotTime = value;
                    Edit();

                }
            }
        }
        public DateTime? SDate
        {
            get => _sDate;
            set
            {
                if (!_sDate.Equals(value))
                {
                    _sDate = value;
                    Edit();

                }
            }
        }
        public string SComment
        {
            get => _sComment;
            set
            {
                if (_sComment == null || !_sComment.Equals(value))
                {
                    _sComment = value;
                    Edit();

                }
            }
        }
        public string OComment
        {
            get => _oComment;
            set
            {
                if (_oComment == null || !_oComment.Equals(value))
                {
                    _oComment = value;
                    Edit();

                }
            }
        }
        public string GateName
        {
            get => _gateName;
            set
            {
                if (_gateName ==null || !_gateName.Equals(value))
                {
                    _gateName = value;
                    Edit();

                }
            }
        }
        public bool? SpCondition
        {
            get => _spCondition;
            set
            {
                if (!_spCondition.Equals(value))
                {
                    _spCondition = value;
                    Edit();

                }
            }
        }
        public string DriverPhone
        {
            get => _driverPhone;
            set
            {
                if (_driverPhone == null || !_driverPhone.Equals(value))
                {
                    _driverPhone = value;
                    Edit();

                }
            }
        }
        public string DriverFio
        {
            get => _driverFio;
            set
            {
                if (_driverFio == null ||  !_driverFio.Equals(value))
                {
                    _driverFio = value;
                    Edit();

                }
            }
        }
        public string VehicleNumber
        {
            get => _vehicleNumber;
            set
            {

                if (_vehicleNumber == null || !_vehicleNumber.Equals(value))
                {
                    _vehicleNumber = value;
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
        public string AttorneyNumber
        {
            get => _attorneyNumber;
            set
            {
                if (_attorneyNumber == null || !_attorneyNumber.Equals(value))
                {
                    _attorneyNumber = value;
                    Edit();

                }
            }
        }
        public DateTime? AttorneyDate
        {
            get => _attorneyDate;
            set
            {
                if (!_attorneyDate.Equals(value))
                {
                    _attorneyDate = value;
                    Edit();

                }
            }
        }
        public DateTime? SubmissionTime
        {
            get => _submissionTime;
            set
            {
                if (!_submissionTime.Equals(value))
                {
                    _submissionTime = value;
                    Edit();

                }
            }
        }
        public DateTime? StartTime
        {
            get => _startTime;
            set
            {
                if (!_startTime.Equals(value))
                {
                    _startTime = value;
                    Edit();

                }
            }
        }
        public string DelayComment
        {
            get => _delayComment;
            set
            {
                if (_delayComment == null || !_delayComment.Equals(value))
                {
                    _delayComment = value;
                    Edit();

                }
            }
        }
        public int? DepositorId
        {
            get => _depositorId;
            set
            {
                if (!_depositorId.Equals(value))
                {
                    _depositorId = value;
                    Edit();

                }
            }
        }
        public bool? IsCourier
        {
            get => _isCourier;
            set
            {
                if (!_isCourier.Equals(value))
                {
                    _isCourier = value;
                    Edit();

                }
            }
        }
        public bool? ShIn
        {
            get => _sIn;
            set
            {
                if (!_sIn.Equals(value))
                {
                    _sIn = value;
                    Edit();

                }
            }
        }
        public string ForwarderFio
        {
            get => _forwarderFio;
            set
            {
                if (_forwarderFio == null || !_forwarderFio.Equals(value))
                {
                    _forwarderFio = value;
                    Edit();

                }
            }
        }
        public string StampNumber
        {
            get => _stampNumber;
            set
            {
                if (_stampNumber == null ||!_stampNumber.Equals(value))
                {
                    _stampNumber = value;
                    Edit();

                }
            }
        }
        public string AttorneyIssued
        {
            get => _attorneyIssued;
            set
            {
                if (_attorneyIssued == null || !_attorneyIssued.Equals(value))
                {
                    _attorneyIssued = value;
                    Edit();

                }
            }
        }
        public string InOut
        {
            get => _inOut;
            set
            {
                if (_inOut == null ||!_inOut.Equals(value))
                {
                    _inOut = value;
                    Edit();

                }
            }
        }
        public DateTime? EndTime
        {
            get => _endTime;
            set
            {
                if (!_endTime.Equals(value))
                {
                    _endTime = value;
                    Edit();

                }
            }
        }
        public DateTime? LeaveTime
        {
            get => _leaveTime;
            set
            {
                if (!_leaveTime.Equals(value))
                {
                    _leaveTime = value;
                    Edit();

                }
            }
        }
        public bool? IsAddLv
        {
            get => _isAddLv;
            set
            {
                if (!_isAddLv.Equals(value))
                {
                    _isAddLv = value;
                    Edit();

                }
            }
        }
        public string DelayReasonName
        {
            get => _delayReasonName;
            set
            {
                if (_delayReasonName == null || !_delayReasonName.Equals(value))
                {
                    _delayReasonName = value;
                    Edit();

                }
            }
        }
        public string TransportCompanyName
        {
            get => _transportCompanyName;
            set
            {
                if (_transportCompanyName == null || !_transportCompanyName.Equals(value))
                {
                    _transportCompanyName = value;
                    Edit();

                }
            }
        }
        public string TransportTypeName
        {
            get => _transportTypeName;
            set
            {
                if (_transportTypeName == null || !_transportTypeName.Equals(value))
                {
                    _transportTypeName = value;
                    Edit();

                }
            }
        }
        public string DepositorName
        {
            get => _depositorName;
            set
            {
                if (_depositorName == null || !_depositorName.Equals(value))
                {
                    _depositorName = value;
                    Edit();

                }
            }
        }
        public string SupplierName
        {
            get => _supplierName;
            set
            {
                if (_supplierName == null || !_supplierName.Equals(value))
                {
                    _supplierName = value;
                    Edit();

                }
            }
        }
        public string CustomPostName
        {
            get => _customPostName;
            set
            {
                if (_customPostName == null || !_customPostName.Equals(value))
                {
                    _customPostName = value;
                    Edit();

                }
            }
        }
        public string WarehouseName
        {
            get => _warehouseName;
            set
            {
                if (_warehouseName == null || !_warehouseName.Equals(value))
                {
                    _warehouseName = value;
                    Edit();

                }
            }
        }
        public string TransportViewName
        {
            get => _transportViewName;
            set
            {
                if (_transportViewName == null || !_transportViewName.Equals(value))
                {
                    _transportViewName = value;
                    Edit();

                }
            }
        }
        public string DepLvDB
        {
            get => _depLvDb;
            set
            {
                if (_depLvDb == null || !_depLvDb.Equals(value))
                {
                    _depLvDb = value;
                    Edit();

                }
            }
        }

        public int? FontColor
        {
            get => _fontColor;
            set
            {
                if (!_fontColor.Equals(value))
                {
                    _fontColor = value;
                    Edit();

                }
            }
        }
        public int? BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                if (!_backgroundColor.Equals(value))
                {
                    _backgroundColor = value;
                    Edit();

                }
            }
        }
        public int? LogNum
        {
            get => _logNum;
            set
            {
                if (!_logNum.Equals(value))
                {
                    _logNum = value;
                    Edit();

                }
            }
        }
        public int? DepLvId
        {
            get => _depLvId;
            set
            {
                if (!_depLvId.Equals(value))
                {
                    _depLvId = value;
                    Edit();

                }
            }
        }
    }
}
