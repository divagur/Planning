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
	                    {nameof(Depositor.Id)}, {nameof(Depositor.Name)},{nameof(Depositor.LvId)},{nameof(Depositor.LvBase)}
                    from 
	                    {Table}
                    ";
        }

 
    }
}
