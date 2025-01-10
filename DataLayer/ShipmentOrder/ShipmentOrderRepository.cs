using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;
using System.Data;

namespace Planning.DataLayer
{
    public class ShipmentOrderRepository:BaseRepository<ShipmentOrder, ShipmentOrderDataAdapter>
    {
        public ShipmentOrderRepository(string ConnectionString)
      : base(ConnectionString)
        {

        }
        public ShipmentOrder GetByLvCode(string LvCode)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where lv_code = @lvCode";
            ShipmentOrder item = null;
            var queryResult = dbConnection.Query<ShipmentOrder>(sql, new { lvCode = LvCode });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }

        public int? GetLvIdByCode(string LvCode)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LvCode", LvCode);
            parameters.Add("@In", 1);
            parameters.Add("@DepId", 1);
            var queryResult = dbConnection.Query<int?>("SP_PL_GetShipmentLvIdByCode", parameters, commandType: CommandType.StoredProcedure);

            return queryResult.FirstOrDefault();
        }
    }
}
