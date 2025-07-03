using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public class GridRender : BaseRenderer
    {
       

        public override void Render(Graphics g, Rectangle r)
        {
            /*
            Pen pen = new Pen(Color.FromArgb(255,0,0));
            g.DrawRectangle(pen, r);*/
            using (LinearGradientBrush gradient = new LinearGradientBrush(r, Color.Gold, Color.Fuchsia, 0.0))
            {
                Brush brush = new SolidBrush(GetBackgroundColor());
                Pen pen = new Pen(Color.Red);                
                g.FillRectangle(brush, r);
                g.DrawRectangle(pen, r);
            }
            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            switch (this.Column.TextAlign)
            {
                case HorizontalAlignment.Center: fmt.Alignment = StringAlignment.Center; break;
                case HorizontalAlignment.Left: fmt.Alignment = StringAlignment.Near; break;
                case HorizontalAlignment.Right: fmt.Alignment = StringAlignment.Far; break;
            }
            g.DrawString(this.GetText(), this.Font, this.TextBrush, r, fmt);


        }
    }
}
