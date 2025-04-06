using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class DepositorAdapter : IDataAdaper
    {
        public string Table => "depositors";


        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name) values(@{nameof(DelayReason.Name)})";                    
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(DelayReason.Name)}";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    id as {nameof(Depositor.Id)}, name as {nameof(Depositor.Name)},lv_id as {nameof(Depositor.LvId)},lv_base as {nameof(Depositor.LvBase)}
                    from 
	                    {Table}
                    ";
        }

 
    }
}
