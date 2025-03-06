using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class MovementRepository : BaseRepository<Shipment, ShipmentDataAdapter>
    {
        public MovementRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
        public MovementRepository()
            : base()
        {

        }
    }
}
