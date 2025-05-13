using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class UserGrpPrvlgRepository: BaseRepository<UserGrpPrvlg, UserGrpPrvlgDataAdapter>
    {
        public UserGrpPrvlgRepository(string ConnectionString)
    : base(ConnectionString)
        {

        }
        public UserGrpPrvlgRepository()
         : base()
        {

        }
    }
}
