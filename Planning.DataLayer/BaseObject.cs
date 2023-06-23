using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class BaseObject
    {
        [DBFieldAttribute]
        public int Id { get; set; }

        public ObjectState State { get; set; }
        public BaseObject()
        {
            //id = Guid.NewGuid();
            State = ObjectState.New;
        }

    }
}
