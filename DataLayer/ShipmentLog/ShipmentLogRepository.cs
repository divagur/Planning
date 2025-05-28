using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;
using System.Data.SqlClient;

namespace Planning.DataLayer
{
    public class ShipmentRepository:BaseRepository<Shipment,ShipmentDataAdapter>
    {
        public ShipmentRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public ShipmentRepository()
            :base()
        {

        }
        public Shipment GetByLvOrderCode(string LvOrderCode)
        {
            ShipmentDataAdapter shipmentDataAdapter = new ShipmentDataAdapter();
            string sql = dataAdapter.GetSelectItemSql() + $@"join shipment_orders so on so.shipment_id = {shipmentDataAdapter.Table}.id
                    where so.lv_order_code = @lvOrderCode";
            Shipment item = null;
            var queryResult = dbConnection.Query<Shipment>(sql, new { lvOrderCode = LvOrderCode});

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
       
    }
}
