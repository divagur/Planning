using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UsersGroupDataAdapter : IDataAdaper
    {
        public string Table { get => "users_group"; }

        public string GetSaveSql(EditState editState)
        {
           switch (editState) 
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name,access) values(@{nameof(UsersGroup.Name)},@{nameof(UsersGroup.Access)})";
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(UsersGroup.Name)}, access = @{nameof(UsersGroup.Access)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;    
        }

        public string GetSelectItemSql()
        {
            return $@"select {Table}.id as {nameof(UsersGroup.Id)}, name as {nameof(UsersGroup.Name)}, access as {nameof(UsersGroup.Access)} from {Table}";
        }
    }
}
