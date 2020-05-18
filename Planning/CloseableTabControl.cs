using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Planning
{
    public delegate bool OnBeforeCloseTab(int indx);

    class ClosableTab : System.Windows.Forms.TabControl
    {
        public event OnBeforeCloseTab BeforeCloseATabPage;

        private Image _img;
        private Point _imageLocation = new Point(15, 5);
        private Point _imgHitArea = new Point(13, 2);

        private bool _imgExist = false;
        private int _tabWidth = 0;

        public ClosableTab()
            : base()
        {
            BeforeCloseATabPage = null;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new Point(12, 3);
        }

        public Image SetImage
        {
            set
            {
                _img = value;
                if (_img != null)
                {
                    _imgExist = true;
                }
            }
            get { return _img; }
        }

        public Point ImageLocation
        {
            get { return _imageLocation; }
            set { _imageLocation = value; }
        }

        public Point ImageHitArea
        {
            get { return _imgHitArea; }
            set { _imgHitArea = value; }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            r = GetTabRect(e.Index);
            r.Offset(2, 2);

            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;

            string title = this.TabPages[e.Index].Text;
            int stringLength = Convert.ToInt32(e.Graphics.MeasureString(title, f).Width);

            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));

            try
            {
                e.Graphics.DrawImage(_img, new Point(r.X + (GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            catch (Exception)
            {
                //MessageBox.Show("Error Loading Image: " + ex.ToString(), "");
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_imgExist == true)
            {
                Point p = e.Location;
                for (int i = 0; i < TabCount; i++)
                {
                    _tabWidth = GetTabRect(i).Width - (_imgHitArea.X);

                    Rectangle r = GetTabRect(i);
                    r.Offset(_tabWidth, _imgHitArea.Y);
                    r.Width = _img.Width;
                    r.Height = _img.Height;
                    if (r.Contains(p))
                    {
                        CloseTab(i);
                    }
                }
            }
        }

        private void CloseTab(int i)
        {
            if (BeforeCloseATabPage != null)
            {
                bool CanClose = BeforeCloseATabPage(i);
                if (!CanClose)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }
}
