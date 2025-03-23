using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportTypeDataAdapter : IDataAdaper
    {
        public string Table => "transport_type";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name,tonnage) 
                                    values(
                                            @{nameof(TransportType.Name)},@{nameof(TransportType.Tonnage)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set name = @{nameof(TransportType.Name)},tonnage  = @{nameof(TransportType.Tonnage)}
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
	                    id as {nameof(TransportType.Id)}, name as {nameof(TransportType.Name)},tonnage as {nameof(TransportType.Tonnage)}
                    from 
	                    {Table}
                    ";
        }
    }
}
