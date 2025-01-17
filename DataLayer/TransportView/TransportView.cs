using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportView: BaseDataItem
    {
        string _name;

       
        public string Name
        {
            get => _name;
            set
            {
                
                if (_name == null || !_name.Equals(value))
                {
                    _name = value;
                    Edit();

                }
            }
        }
      

    }
}
