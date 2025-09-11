using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public class BarRendererEx : BaseRenderer
    {
        private bool useStandardBar = true;

        private int padding = 2;

        private Color backgroundColor = Color.AliceBlue;

        private Color frameColor = Color.Black;

        private float frameWidth = 1f;

        private Color fillColor = Color.BlueViolet;

        private Color startColor = Color.CornflowerBlue;

        private Color endColor = Color.DarkBlue;

        private int maximumWidth = 100;

        private int maximumHeight = 16;

        private double minimumValue;

        private double maximumValue = 100.0;

        private Pen pen;

        private Brush brush;

        private Brush backgroundBrush;

        [Category("ObjectListView")]
        [Description("Should this bar be drawn in the system style?")]
        [DefaultValue(true)]
        public bool UseStandardBar
        {
            get
            {
                return useStandardBar;
            }
            set
            {
                useStandardBar = value;
            }
        }

        [Category("ObjectListView")]
        [Description("How many pixels in from our cell border will this bar be drawn")]
        [DefaultValue(2)]
        public int Padding
        {
            get
            {
                return padding;
            }
            set
            {
                padding = value;
            }
        }

        [Category("ObjectListView")]
        [Description("The color of the interior of the bar")]
        [DefaultValue(typeof(Color), "AliceBlue")]
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }

        [Category("ObjectListView")]
        [Description("What color should the frame of the progress bar be")]
        [DefaultValue(typeof(Color), "Black")]
        public Color FrameColor
        {
            get
            {
                return frameColor;
            }
            set
            {
                frameColor = value;
            }
        }

        [Category("ObjectListView")]
        [Description("How many pixels wide should the frame of the progress bar be")]
        [DefaultValue(1f)]
        public float FrameWidth
        {
            get
            {
                return frameWidth;
            }
            set
            {
                frameWidth = value;
            }
        }

        [Category("ObjectListView")]
        [Description("What color should the 'filled in' part of the progress bar be")]
        [DefaultValue(typeof(Color), "BlueViolet")]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        [Category("ObjectListView")]
        [Description("Use a gradient to fill the progress bar starting with this color")]
        [DefaultValue(typeof(Color), "CornflowerBlue")]
        public Color GradientStartColor
        {
            get
            {
                return startColor;
            }
            set
            {
                startColor = value;
            }
        }

        [Category("ObjectListView")]
        [Description("Use a gradient to fill the progress bar ending with this color")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color GradientEndColor
        {
            get
            {
                return endColor;
            }
            set
            {
                endColor = value;
            }
        }

        [Category("Behavior")]
        [Description("The progress bar will never be wider than this")]
        [DefaultValue(100)]
        public int MaximumWidth
        {
            get
            {
                return maximumWidth;
            }
            set
            {
                maximumWidth = value;
            }
        }

        [Category("Behavior")]
        [Description("The progress bar will never be taller than this")]
        [DefaultValue(16)]
        public int MaximumHeight
        {
            get
            {
                return maximumHeight;
            }
            set
            {
                maximumHeight = value;
            }
        }

        [Category("Behavior")]
        [Description("The minimum data value expected. Values less than this will given an empty bar")]
        [DefaultValue(0.0)]
        public double MinimumValue
        {
            get
            {
                return minimumValue;
            }
            set
            {
                minimumValue = value;
            }
        }

        [Category("Behavior")]
        [Description("The maximum value for the range. Values greater than this will give a full bar")]
        [DefaultValue(100.0)]
        public double MaximumValue
        {
            get
            {
                return maximumValue;
            }
            set
            {
                maximumValue = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Pen Pen
        {
            get
            {
                if (pen == null && !FrameColor.IsEmpty)
                {
                    return new Pen(FrameColor, FrameWidth);
                }

                return pen;
            }
            set
            {
                pen = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Brush Brush
        {
            get
            {
                if (brush == null && !FillColor.IsEmpty)
                {
                    return new SolidBrush(FillColor);
                }

                return brush;
            }
            set
            {
                brush = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Brush BackgroundBrush
        {
            get
            {
                if (backgroundBrush == null && !BackgroundColor.IsEmpty)
                {
                    return new SolidBrush(BackgroundColor);
                }

                return backgroundBrush;
            }
            set
            {
                backgroundBrush = value;
            }
        }

        public BarRendererEx()
        {
        }

        public BarRendererEx(int minimum, int maximum)
            : this()
        {
            MinimumValue = minimum;
            MaximumValue = maximum;
        }

        public BarRendererEx(Pen pen, Brush brush)
            : this()
        {
            Pen = pen;
            Brush = brush;
            UseStandardBar = false;
        }

        public BarRendererEx(int minimum, int maximum, Pen pen, Brush brush)
            : this(minimum, maximum)
        {
            Pen = pen;
            Brush = brush;
            UseStandardBar = false;
        }

        public BarRendererEx(Pen pen, Color start, Color end)
            : this()
        {
            Pen = pen;
            SetGradient(start, end);
        }

        public BarRendererEx(int minimum, int maximum, Pen pen, Color start, Color end)
            : this(minimum, maximum)
        {
            Pen = pen;
            SetGradient(start, end);
        }

        public void SetGradient(Color start, Color end)
        {
            GradientStartColor = start;
            GradientEndColor = end;
        }

        public override void Render(Graphics g, Rectangle r)
        {
            DrawBackground(g, r);
            r = ApplyCellPadding(r);
            Rectangle inner = Rectangle.Inflate(r, -Padding, -Padding);
            inner.Width = Math.Min(inner.Width, MaximumWidth);
            inner.Height = Math.Min(inner.Height, MaximumHeight);
            inner = AlignRectangle(r, inner);
            if (!(base.Aspect is IConvertible convertible))
            {
                return;
            }

            double num = convertible.ToDouble(NumberFormatInfo.InvariantInfo);
            Rectangle rect = Rectangle.Inflate(inner, -1, -1);
            if (num <= MinimumValue)
            {
                rect.Width = 0;
            }
            else if (num < MaximumValue)
            {
                rect.Width = (int)((double)rect.Width * (num - MinimumValue) / MaximumValue);
            }

            if (UseStandardBar && ProgressBarRenderer.IsSupported && !base.IsPrinting)
            {
                CellVerticalAlignment = StringAlignment.Center;
                ProgressBarRenderer.DrawHorizontalBar(g, inner);
                ProgressBarRenderer.DrawHorizontalChunks(g, rect);
                /*
                StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
                fmt.LineAlignment = StringAlignment.Center;
                fmt.Trimming = StringTrimming.EllipsisCharacter;
                switch (this.Column.TextAlign)
                {
                    case HorizontalAlignment.Center: fmt.Alignment = StringAlignment.Center; break;
                    case HorizontalAlignment.Left: fmt.Alignment = StringAlignment.Near; break;
                    case HorizontalAlignment.Right: fmt.Alignment = StringAlignment.Far; break;
                }
                g.DrawString((Math.Round(num, 2) * 100).ToString()+"%", this.Font, this.TextBrush, r, fmt);
                //DrawText(g, r, (Math.Round(num,2)*100).ToString());*/
                return;
            }

            g.FillRectangle(BackgroundBrush, inner);
            if (rect.Width > 0)
            {
                rect.Width++;
                rect.Height++;
                if (GradientStartColor == Color.Empty)
                {
                    g.FillRectangle(Brush, rect);
                }
                else
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(inner, GradientStartColor, GradientEndColor, LinearGradientMode.Horizontal);
                    g.FillRectangle(linearGradientBrush, rect);
                }
            }

            g.DrawRectangle(Pen, inner);
            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            switch (this.Column.TextAlign)
            {
                case HorizontalAlignment.Center: fmt.Alignment = StringAlignment.Center; break;
                case HorizontalAlignment.Left: fmt.Alignment = StringAlignment.Near; break;
                case HorizontalAlignment.Right: fmt.Alignment = StringAlignment.Far; break;
            }
            g.DrawString((Math.Round(num, 2) * 100).ToString() + "%", this.Font, this.TextBrush, r, fmt);
        }

        protected override Rectangle HandleGetEditRectangle(Graphics g, Rectangle cellBounds, OLVListItem item, int subItemIndex, Size preferredSize)
        {
            return CalculatePaddedAlignedBounds(g, cellBounds, preferredSize);
        }
    }
}
