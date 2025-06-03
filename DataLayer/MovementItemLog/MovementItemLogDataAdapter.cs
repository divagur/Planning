using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class MovementItemLogDataAdapter : IDataAdaper
    {
        public string Table => "movement_item_log";

        public string GetSaveSql(EditState editState)
        {
            /*
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (dml_type, dml_date, dml_user_name, dml_comp_name, movement_item_id,movement_id, depositor_id, TklLVID) 
                                    values(@{nameof(MovementItem.MovementId)}, @{nameof(MovementItem.DepositorId)}, @{nameof(MovementItem.TklLVID)})";
                case EditState.Edit:
                    return $@"update {Table} set movement_id = @{nameof(MovementItem.MovementId)}, 
                                depositor_id = @{nameof(MovementItem.DepositorId)}, TklLVID = @{nameof(MovementItem.TklLVID)}
                                where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }
            */
            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    {Table}.dml_id as {nameof(MovementItemLog.Id)},dml_type as {nameof(MovementItemLog.DmlType)},dml_date as {nameof(MovementItemLog.DmlDate)}, dml_user_name as {nameof(MovementItemLog.DmlUserName)}, 
                        dml_comp_name as {nameof(MovementItemLog.DmlCompName)},
                        movement_item_id as {nameof(MovementItemLog.MovementItemId)}, 
                        movement_id as {nameof(MovementItemLog.MovementId)},depositor_id as {nameof(MovementItemLog.DepositorId)},
                        TklLVID as {nameof(MovementItem.TklLVID)}
                    from 
	                    {Table}
                    ";
        }
    }
}
