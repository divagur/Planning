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
    public class ShipmentOrderPartRepository:BaseRepository<ShipmentOrderPart, ShipmentOrderPartDataAdapter>
    {
        public ShipmentOrderPartRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public ShipmentOrderPartRepository()
            : base()
        {

        }        

        public List<ShipmentOrderPart> GetShipmentOrderParts(List<int?> ShipmentIds)
        {
            List<ShipmentOrderPart> result;
            string sql = dataAdapter.GetSelectItemSql() + " where sh_order_id in (@shipmentIds)";
            string shipmentIds = String.Join(",", ShipmentIds.Select(i => i.ToString()).ToArray());
            var queryResult = dbConnection.Query<ShipmentOrderPart>(sql, new { shipmentIds = shipmentIds });
            result = queryResult.ToList();
            return result;
        }
    }
}
