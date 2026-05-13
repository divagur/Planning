using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportCompanyKpiDelayDataAdapter : IDataAdaper
    {
        public string Table => "transport_company_kpi_delay";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (minutes_delay,kpi) 
                                    values(
                                            @{nameof(TransportCompanyKpiDelay.MinutesDelay)},@{nameof(TransportCompanyKpiDelay.Kpi)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set minutes_delay = @{nameof(TransportCompanyKpiDelay.MinutesDelay)},kpi = @{nameof(TransportCompanyKpiDelay.Kpi)}
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
	                    id as {nameof(TransportCompanyKpiDelay.Id)}, minutes_delay as {nameof(TransportCompanyKpiDelay.MinutesDelay)},
                        kpi as {nameof(TransportCompanyKpiDelay.Kpi)}
                    from 
	                    {Table}
                    ";
        }
    }
}
