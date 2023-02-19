using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    [Serializable]
    public class VolumeCalcConstant
    {
        public string Name { get; set; }
        public decimal PalletWeight { get; set; }
        public decimal PalletHeight { get; set; }
        public decimal PalletVolume { get; set; }
        public decimal PalleteDimensions { get; set; }
    }
}
