using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class Movement: BaseDataItem
    {
        DateTime _mDate;
        int? _timeSlotId;
        int? _priority;
        string _comment;
        int? _delayReasonsId;
        string _delayComment;
        string _performer;
        bool? _defCustomer;
        bool? _spCondition;
        TimeSpan? _specialTime;
        TimeSlot _timeSlot;

        public DateTime MDate
        {
            get => _mDate;
            set
            {

                if (_mDate == null || !_mDate.Equals(value))
                {
                    _mDate = value;
                    Edit();

                }
            }
        }
        public int? TimeSlotId
        {
            get => _timeSlotId;
            set
            {

                if (_timeSlotId == null || !_timeSlotId.Equals(value))
                {
                    _timeSlotId = value;
                    Edit();

                }
            }
        }
        public int? Priority
        {
            get => _priority;
            set
            {

                if (_priority == null || !_priority.Equals(value))
                {
                    _priority = value;
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
        public int? DelayReasonsId
        {
            get => _delayReasonsId;
            set
            {

                if (_delayReasonsId == null || !_delayReasonsId.Equals(value))
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

                if (_delayComment == null || !_delayComment.Equals(value))
                {
                    _delayComment = value;
                    Edit();

                }
            }
        }
        public string Performer
        {
            get => _performer;
            set
            {

                if (_performer == null || !_performer.Equals(value))
                {
                    _performer = value;
                    Edit();

                }
            }
        }
        public bool? DefCustomer
        {
            get => _defCustomer;
            set
            {

                if (_defCustomer == null || !_defCustomer.Equals(value))
                {
                    _defCustomer = value;
                    Edit();

                }
            }
        }
        public bool? SpCondition
        {
            get => _spCondition;
            set
            {

                if (_spCondition == null || !_spCondition.Equals(value))
                {
                    _spCondition = value;
                    Edit();

                }
            }
        }
        public TimeSpan? SpecialTime
        {
            get => _specialTime;
            set
            {

                if (_specialTime == null || !_specialTime.Equals(value))
                {
                    _specialTime = value;
                    Edit();

                }
            }
        }
        public TimeSlot TimeSlot
        {
            get
            {
                if (_timeSlot == null)
                {
                    TimeSlotRepository timeSlotRepository = new TimeSlotRepository();
                    _timeSlot = timeSlotRepository.GetById(_timeSlotId);
                }
                return _timeSlot;
            }
        }

    }
}
