using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class BaseDataManager<T>
        where T: BaseObject
    {
        MSSqlAdapter adapter = new MSSqlAdapter();
        //ISqlAdaper sqlAdaper = new ISqlAdaper();
        public List<T> GetList(string Where)
        {
            return adapter.GetObjects<T>(Where);
        }

        public void Save(T item)
        {
            adapter.Save(item);
        }


        public void Save(List<T> listItems)
        {
            adapter.Save(listItems);
        }

    }
}
