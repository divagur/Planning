using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserRepository : BaseRepository<User, UserDataAdapter>
    {
        public UserRepository(string connectionString)
        : base(connectionString)
        {

        }

        public UserRepository()
        : base()
        {

        }

        public User GetByDomainUserName(string DomainUserName)
        {
            User result = null;
            string sql = dataAdapter.GetSelectItemSql() + $" where domain_user_name = @domainUserName";
            var queryResult = dbConnection.Query<User>(sql, new { domainUserName = DomainUserName });
            if (queryResult != null)
            {
                result = queryResult.FirstOrDefault();
            }
            return result;
        }

        public User GetByUserName(string UserName)
        {
            User result = null;
            string sql = dataAdapter.GetSelectItemSql() + $" where login = @userName";
            var queryResult = dbConnection.Query<User>(sql, new { userName = UserName });
            if (queryResult != null)
            {
                result = queryResult.FirstOrDefault();
            }
            return result;
        }
    }
}
