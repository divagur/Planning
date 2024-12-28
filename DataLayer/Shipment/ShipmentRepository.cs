using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentRepository:BaseRepository<Shipment,ShipmentDataAdapter>
    {
        public ShipmentRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
    }
}
