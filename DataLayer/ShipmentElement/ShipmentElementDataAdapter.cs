using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentElementDataAdapter : IDataAdaper
    {
        public string Table => "shipment_element";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (field_name,field_db_name,field_type) 
                                values(@{nameof(ShipmentElement.FieldName)},@{nameof(ShipmentElement.FieldDbName)},@{nameof(ShipmentElement.FieldType)})";
                case EditState.Edit:
                    return $@"update {Table} set id = @{nameof(ShipmentElement.Id)}, field_name = @{nameof(ShipmentElement.FieldName)},
                             field_db_name = @{nameof(ShipmentElement.FieldDbName)}, field_type = @{nameof(ShipmentElement.FieldType)}    
                            where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"select id as {nameof(ShipmentElement.Id)}, field_name as {nameof(ShipmentElement.FieldName)},
                    field_db_name as {nameof(ShipmentElement.FieldDbName)}, field_type as {nameof(ShipmentElement.FieldType)},
                    CASE 
					    WHEN field_type = 1 THEN 'Строка' 
					    WHEN field_type = 2 THEN 'Число' 
					    WHEN field_type = 3 THEN 'Дата'
					    WHEN field_type = 4 THEN 'ДатаВремя'
					    WHEN field_type = 5 THEN 'Логический' 
				    END AS {nameof(ShipmentElement.FieldTypeName)}
                    from {Table}";
        }
    }
}
