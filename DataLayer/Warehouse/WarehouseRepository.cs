using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class WarehouseRepository : BaseRepository<Warehouse, WarehouseDataAdapter>
    {
        public WarehouseRepository(string connectionString)
            :base(connectionString)
        {

        }

        public Warehouse GetByCode(string code)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where code = @Code";
            Warehouse item = null;
            var queryResult = dbConnection.Query<Warehouse>(sql, new { Code = code });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
