using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UsersGroupRepository : BaseRepository<UsersGroup, UsersGroupDataAdapter>
    {
        
        public UsersGroupRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }
        public UsersGroupRepository()
         : base()
        {

        }

        public List<UsersGroup> GetByUserId(int? UserId)
        {
            List<UsersGroup> result;
            string sql = dataAdapter.GetSelectItemSql() + $" inner join user_group_lnk ugl on {dataAdapter.Table}.id = ugl.grp_id where user_id = @userId";
            var queryResult = dbConnection.Query<UsersGroup>(sql, new { userId = UserId });
            result = queryResult.ToList();
            return result;
        }
    }
}
