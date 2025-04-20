using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;
namespace Planning.DataLayer
{
    public class PLAttribute: BaseDataItem
    {
        int? _spaId;
        string _spaName;
        int? _pLFieldId;
        string _pLField;
        int? _lvaIn;
        string _lvaType;

        public int? SpaId
        {
            get => _spaId;
            set
            {
                if (!_spaId.Equals(value))
                {
                    _spaId = value;
                    Edit();

                }
            }
        }
        public string SpaName
        {
            get => _spaName;
            set 
            {
                if (_spaName == null || !_spaName.Equals(value))
                {
                    _spaName = value;
                    Edit();

                }
            }
        }
        public int? PLFieldId
        {
            get => _pLFieldId;
            set
            {
                if (!_pLFieldId.Equals(value))
                {
                    _pLFieldId = value;
                    Edit();

                }
            }
        }
        public string PLField
        {
            get => _pLField;
            set
            {
                if (_pLField == null || !_pLField.Equals(value))
                {
                    _pLField = value;
                    Edit();

                }
            }
        }
        public int? LvaIn
        {
            get => _lvaIn;
            set
            {
                if (!_lvaIn.Equals(value))
                {
                    _lvaIn = value;
                    Edit();

                }
            }
        }
        public string LvaType
        {
            get => _lvaType;
            set
            {
                if (_lvaType == null || !_lvaType.Equals(value))
                {
                    _lvaType = value;
                    Edit();

                }
            }
        }
    }
}
