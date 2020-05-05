using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace winform_client
{
    [Serializable]
    public partial class MyRect : All_Shapes
    {
        private Rectangle rect;
        //private int thick;
        //private int pre_thick;
        //private bool isSolid;
        private bool isFill;
        private Color color;
       // private Color line_color;
        //private Point start;
       // private Point finish;
        private int width;
        private int height;
        public MyRect()
        {
            rect = new Rectangle();
            //thick = 1;
            //isSolid = true;
            isFill = false;
            color = Color.Empty;
           // line_color = Color.Black;
        }

        public void setRect(Point start, Point finish, int thick, bool isSolid, bool isFill, Color line_color, Color color)
        {
            base.SetShape(thick, isSolid, line_color, start, finish);
            //this.start = start;
            //this.finish = finish;
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            width = rect.Width;
            height = rect.Height;
            //this.thick = thick;
            //this.pre_thick = thick;
            this.isFill = isFill;
            this.color = color;
            
        }
        public void setSize(int lines, int wheel_line)
        {
            if (lines < 0)
            {
                //if (wheel_line <= 5)
                ////if (rect.Width * 10 < Math.Pow((10), 7))
                //{
                    if (thick < pre_thick * 10)
                {
                    rect.Width = (int)Math.Round(rect.Width * 1.1);
                    rect.Height = (int)Math.Round(rect.Height * 1.1);
                    rect.X = (int)Math.Round(rect.X * 1.1);
                    rect.Y = (int)Math.Round(rect.Y * 1.1);
                    thick = (int)Math.Round(thick * 1.5);
                }

            }
            else if (lines > 0)
            {
                //if ((int)(rect.Width * 0.9)>width ||(int)(rect.Height * 0.9) >height)
                if(wheel_line > 0)
                {
                    rect.Width = (int)Math.Round(rect.Width * 0.9);
                    rect.Height = (int)Math.Round(rect.Height * 0.9);
                    rect.X = (int)Math.Round(rect.X * 0.9);
                    rect.Y = (int)Math.Round(rect.Y * 0.9);
                    thick = (int)Math.Round(thick * 0.55);
                }
                else if (thick > pre_thick)
                {
                    rect.Width = width;
                    rect.Height = height;
                    rect.X = Math.Min(start.X, finish.X);
                    rect.Y = Math.Min(start.Y, finish.Y);
                    thick = pre_thick;
                }
            }
            
        }
        public int getSize()
        {
            return rect.Width;
        }
        public Rectangle getRect()
        {
            return rect;
        }
        public bool getFill()
        {
            return isFill;
        }
        public Color getColor()
        {
            return color;
        }

    }

}