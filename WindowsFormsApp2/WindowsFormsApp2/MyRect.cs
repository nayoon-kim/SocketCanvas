using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace WindowsFormsApp2
{
    [Serializable]
    class MyRect
    {
        private Rectangle rect;
        private int thick;
        private bool isSolid;
        private bool isFill;
        private Color color;
        private Color line_color;
        public MyRect()
        {
            rect = new Rectangle();
            thick = 1;
            isSolid = true;
            isFill = false;
            color = Color.Empty;
            line_color = Color.Black;
        }

        public void setRect(Point start, Point finish, int thick, bool isSolid, bool isFill, Color line_color, Color color)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            this.thick = thick;
            this.isSolid = isSolid;
            this.isFill = isFill;
            this.color = color;
            this.line_color = line_color;
        }
        public Rectangle getRect()
        {
            return rect;
        }
        public int getThick()
        {
            return thick;
        }
        public bool getSolid()
        {
            return isSolid;
        }
        public bool getFill()
        {
            return isFill;
        }
        public Color getColor()
        {
            return color;
        }
        public Color getLineColor()
        {
            return line_color;
        }
    }

}