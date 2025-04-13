using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class DepositorAttribute: BaseDataItem
    {
        int? _sheId;
        bool? _lvaIn;
        int? _lvaAttrLvId;
        bool? _lvaUseOrdAttr;
        string _lvaDB;
        string _lvaField;
        int? _plDepId;
        int? _plElemId;
        public bool? LvaIn 
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
        public int? LvaAttrLvId 
        { 
            get => _lvaAttrLvId;
            set
            {
                if (!_lvaAttrLvId.Equals(value))
                {
                    _lvaAttrLvId = value;
                    Edit();

                }
            } 
        }
        public bool? LvaUseOrdAttr 
        {
            get => _lvaUseOrdAttr;
            set
            {
                if (!_lvaUseOrdAttr.Equals(value))
                {
                    _lvaUseOrdAttr = value;
                    Edit();

                }
            }
        }
        public string LvaDB 
        {
            get => _lvaDB;
            set
            {
                if (_lvaDB == null || !_lvaDB.Equals(value))
                {
                    _lvaDB = value;
                    Edit();

                }
            }
        }
        public string LvaField 
        {
            get => _lvaField;
            set
            {
                if (_lvaField == null || !_lvaField.Equals(value))
                {
                    _lvaField = value;
                    Edit();

                }
            }
        }
        public int? PlDepId
        {
            get => _plDepId;
            set
            {
                if (!_plDepId.Equals(value))
                {
                    _plDepId = value;
                    Edit();

                }
            }
        }
        public int? PlElemId
        {
            get => _plElemId;
            set
            {
                if (!_plElemId.Equals(value))
                {
                    _plElemId = value;
                    Edit();

                }
            }
        }
        public int? SheId
        {
            get => _sheId;
            set
            {
                if (!_sheId.Equals(value))
                {
                    _sheId = value;
                    Edit();

                }
            }
        }
    }
}
