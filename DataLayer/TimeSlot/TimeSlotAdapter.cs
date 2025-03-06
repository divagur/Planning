using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class TimeSlotAdapter : IDataAdaper
    {
        public string Table => "time_slot";


        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name) values(@{nameof(TimeSlot.DepositorId)}, @{nameof(TimeSlot.Name)}, @{nameof(TimeSlot.SlotTime)})";
                    break;
                case EditState.Edit:
                    return $@"update {Table} id = @{nameof(TimeSlot.Id)},depositor_id = @{nameof(TimeSlot.DepositorId)}, 
                                name = @{nameof(TimeSlot.Name)}, slot_time = @{nameof(TimeSlot.SlotTime)}";
                    break;
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
 
                    break;
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    {nameof(TimeSlot.Id)}, {nameof(TimeSlot.Name)},{nameof(TimeSlot.DepositorId)},{nameof(TimeSlot.SlotTime)}
                    from 
	                    {Table}
                    ";
        }

 
    }
}
