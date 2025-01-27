using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportCompanyDataAdapter : IDataAdaper
    {
        public string Table => "transport_company";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (name, is_active, code) 
                                    values(
                                            @{nameof(TransportCompany.Name)},@{nameof(TransportCompany.IsActive)},@{nameof(TransportCompany.Code)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set code = @{nameof(TransportCompany.Code)},name = @{nameof(TransportCompany.Name)},
                                            is_active = @{nameof(TransportCompany.IsActive)}
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
	                    id as {nameof(TransportCompany.Id)}, code as {nameof(TransportCompany.Code)},name as {nameof(TransportCompany.Name)},
                        is_active as {nameof(TransportCompany.IsActive)}
                    from 
	                    {Table}
                    ";
        }
    }
}
