using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportCompany : BaseDataItem
    {
        int? _code;
        string _name;
        bool? _isActive;

        public int? Code
        {
            get => _code;
            set
            {
                if (!_code.Equals(value))
                {
                    _code = value;
                    Edit();

                }
            }
        }
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

        public bool? IsActive
        {
            get => _isActive;
            set
            {
                if (!_isActive.Equals(value))
                {
                    _isActive = value;
                    Edit();
                }
            }
        }

    }
}
