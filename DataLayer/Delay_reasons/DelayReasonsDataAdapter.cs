using System;

namespace Planning.Kernel
{
    public class DelayReasonsDataAdapter : IDataAdaper
    {
        //public string Table { get => "delay_reasons"; }

        public string Table
        {
            get
            {
                return "delay_reasons";
   
            }

        }

        public string GetSaveSql(EditState editState)
        {
           switch (editState) 
            {
                case EditState.New:
                    return $@"INSERT INTO delay_reasons (name) values(@{nameof(DelayReasons.Name)})";
                    break;
                case EditState.Edit:
                    return $@"update delay_reasons id = @{nameof(DelayReasons.Id)}, name = @{nameof(DelayReasons.Name)}";
                    break;
                case EditState.Delete:
                    return "delete from delay_reasons where id = @Id";
                    break;
            }

            return String.Empty;    
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(DelayReasons.Id)}, name as {nameof(DelayReasons.Name)} from delay_reasons";
        }
    }
}
