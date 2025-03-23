using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
using Dapper;

namespace Planning.DataLayer
{
    public class TransportTypeRepository : BaseRepository<TransportType, TransportTypeDataAdapter>
    {
        public TransportTypeRepository(string connectionString)
            :base(connectionString)
        {

        }

        public TransportTypeRepository()
        : base()
        {

        }
    }
}
