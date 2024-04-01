using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks
{
    public class RuleRowColor
    {
        public string Operation { get; set; }
        public int Param1 { get; set; }
        public int  Param2 { get; set; }
        public int Color { get; set; }
        public Color BackgroundColorRGB { get; set; }
        public Color FontColorRGB { get; set; }
    }
}
