using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class Warehouse: BaseDataItem
    {
        string _code;
        string _name;
        string _descr;

        public string Code
        {
            get => _code;
            set
            {
                //if (!_code.Equals(value))
                //{
                    _code = value;
                    Edit();

                //}
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                //if (!_name.Equals(value))
                //{
                    _name = value;
                    Edit();

                //}
            }
        }

        public string Descr
        {
            get => _descr;
            set
            {
                //if (!_descr.Equals(value))
                //{
                    _descr = value;
                    Edit();

                //}
            }
        }

    }
}
