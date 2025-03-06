using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class VolumeCalcProduct
    {
        decimal _qty;
        decimal _volume;
        decimal _weight;

        public string prdId { get; set; } = "";
        public string ordCode { get; set; } = "";

        public string prdCode { get; set; } = "";
        public string prdName { get; set; } = "";
        public decimal Qty {
            get {
                    return _qty;
                } 
            set {
                    _qty = value;
                    TotalVolume = _qty * _volume;
                    TotalWeight = _qty * _weight;
                } 
        }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Volume {
            get {
                    return _volume;
            }
            set
            {
                _volume = value;
                TotalVolume = _qty * _volume;
            }
        }
        public decimal Weight {
            get{
                return _weight;
            }
            set
            {
                _weight = value;
                TotalWeight = _qty * _weight;
            } 
        }
        public decimal TotalVolume { get; private set; }
        public decimal TotalWeight { get; private set; }


        

    }
}
