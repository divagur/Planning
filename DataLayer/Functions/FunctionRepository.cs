using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class FunctionRepository: BaseRepository<Function,FunctionDataAdapter>
    {
        public FunctionRepository(string ConnectionString)
    : base(ConnectionString)
        {

        }
        public FunctionRepository()
         : base()
        {

        }
    }
}
