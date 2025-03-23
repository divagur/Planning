using System;
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
    }
}
