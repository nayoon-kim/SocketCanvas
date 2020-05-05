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
    public partial class MyCircle : All_Shapes
    {

        private Rectangle rectC;


        private Point old;
       // private Point current;

        private bool isFill;
        private Color color;
      
        private int width;
        private int height;
        public MyCircle()
        {
            rectC = new Rectangle();
     
            isFill = false;
            color = Color.Empty;

        }

        public void setRectC(Point start, Point finish, int thick, bool isSolid, bool isFill, Color line_color, Color color)
        {
            base.SetShape(thick, isSolid, line_color, start, finish);

            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.X, finish.X);
            old.X = rectC.X;
            old.Y = rectC.Y;
            rectC.Width = Math.Abs(finish.X - start.X);
            rectC.Height = Math.Abs(finish.Y - start.Y);
            this.width = rectC.Width;
            this.height = rectC.Height;
      
            this.isFill = isFill;
            this.color = color;

        }
        public void setSize(int lines, int wheel_line)
        {
            if (lines < 0)
            {
                //if (rectC.Width * 10 < Math.Pow((10), 7))
                //{
                if (thick < pre_thick * 10)
                {

                    //if (wheel_line <= 5){
                    rectC.Width = (int)Math.Round(rectC.Width * 1.1);
                    rectC.Height = (int)Math.Round(rectC.Height * 1.1);
                    rectC.X = (int)Math.Round(rectC.X * 1.1);
                    rectC.Y = (int)Math.Round(rectC.Y * 1.1);
                    thick = (int)Math.Round(thick * 1.5);
                    //rectC.Width = (int)Math.Round(rectC.Width * Math.Pow(1.01, wheel_line));
                    //rectC.Height = (int)Math.Round(rectC.Height * Math.Pow(1.01, wheel_line));
                    //rectC.X = (int)Math.Round(rectC.X * Math.Pow(1.01, wheel_line));
                    //rectC.Y = (int)Math.Round(rectC.Y * Math.Pow(1.01, wheel_line));
                    //thick = (int)Math.Round(thick * Math.Pow(1.05, wheel_line));
                }
            }
            else if (lines > 0)
            {
                //if ((int)(rectC.Width * 0.9) > width || (int)(rectC.Height * 0.9) > height)
                //{
                if (wheel_line > 0)
                {
                    rectC.Width = (int)Math.Round(rectC.Width * 0.9);
                    rectC.Height = (int)Math.Round(rectC.Height * 0.9);
                    rectC.X = (int)Math.Round(rectC.X * 0.9);
                    rectC.Y = (int)Math.Round(rectC.Y * 0.9);
                    thick = (int)Math.Round(thick * 0.5);
                    //rectC.Width = (int)Math.Round(rectC.Width * Math.Pow(1.01, -wheel_line));
                    //rectC.Height = (int)Math.Round(rectC.Height * Math.Pow(1.01, -wheel_line));
                    //rectC.X = (int)Math.Round(rectC.X * Math.Pow(1.01, -wheel_line));
                    //rectC.Y = (int)Math.Round(rectC.Y * Math.Pow(1.01, -wheel_line));
                    //thick = (int)Math.Round(thick * Math.Pow(1.05, -wheel_line));
                }
                else if(thick>pre_thick)
                {
                    rectC.Width = width;
                    rectC.Height = height;
                    rectC.X = old.X;
                    rectC.Y = old.Y;
                    thick = pre_thick;
                }
            }

        }
        public Rectangle getRectC()
        {
            return rectC;
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
