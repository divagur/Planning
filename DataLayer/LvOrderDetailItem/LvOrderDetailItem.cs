using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning
{
    public class LvOrderDetailItem:BaseDataItem
    {
        string _primaryCode;
        string _shortDescription;
        decimal? _quantity;
        int? _detailType;

        public string PrimaryCode 
        {
            get => _primaryCode;
            set
            {
                if (_primaryCode == null || !_primaryCode.Equals(value))
                {
                    _primaryCode = value;
                    Edit();

                }
            }
        }
        public string ShortDescription 
        {
            get => _shortDescription;
            set
            {
                if (_shortDescription == null || !_shortDescription.Equals(value))
                {
                    _shortDescription = value;
                    Edit();

                }
            }
        }
        public decimal? Quantity 
        {
            get => _quantity;
            set
            {
                if (!_quantity.Equals(value))
                {
                    _quantity = value;
                    Edit();

                }
            }
        }
        public int? DetailType 
        {
            get => _detailType;
            set
            {
                if (!_detailType.Equals(value))
                {
                    _detailType = value;
                    Edit();

                }
            }
        }
    }
}
