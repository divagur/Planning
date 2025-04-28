using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentElement: BaseDataItem
    {
        string _fieldName;
        string _fieldDbName;
        string _fieldTypeName;
        int? _fieldType;
        public string FieldName
        {
            get => _fieldName;
            set
            {
                if (_fieldName == null || !_fieldName.Equals(value))
                {
                    _fieldName = value;
                    Edit();

                }
            }
        }
        public string FieldDbName
        {
            get => _fieldDbName;
            set
            {
                if (_fieldDbName == null || !_fieldDbName.Equals(value))
                {
                    _fieldDbName = value;
                    Edit();

                }
            }
        }
        public string FieldTypeName
        {
            get => _fieldTypeName;
            set
            {
                if (_fieldTypeName == null || !_fieldTypeName.Equals(value))
                {
                    _fieldTypeName = value;
                    Edit();

                }
            }
        }
        public int? FieldType 
        { 
            get => _fieldType;
            set
            {
                if (!_fieldType.Equals(value))
                {
                    _fieldType = value;
                    Edit();

                }
            }
        }

    }
}
