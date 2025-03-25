using System;
using Planning.Kernel;
using Dapper;
using System.Linq;

namespace Planning.DataLayer
{
    public class SupplierRepository : BaseRepository<Supplier, SupplierDataAdapter>
    {
        
        public SupplierRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }

        public Supplier GetByCode(string code)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where code = @Code";
            Supplier item = null;
            var queryResult = dbConnection.Query<Supplier>(sql, new { Code = code });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
