using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_client
{
    [Serializable]
    public class All_Shapes
    {
        public int thick;
        public int pre_thick;
        public bool isSolid;
        public Color line_color;
        public Point start;
        public Point finish;

        public int width;
        public int height;

        public int X;
        public int Y;

        public All_Shapes()
        {
 
            thick = 1;
            isSolid = true;
            
            line_color = Color.Black;
        }
        public void SetShape(int thick, bool isSolid, Color line_color, Point start, Point finish)
        {
            this.thick = thick;
            this.isSolid = isSolid;
            this.line_color = line_color;
            this.start = start;
            this.pre_thick = thick;
            this.finish = finish;
            this.X = Math.Abs(start.X - finish.X) / 2;
            this.Y = Math.Abs(start.Y - finish.Y) / 2;
            this.width = Math.Abs(finish.X - start.X);
            this.height = Math.Abs(finish.Y - start.Y);
        }
        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height;
        }
            
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public void setX(int X)
        {
            this.X = X;
        }
        public void setY(int Y)
        {
            this.Y = Y;
        }
        public Point getStart()
        {
            return start;
        }
        public Point getFinish()
        {
            return finish;
        }
        public void setStart(Point start)
        {
            this.start = start;
        }
        public void setFinish(Point finish)
        {
            this.finish = finish;
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
