using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Planning.DataLayer;
using Planning.Kernel;
using Dapper;

namespace Planning
{
    public class LvOrderDetailItemRepository : BaseRepository<LvOrderDetailItem, LvOrderDetailItemAdapter>
    {
        public LvOrderDetailItemRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public LvOrderDetailItemRepository()
            : base()
        {

        }
        public List<LvOrderDetailItem> GetOrderDetailItems(int? DepositorLVId, int InOutType, int? ordId, bool isAll = false)
        {
            List<LvOrderDetailItem> listOrderDetailItems = new List<LvOrderDetailItem>();

            string sql = dataAdapter.GetSelectItemSql();


            DynamicParameters parameters = new DynamicParameters();
            
            parameters.Add("@In", InOutType);
            parameters.Add("@DepId", DepositorLVId);
            parameters.Add("@LVID", ordId);
            parameters.Add("@IsAll", isAll);

            var queryResult = dbConnection.Query<LvOrderDetailItem>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (queryResult != null)
            {
                listOrderDetailItems = queryResult.ToList();

            }

            return listOrderDetailItems;
        }
    }
}
