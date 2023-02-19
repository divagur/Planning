using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class VolumeCalcParams
    {
        public int ImportStartRow { get; set; } = 2;
        public int ImportColVendorCode { get; set; } = 1;
        public int ImportColName { get; set; } = 2;
        public int ImportColAmount { get; set; } = 3;


    }
}
