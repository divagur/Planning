using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class MovementItemRepository: BaseRepository<MovementItem, MovementItemDataAdapter>
    {
        public MovementItemRepository(string ConnectionString)
    :   base(ConnectionString)
        {

        }
        public MovementItemRepository()
            : base()
        {

        }

        public List<MovementItem> GetByMovementId(int? MovementId)
        {
            List<MovementItem> result;
            string sql = dataAdapter.GetSelectItemSql() + " where movement_id = @movementId";
            var queryResult = dbConnection.Query<MovementItem>(sql, new { movementId = MovementId });
            result = queryResult.ToList();
            return result;
        }
    }
}
