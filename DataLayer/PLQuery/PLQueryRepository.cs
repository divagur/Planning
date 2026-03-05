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
    public class PLQuertRepository: BaseRepository<PLQuery,PLQueryAdapter>
    {
        public PLQuertRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public PLQuertRepository()
            : base()
        {

        }

        public string GetQueryStr(int? QueryId)
        {
            string sql = dataAdapter.GetSelectItemSql();
            string strQuery = String.Empty;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@QueryId", QueryId);


            List<PLQuery> plQuery = new List<PLQuery>();
            try
            {
                var queryResult = dbConnection.Query<PLQuery>(sql, parameters, commandType: CommandType.StoredProcedure);
                if (queryResult != null)
                {
                    plQuery = queryResult.ToList();
                    strQuery = String.Concat(plQuery[0].qryFirst, plQuery[0].qryRepeating, plQuery[0].qryLast);
                }
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                throw new Exception(ex.Message);
            }

            return strQuery;
        }

        public List<T> GetQueryObjects<T>(int? QueryId, Dictionary<string, object> parametrs)
        { 
            List<T> result = new List<T>();
            string sql = GetQueryStr(QueryId);

            var queryResult = dbConnection.Query<T>(sql, parametrs);
            result = queryResult.ToList();
            return result;

        }
    }
}
