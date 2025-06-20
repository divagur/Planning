using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Planning.DataLayer;
using Dapper;
using System.Data;

namespace Planning.DataLayer
{ 
    public class LvSelectOrderRepository : BaseRepository<LvSelectOrder, LvSelectOrderAdapter>
    {
        public LvSelectOrderRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public LvSelectOrderRepository()
            : base()
        {

        }

        public List<LvSelectOrder> GetAll(int? Split, int? In, int? DepId, int? OrderId, int IsAll)
        {
            string sql = dataAdapter.GetSelectItemSql();


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Split", Split);
            parameters.Add("@In", In);
            parameters.Add("@DepId", DepId);
            parameters.Add("@LVID", OrderId);
            parameters.Add("@IsAll", IsAll);

            List<LvSelectOrder> shipments = new List<LvSelectOrder>();

            var queryResult = dbConnection.Query<LvSelectOrder>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (queryResult != null)
            {
                shipments = queryResult.ToList();

            }
            return shipments;
        }
    }
}
