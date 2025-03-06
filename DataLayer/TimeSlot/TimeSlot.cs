using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;

namespace Planning.DataLayer
{
    [Table("depositors")]
    public class TimeSlot: BaseDataItem
    {
        int? _depositorId;
        string _name; 
        TimeSpan _slotTime;

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
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null || !_depositorId.Equals(value))
                {
                    _name = value;
                    Edit();

                }
            }
        }
        public TimeSpan SlotTime
        {
            get => _slotTime;
            set
            {
                if (_slotTime == null || !_depositorId.Equals(value))
                {
                    _slotTime = value;
                    Edit();

                }
            }
        }
    }
}
