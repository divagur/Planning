using System;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class DelayReasonRepository : BaseRepository<DelayReason, DelayReasonDataAdapter>
    {
        
        public DelayReasonRepository(string ConnectionString)
            : base(ConnectionString)
        {
            
        }
        public DelayReasonRepository()
         : base()
        {

        }
    }
}
