using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
namespace Planning.Kernel
{
    public class DelayReasonsRepository : BaseRepository<DelayReasons, DelayReasonsDataAdapter>
    {
        
        public DelayReasonsRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }

       
        /*
        public override List<DelayReasons> GetAll()
        {
            string sql = $@"select id as {nameof(DelayReasons.Id)}, name as {nameof(DelayReasons.Name)} from delay_reasons";
            var queryResult = dbConnection.Query<DelayReasons>(sql);

            return queryResult.ToList();
        }

        public override DelayReasons GetById(int id)
        {
            string sql = $@"select id as {nameof(DelayReasons.Id)}, name as {nameof(DelayReasons.Name)} from delay_reasons where id = @Id";            
            DelayReasons delayReasons = null;
            var queryResult = dbConnection.Query<DelayReasons>(sql, new { Id = id });

            if (queryResult != null)
            {
                delayReasons = queryResult.FirstOrDefault();
            }
            return delayReasons;
        }
        */
   
    }
}
