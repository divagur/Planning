using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TimeSlotRepository : BaseRepository<TimeSlot, TimeSlotAdapter>
    {
        public TimeSlotRepository(string ConnectionString)
        : base(ConnectionString)
        {

        }
        public TimeSlotRepository()
            : base( )
        {

        }

        public List<TimeSlot> GetByDepositorId(int? DepositorId)
        {
            List<TimeSlot> timeSlots;
            string sql = dataAdapter.GetSelectItemSql() + " where depositor_id = @depositorId";
            
            var queryResult = dbConnection.Query<TimeSlot>(sql, new { depositorId = DepositorId });
            timeSlots = queryResult.ToList();
            return timeSlots;
        }
    }
}
