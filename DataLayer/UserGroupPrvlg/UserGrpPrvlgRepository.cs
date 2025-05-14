using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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

        public List<UserGrpPrvlg> GetByGrpId(int? GrpId)
        {
            List<UserGrpPrvlg> result;
            string sql = dataAdapter.GetSelectItemSql() + " where grp_id = @grpId";
            var queryResult = dbConnection.Query<UserGrpPrvlg>(sql, new { grpId = GrpId });
            result = queryResult.ToList();
            return result;
        }
    }
}
