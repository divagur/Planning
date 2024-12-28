using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public interface IBaseDataAdapter<T>
        where T: BaseObject
    {
        List<T> GetList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);

    }
}
