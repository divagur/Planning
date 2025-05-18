using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGroupLnkRepository:BaseRepository<UserGroupLnk, UserGroupLnkDataAdapter>
    {
        public UserGroupLnkRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public UserGroupLnkRepository()
            : base()
        {

        }

        public List<UserGroupLnk> GetByUserId(int? UserId)
        {
            List<UserGroupLnk> result;
            string sql = dataAdapter.GetSelectItemSql() + " where user_id = @userId";
            var queryResult = dbConnection.Query<UserGroupLnk>(sql, new { userId = UserId });
            result = queryResult.ToList();
            return result;
        }
    }
}
