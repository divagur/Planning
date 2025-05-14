using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGroupLnkDataAdapter : IDataAdaper
    {
        public string Table => "user_group_lnk";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (user_id, group_id) values(@{nameof(UserGroupLnk.UserId)}, @{nameof(UserGroupLnk.GroupId)})";
                case EditState.Edit:
                    return $@"update {Table} set user_id = @{nameof(UserGroupLnk.UserId)}, group_id = @{nameof(UserGroupLnk.GroupId)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(UserGroupLnk.Id)}, user_id as {nameof(UserGroupLnk.UserId)}, group_id as {nameof(UserGroupLnk.GroupId)} 
                       from {Table}";
        }
    }
}
