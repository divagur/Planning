using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DepositorAttributeRepository:BaseRepository<DepositorAttribute, DepositorAttributeAdapter>
    {

        public DepositorAttributeRepository(string ConnectionString)
: base(ConnectionString)
        {

        }
        public DepositorAttributeRepository()
            : base()
        {

        }

    }
}
