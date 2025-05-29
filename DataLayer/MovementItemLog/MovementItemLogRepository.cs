using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class MovementItemLogRepository : BaseRepository<MovementItemLog, MovementItemLogDataAdapter>
    {
        public MovementItemLogRepository(string ConnectionString)
    :   base(ConnectionString)
        {

        }
        public MovementItemLogRepository()
            : base()
        {

        }

        public List<MovementItemLog> GetByMovementId(int? MovementId)
        {
            List<MovementItemLog> result;
            string sql = dataAdapter.GetSelectItemSql() + " where movement_id = @movementId";
            var queryResult = dbConnection.Query<MovementItemLog>(sql, new { movementId = MovementId });
            result = queryResult.ToList();
            return result;
        }
    }
}
