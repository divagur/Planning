using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class GatewayRepository : BaseRepository<Gateway, GatewayDataAdapter>
    {
        
        public GatewayRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }
        public GatewayRepository()
         : base()
        {

        }
    }
}
