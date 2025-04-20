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
    public class PLAttributeRepository: BaseRepository<PLAttribute,PLAttributeAdapter>
    {
        public PLAttributeRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public PLAttributeRepository()
            : base()
        {

        }

        public List<PLAttribute> GetAll(int? DepId)
        {
            string sql = dataAdapter.GetSelectItemSql();


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepId", DepId);


            List<PLAttribute> plAttrs = new List<PLAttribute>();

            var queryResult = dbConnection.Query<PLAttribute>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (queryResult != null)
            {
                plAttrs = queryResult.ToList();

            }
            return plAttrs;
        }
    }
}
