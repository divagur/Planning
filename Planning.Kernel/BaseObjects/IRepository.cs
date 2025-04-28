
using System.Collections.Generic;

namespace Planning.Kernel
{
    public interface IRepository<T> where T : BaseDataItem
    { 
        List<T> GetAll();
       
        T GetById(int? id);
        bool Save(T Item);
        bool Save(List<T> Items);

        string GetLastError();
    }
    /*
    interface IDataSource<out T> where T : class
    {
        IEnumerable<T> GetAll();
    }

    interface IRepository<T> : IDataSource<T> where T : BaseDataItem
    {
        void Save(T t);
        void Delete(T t);
    }
    */
}
