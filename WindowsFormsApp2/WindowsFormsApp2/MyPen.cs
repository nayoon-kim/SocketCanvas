using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    class MyPen
    {
        private Point current;
        private Point old;
        private int thick;
        private bool isSolid;
        private Color line_color;

        public MyPen()
        {
            current = new Point();
            old = new Point();
            thick = 1;
            isSolid = true;
            line_color = Color.Black;
        }
        public void setPen(Point old, Point current, int thick, bool isSolid, Color line_color)
        {
            this.old = old;
            this.current = current;
            this.thick = thick;
            this.isSolid = isSolid;
            this.line_color = line_color;
        }
        public Point getOld()
        {
            return old;
        }
        public Point getCurrent()
        {
            return current;
        }
        public int getThick()
        {
            return thick;
        }
        public bool getSolid()
        {
            return isSolid;
        }
        public Color getLineColor()
        {
            return line_color;
        }
    }
}
