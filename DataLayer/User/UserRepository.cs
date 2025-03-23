using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
