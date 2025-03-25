using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class CustomPostRepository:BaseRepository<CustomPost, CustomPostDataAdapter>
    {
        public CustomPostRepository(string connectionString)
            :base(connectionString)
        {

        }

        public CustomPostRepository()
        : base()
        {

        }
        public CustomPost GetByCode(string code)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where code = @Code";
            CustomPost item = null;
            var queryResult = dbConnection.Query<CustomPost>(sql, new { Code = code });

            if (queryResult != null)
            {
                item = queryResult.FirstOrDefault();
            }
            return item;
        }
    }
}
