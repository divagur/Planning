using Dapper;
using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class TransportCompanyKpiDelayRepository : BaseRepository<TransportCompanyKpiDelay, TransportCompanyKpiDelayDataAdapter>
    {
        public TransportCompanyKpiDelayRepository(string connectionString)
           : base(connectionString)
        {

        }
        public TransportCompanyKpiDelayRepository()
        : base()
        {

        }

        public TransportCompanyKpiDelay GetByMinutesDelay(int? minutesDelay)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where minutes_delay = @MinutesDelay";
            TransportCompanyKpiDelay item = null;
            var queryResult = dbConnection.Query<TransportCompanyKpiDelay>(sql, new { MinutesDelay = minutesDelay });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }


        public TransportCompanyKpiDelay GetByKpi(int? kpi)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where kpi = @Kpi";
            TransportCompanyKpiDelay item = null;
            var queryResult = dbConnection.Query<TransportCompanyKpiDelay>(sql, new { Kpi = kpi });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }

    }
}
