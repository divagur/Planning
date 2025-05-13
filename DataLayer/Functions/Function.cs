using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class Function:BaseDataItem
    {
        string _name;
        string _code;

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
        public string Code
        {
            get => _code;
            set
            {
                if (_code == null || !_code.Equals(value))
                {
                    _code = value;
                    Edit();

                }
            }
        }
    }
}
