using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class Depositor: BaseDataItem
    {
        string _name;
        string _lvBase;
        int? _lvId;
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
        public string LvBase
        {
            get => _lvBase;
            set
            {
                if (_lvBase == null || !_lvBase.Equals(value))
                {
                    _lvBase = value;
                    Edit();

                }
            }
        }
        public int? LvId
        {
            get => _lvId;
            set
            {
                if (!_lvId.Equals(value))
                {
                    _lvId = value;
                    Edit();

                }
            }
        }
    }
}
