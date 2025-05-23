using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Planning.DataLayer;
using Dapper;
using System.Data;

namespace Planning.DataLayer
{ 
    public class LvMovementItemRepository : BaseRepository<LvMovementItem, LvMovementItemAdapter>
    {
        public LvMovementItemRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public LvMovementItemRepository()
            : base()
        {

        }

        public List<LvMovementItem> GetAll(int? MovementId)
        {
            string sql = dataAdapter.GetSelectItemSql();


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MovementID", MovementId);

            List<LvMovementItem> movementItems = new List<LvMovementItem>();

            var queryResult = dbConnection.Query<LvMovementItem>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (queryResult != null)
            {
                movementItems = queryResult.ToList();

            }
            return movementItems;
        }
    }
}
