using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class SupplierRepository : BaseRepository<Supplier, SupplierDataAdapter>
    {
        
        public SupplierRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }
        public SupplierRepository()
         : base()
        {

        }
    }
}
