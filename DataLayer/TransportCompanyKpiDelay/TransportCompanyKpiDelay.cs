using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class TransportCompanyKpiDelay : BaseDataItem
    {
        int? _minutesDelay = 0;
        int? _kpi = 0;

        public int? MinutesDelay
        {
            get => _minutesDelay;
            set
            {
                if (!_minutesDelay.Equals(value))
                {
                    _minutesDelay = value;
                    Edit();

                }
            }
        }

        public int? Kpi
        {
            get => _kpi;
            set
            {
                if (!_kpi.Equals(value))
                {
                    _kpi = value;
                    Edit();

                }
            }
        }
    }
}
