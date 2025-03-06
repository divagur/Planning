
using System.Collections.Generic;

namespace Planning.Kernel
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int? id);
        bool Save(T Item);
        bool Save(List<T> Items);
    }
}
