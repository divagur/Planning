using System;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class UserGrpPrvlgDataAdapter : IDataAdaper
    {
        public string Table => "user_grp_prvlg";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (grp_id, func_id, is_view, is_append, is_edit, is_delete) 
                                    values(@{nameof(UserGrpPrvlg.GrpId)},@{nameof(UserGrpPrvlg.FuncId)},@{nameof(UserGrpPrvlg.IsView)},
                                            @{nameof(UserGrpPrvlg.IsAppend)}, @{nameof(UserGrpPrvlg.IsEdit)}, @{nameof(UserGrpPrvlg.IsDelete)})";
                case EditState.Edit:
                    return $@"update {Table} grp_id = @{nameof(UserGrpPrvlg.GrpId)}, func_id = @{nameof(UserGrpPrvlg.FuncId)}, 
                                                is_view = @{nameof(UserGrpPrvlg.IsView)}, is_append = @{nameof(UserGrpPrvlg.IsAppend)}, 
                                                is_edit = @{nameof(UserGrpPrvlg.IsEdit)}, is_delete = @{nameof(UserGrpPrvlg.IsDelete)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(UserGrpPrvlg.Id)}, grp_id as {nameof(UserGrpPrvlg.GrpId)}, func_id as {nameof(UserGrpPrvlg.FuncId)}, 
                            is_view as {nameof(UserGrpPrvlg.IsView)}, is_append as {nameof(UserGrpPrvlg.IsAppend)}, 
                            is_edit as {nameof(UserGrpPrvlg.IsEdit)}, is_delete as {nameof(UserGrpPrvlg.IsDelete)} 
                       from {Table}";
        }
    }
}
