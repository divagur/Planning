using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class MovementDataAdapter : IDataAdaper
    {
        public string Table => "movement";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (m_date, time_slot_id, priority, comment, delay_reasons_id, delay_comment, performer, 
                                                    def_customer, sp_condition, special_time) 
                                    values(
                                            @{nameof(Movement.MDate)},@{nameof(Movement.TimeSlotId)},@{nameof(Movement.Priority)},@{nameof(Movement.Comment)},@{nameof(Movement.DelayReasonsId)},
                                            @{nameof(Movement.DelayComment)},@{nameof(Movement.Performer)},@{nameof(Movement.DefCustomer)},@{nameof(Movement.SpCondition)},
                                            @{nameof(Movement.SpecialTime)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set m_date = @{nameof(Movement.MDate)}, time_slot_id = @{nameof(Movement.TimeSlotId)}, priority = @{nameof(Movement.Priority)}, 
                                                    comment = @{nameof(Movement.Comment)}, delay_reasons_id = @{nameof(Movement.DelayReasonsId)}, 
                                                    delay_comment = @{nameof(Movement.DelayComment)}, performer = @{nameof(Movement.Performer)}, 
                                                    def_customer = @{nameof(Movement.DefCustomer)}, sp_condition = @{nameof(Movement.SpCondition)}, special_time = @{nameof(Movement.SpecialTime)}
                        where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    id as {nameof(Movement.Id)}, m_date as {nameof(Movement.MDate)}, time_slot_id as {nameof(Movement.TimeSlotId)}, priority as {nameof(Movement.Priority)}, 
                        comment as {nameof(Movement.Comment)}, delay_reasons_id as {nameof(Movement.DelayReasonsId)}, delay_comment as {nameof(Movement.DelayComment)}, 
                        performer as {nameof(Movement.Performer)}, def_customer as {nameof(Movement.DefCustomer)}, sp_condition as {nameof(Movement.SpCondition)}, 
                        special_time as {nameof(Movement.SpecialTime)}
                    from 
	                    {Table}
                    ";
        }
    }
}
