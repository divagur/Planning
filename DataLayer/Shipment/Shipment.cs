using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class Shipment:BaseDataItem
    {
        int? _lvId;
        int? _timeSlotId;
        DateTime? _sDate;
        string _sComment;
        string _oComment;
        int? _gateId;
        bool? _spCondition;
        string _driverPhone;
        string _driverFio;
        string _vehicleNumber;
        string _trailerNumber;
        string _attorneyNumber;
        DateTime? _attorneyDate;
        DateTime? _submissionTime;
        DateTime? _startTime;
        int? _delayReasonsId;
        string _delayComment;
        int? _depositorId;
        bool? _isCourier;
        string _forwarderFio;
        string _stampNumber;
        string _attorneyIssued;
        bool? _shIn;
        TimeSpan? _specialTime;
        DateTime? _endTime;
        DateTime? _leaveTime;
        bool? _isAddLv;
        int? _transportCompanyId;
        int? _transportTypeId;
        int? _supplierId;
        string _lvCode;

        public int? LvId
        {
            get => _lvId;
            set
            {
                if (!_lvId.Equals(value))
                {
                    _lvId = value;
                    Edit();

                }
            }
        }
        public int? TimeSlotId
        {
            get => _timeSlotId;
            set
            {
                if (!_timeSlotId.Equals(value))
                {
                    _timeSlotId = value;
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
                if (!_sComment.Equals(value))
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
                if (!_oComment.Equals(value))
                {
                    _oComment = value;
                    Edit();

                }
            }
        }
        public int? GateId
        {
            get => _gateId;
            set
            {
                if (!_gateId.Equals(value))
                {
                    _gateId = value;
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
                if (!_driverPhone.Equals(value))
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
                if (!_driverFio.Equals(value))
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
                if (!_vehicleNumber.Equals(value))
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
                if (!_trailerNumber.Equals(value))
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
                if (!_attorneyNumber.Equals(value))
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
        public int? DelayReasonsId
        {
            get => _delayReasonsId;
            set
            {
                if (!_delayReasonsId.Equals(value))
                {
                    _delayReasonsId = value;
                    Edit();

                }
            }
        }
        public string DelayComment
        {
            get => _delayComment;
            set
            {
                if (!_delayComment.Equals(value))
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
        public string ForwarderFio
        {
            get => _forwarderFio;
            set
            {
                if (!_forwarderFio.Equals(value))
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
                if (!_stampNumber.Equals(value))
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
                if (!_attorneyIssued.Equals(value))
                {
                    _attorneyIssued = value;
                    Edit();

                }
            }
        }
        public bool? ShIn
        {
            get => _shIn;
            set
            {
                if (!_shIn.Equals(value))
                {
                    _shIn = value;
                    Edit();

                }
            }
        }
        public TimeSpan? SpecialTime
        {
            get => _specialTime;
            set
            {
                if (!_specialTime.Equals(value))
                {
                    _specialTime = value;
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
        public int? TransportCompanyId
        {
            get => _transportCompanyId;
            set
            {
                if (!_transportCompanyId.Equals(value))
                {
                    _transportCompanyId = value;
                    Edit();

                }
            }
        }
        public int? TransportTypeId
        {
            get => _transportTypeId;
            set
            {
                if (!_transportTypeId.Equals(value))
                {
                    _transportTypeId = value;
                    Edit();

                }
            }
        }
        public int? SupplierId
        {
            get => _supplierId;
            set
            {
                if (!_supplierId.Equals(value))
                {
                    _supplierId = value;
                    Edit();

                }
            }
        }
        public string LvCode
        {
            get => _lvCode;
            set
            {
                if (!_lvCode.Equals(value))
                {
                    _lvCode = value;
                    Edit();

                }
            }
        }
    }
}
