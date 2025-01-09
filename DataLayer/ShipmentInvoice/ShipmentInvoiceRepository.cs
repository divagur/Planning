using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentInvoiceRepository:BaseRepository<Shipment,ShipmentDataAdapter>
    {
        public ShipmentInvoiceRepository(string ConnectionString)
            : base(ConnectionString)
        {

        }
    }
}
