using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class PLQueryAdapter : IDataAdaper
    {
        public string Table => "pl_query";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (qry_ID, qry_First, qry_Repeating, qry_Last, qry_Comment) 
                                    values(
                                            @{nameof(PLQuery.qryId)},@{nameof(PLQuery.qryFirst)},@{nameof(PLQuery.qryRepeating)},
                                            @{nameof(PLQuery.qryLast)},@{nameof(PLQuery.qryComment)})";
                case EditState.Edit:
                    return $@"update {Table} set qry_First = @{nameof(PLQuery.qryFirst)},
                                            qry_Repeating = @{nameof(PLQuery.qryRepeating)},qry_Last = @{nameof(PLQuery.qryLast)},
                                            qry_Comment = @{nameof(PLQuery.qryComment)}
                        where qry_ID = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where qry_ID = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    {Table}.qry_ID as {nameof(PLQuery.qryId)}, qry_First as {nameof(PLQuery.qryFirst)},qry_Repeating as {nameof(PLQuery.qryRepeating)},
                        qry_Last as {nameof(PLQuery.qryLast)},qry_Comment as {nameof(PLQuery.qryComment)}
                    from 
	                    {Table}
                    ";
        }
    }
}
