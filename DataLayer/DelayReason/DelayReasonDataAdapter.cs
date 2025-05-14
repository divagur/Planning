using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class DelayReasonDataAdapter : IDataAdaper
    {
        public string Table { get => "delay_reasons"; }

        public string GetSaveSql(EditState editState)
        {
           switch (editState) 
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name) values(@{nameof(DelayReason.Name)})";                    
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(DelayReason.Name)}
                            where id = @Id";                    
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;    
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(DelayReason.Id)}, name as {nameof(DelayReason.Name)} from {Table}";
        }
    }
}
