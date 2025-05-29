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
    public class ShipmentOrderLogRepository : BaseRepository<ShipmentOrderLog, ShipmentOrderLogDataAdapter>
    {
        public ShipmentOrderLogRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public ShipmentOrderLogRepository()
            : base()
        {

        }

        public List<ShipmentOrderLog> GetShipmentOrders(int? ShipmentId)
        {
            List<ShipmentOrderLog> result;
            string sql = dataAdapter.GetSelectItemSql() + " where shipment_id = @shipmentId";
            var queryResult = dbConnection.Query<ShipmentOrderLog>(sql, new { shipmentId = ShipmentId });
            result = queryResult.ToList();
            return result;
        }
    }
}
