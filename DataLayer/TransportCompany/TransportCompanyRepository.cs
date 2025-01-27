using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class TransportCompanyRepository : BaseRepository<TransportCompany, TransportCompanyDataAdapter>
    {
        public TransportCompanyRepository(string connectionString)
            :base(connectionString)
        {

        }

        public TransportCompany GetByCode(int code)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where code = @Code";
            TransportCompany item = null;
            var queryResult = dbConnection.Query<TransportCompany>(sql, new { Code = code });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
