using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks.DataLayer
{
    public abstract class BaseRepository<T>
        where T : BaseObject
    {
        IBaseDataAdapter<T> _dataAdapter;
        string _connectionString;

        public BaseRepository(string connectionString)
        {
            //_dataAdapter = GetDataAdapter();
            _connectionString = connectionString;
        }

        public abstract IBaseDataAdapter<T> GetDataAdapter();
        public abstract List<T> GetList();
        public abstract T GetItem(int Id);
        public string ConnectionString { get => _connectionString; }
        
    }
}
