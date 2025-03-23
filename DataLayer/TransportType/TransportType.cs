using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportType: BaseDataItem
    {
        string _name;
        int? _tonnage;


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
        public int? Tonnage
        {
            get => _tonnage;
            set
            {

                if (!_tonnage.Equals(value))
                {
                    _tonnage = value;
                    Edit();

                }
            }
        }

    }
}
