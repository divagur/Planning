using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DepositorAttribute:BaseDataItem
    {
        string _name;
        int? _typeId;
        string _typeName;

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
        public int? TypeId
        {
            get => _typeId;
            set
            {
                if (!_typeId.Equals(value))
                {
                    _typeId = value;
                    Edit();

                }
            }
        }
        public string TypeName
        {
            get => _typeName;
            set
            {
                if (_typeName == null || !_typeName.Equals(value))
                {
                    _typeName = value;
                    Edit();

                }
            }
        }
    }
}
