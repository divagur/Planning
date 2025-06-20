using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DepositorRepository : BaseRepository<Depositor, DepositorAdapter>
    {
        public DepositorRepository(string ConnectionString)
        : base(ConnectionString)
        {

        }
        public DepositorRepository()
            : base()
        {

        }

        public Depositor GetByName(string name)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where name = @Name";
            Depositor item = null;
            var queryResult = dbConnection.Query<Depositor>(sql, new { Name = name });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
