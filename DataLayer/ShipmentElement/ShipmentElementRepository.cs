using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentElementRepository : BaseRepository<ShipmentElement, ShipmentElementDataAdapter>
    {
        public ShipmentElementRepository(string ConnectionString)
    : base(ConnectionString)
        {

        }
        public ShipmentElementRepository()
         : base()
        {

        }
    }
}
