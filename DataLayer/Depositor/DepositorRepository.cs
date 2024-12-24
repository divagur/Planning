using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;

namespace PlanningTasks.DataLayer
{
    public class DepositorRepository : BaseRepository<Depositor>
    {
        public override IBaseDataAdapter<Depositor> GetDataAdapter()
        {
            throw new NotImplementedException();
        }

        public DepositorRepository(string connectionString)
            :base(connectionString)
        {

        }

        public override Depositor GetItem(int Id)
        {
            return null;
        }

        public override List<Depositor> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                //
                
                
                var predicate = Predicates.Field<Depositor>(f => f.Name, Operator.Eq, "BAXI");
                string sQuery = $"SELECT id as {nameof(Depositor.Id)}, " +
                    $"name as {nameof(Depositor.Name)}, lv_base as {nameof(Depositor.LvBase)}, lv_id as {nameof(Depositor.LvId)} FROM depositors";
                
                


                var result =  db.Query<Depositor>($"SELECT id as {nameof(Depositor.Id)}, " +
                    $"name as {nameof(Depositor.Name)}, lv_base as {nameof(Depositor.LvBase)}, lv_id as {nameof(Depositor.LvId)} FROM depositors", predicate).ToList();
                db.Close();
                return result;
                // db.GetList<Depositor>(predicate).ToList(); 
            }

        }
    }
}
