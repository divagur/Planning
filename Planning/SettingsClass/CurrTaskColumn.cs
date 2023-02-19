using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{

    [Serializable]
    public class CurrTaskColumn
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int BgColor { get; set; }
        public int FontColor { get; set; }



        public CurrTaskColumn()
        {

        }
        public CurrTaskColumn(string id, string title, bool isVisible, int width)
        {
            Id = id;
            Title = title;
            Visible = isVisible;
            Width = width;
        }

    }
}
