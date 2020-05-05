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
    class MyLines
    {
        private Point[] point = new Point[2];
        private int thick;
        private bool isSolid;
        private Color line_color;

        public MyLines()
        {
            point[0] = new Point();
            point[1] = new Point();
            thick = 1;
            isSolid = true;
            line_color = Color.Black;
        }

        public void setPoint(Point start, Point finish, int thick, bool isSolid, Color line_color)
        {
            point[0] = start;
            point[1] = finish;
            this.thick = thick;
            this.isSolid = isSolid;
            this.line_color = line_color;
        }
        public Point getPoint1()
        {
            return point[0];
        }
        public Point getPoint2()
        {
            return point[1];
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