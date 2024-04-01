using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks
{
    public class CurrentTask
    {
        public DateTime? ShpDate { get; set; }
        public TimeSpan? SlotTime { get; set; }
        public string InOut { get; set; }
        public int LvOrderId { get; set; }
        public string LvOrderCode { get; set; }
        public string KlientName { get; set; }
        public string PrcReady { get; set; }
        public decimal? DoneShare { get; set; }
        public string GateName { get; set; }
        public int? ShippingPlacesNumber { get; set; }
        public int? DepositCount { get; set; }
        public int? AssemblyPicking { get; set; }
        public int? AssemblyPallet { get; set; }
        public int? AssemblyMezzanine { get; set; }
        public int? FontColor { get; set; }
        public int? BackgroundColor { get; set; }
        public Color BackgroundColorRGB { get; set; }
        public Color FontColorRGB { get; set; }
    }
}
