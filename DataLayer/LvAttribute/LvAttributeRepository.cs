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
    public class LvAttributeRepository: BaseRepository<LvAttribute,LvAttributeAdapter>
    {
        public LvAttributeRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public LvAttributeRepository()
            : base()
        {

        }

        public List<LvAttribute> GetAll(int? DepId, bool? ShpIn)
        {
            string sql = dataAdapter.GetSelectItemSql();


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepId", DepId);
            parameters.Add("@ShpIn", ShpIn);

            List<LvAttribute> shipments = new List<LvAttribute>();

            var queryResult = dbConnection.Query<LvAttribute>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (queryResult != null)
            {
                shipments = queryResult.ToList();

            }
            return shipments;
        }
    }
}
