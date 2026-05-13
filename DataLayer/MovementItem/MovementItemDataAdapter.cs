using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class MovementItemDataAdapter : IDataAdaper
    {
        public string Table => "movement_item";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (movement_id, depositor_id, TklLVID,
                                                    last_modify_user,last_modify_date) 
                                    values(@{nameof(MovementItem.MovementId)}, @{nameof(MovementItem.DepositorId)}, 
                                            @{nameof(MovementItem.TklLVID)},
                                            @{nameof(MovementItem.LastModifyUser)},@{nameof(MovementItem.LastModifyDate)})";
                case EditState.Edit:
                    return $@"update {Table} set movement_id = @{nameof(MovementItem.MovementId)}, 
                                depositor_id = @{nameof(MovementItem.DepositorId)}, TklLVID = @{nameof(MovementItem.TklLVID)},
                                last_modify_user = @{nameof(MovementItem.LastModifyUser)},
                                last_modify_date = @{nameof(MovementItem.LastModifyDate)}
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
	                    {Table}.id as {nameof(MovementItem.Id)}, movement_id as {nameof(MovementItem.MovementId)},depositor_id as {nameof(MovementItem.DepositorId)},
                        TklLVID as {nameof(MovementItem.TklLVID)},
                        last_modify_user as {nameof(MovementItem.LastModifyUser)},last_modify_date as {nameof(MovementItem.LastModifyDate)}
                    from 
	                    {Table}
                    ";
        }
    }
}
