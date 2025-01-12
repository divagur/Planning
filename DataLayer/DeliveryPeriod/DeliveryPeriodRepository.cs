using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class DeliveryPeriodRepository : BaseRepository<DeliveryPeriod, DeliveryPeriodDataAdapter>
    {
        public DeliveryPeriodRepository(string connectionString)
            :base(connectionString)
        {

        }

        public DeliveryPeriod GetByCode(string CustomPostCode, string WarehouseCode)
        {
            DeliveryPeriodDataAdapter deliveryPeriodDataAdapter = new DeliveryPeriodDataAdapter();
            string sql = dataAdapter.GetSelectItemSql() + $@"join custom_posts cp on cp.id = {deliveryPeriodDataAdapter.Table}.custom_post_id
                    join warehouses w on w.id = {deliveryPeriodDataAdapter.Table}.warehouse_id
                    where cp.code = @customPostCode and w.code = @warehouseCode";
            DeliveryPeriod item = null;
            var queryResult = dbConnection.Query<DeliveryPeriod>(sql, new { customPostCode = CustomPostCode, warehouseCode = WarehouseCode });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
