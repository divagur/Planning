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
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DepositorRepository : BaseRepository<Depositor, DepositorAdapter>
    {
        public DepositorRepository(string ConnectionString)
        : base(ConnectionString)
        {

        }
    }
}
