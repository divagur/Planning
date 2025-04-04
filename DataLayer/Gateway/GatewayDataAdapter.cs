using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class GatewayDataAdapter : IDataAdaper
    {
        public string Table { get => "gateways"; }

        public string GetSaveSql(EditState editState)
        {
           switch (editState) 
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name) values(@{nameof(Gateway.Name)})";
                case EditState.Edit:
                    return $@"update {Table} Set name = @{nameof(Gateway.Name)}
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;    
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(Gateway.Id)}, name as {nameof(Gateway.Name)} from {Table}";
        }
    }
}
