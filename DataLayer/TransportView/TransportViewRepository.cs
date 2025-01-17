using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class TransportViewRepository : BaseRepository<TransportView, TransportViewDataAdapter>
    {
        public TransportViewRepository(string connectionString)
            :base(connectionString)
        {

        }

        public TransportView GetByNameOrCreate(string Name)
        {
            string sql = dataAdapter.GetSelectItemSql() + " where name = @viewName";
            TransportView item = null;
            var queryResult = dbConnection.Query<TransportView>(sql, new { ViewName = Name });

            if (queryResult != null && queryResult.Count() > 0)
            {
                item = queryResult.FirstOrDefault();
            }
            else
            {
                item = new TransportView();
                item.Name = Name;
                Save(item);
            }
            return item;
        }
    }
}
