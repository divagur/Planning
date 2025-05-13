using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGroupLnkRepository:BaseRepository<UserGroupLnk, UserDataAdapter>
    {
        public UserGroupLnkRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public UserGroupLnkRepository()
            : base()
        {

        }
    }
}
