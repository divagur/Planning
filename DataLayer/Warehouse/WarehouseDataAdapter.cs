using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class WarehouseDataAdapter : IDataAdaper
    {
        public string Table => "wrehouse";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (code, name, descr) 
                                    values(
                                            @{nameof(Warehouse.Code)},@{nameof(Warehouse.Name)},@{nameof(Warehouse.Descr)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set code = @{nameof(Warehouse.Code)},name = @{nameof(Warehouse.Name)},
                                            descr = @{nameof(Warehouse.Descr)}
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
	                    id as {nameof(Warehouse.Id)}, code as {nameof(Warehouse.Code)},name as {nameof(Warehouse.Name)},
                        descr as {nameof(Warehouse.Descr)}
                    from 
	                    {Table}
                    ";
        }
    }
}
