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
    public partial class MyCircle
    {

        private Rectangle rectC;
        private int thick;
        private bool isSolid;
        private bool isFill;
        private Color color;
        private Color line_color;

        public MyCircle()
        {
            rectC = new Rectangle();
            thick = 1;
            isSolid = true;
            isFill = false;
            color = Color.Empty;
            line_color = Color.Black;
        }

        public void setRectC(Point start, Point finish, int thick, bool isSolid, bool isFill, Color line_color, Color color)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.X, finish.X);

            rectC.Width = Math.Abs(finish.X - start.X);
            rectC.Height = Math.Abs(finish.Y - start.Y);
            this.thick = thick;
            this.isSolid = isSolid;
            this.isFill = isFill;
            this.color = color;
            this.line_color = line_color;
        }
        public Rectangle getRectC()
        {
            return rectC;
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
