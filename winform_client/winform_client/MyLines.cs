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
    public partial class MyLines : All_Shapes
    {
        private Point old;
        private Point current;
        public MyLines()
        {

        }

        public void setPoint(Point start, Point finish, int thick, bool isSolid, Color line_color)
        {
            base.SetShape(thick, isSolid, line_color, start, finish);
            old = start;
            current = finish;
        }
        public void setSize(int lines,int wheel_line)
        {
            if (lines < 0)
            {
                if (thick < pre_thick * 10)
                {
                    //if (wheel_line <= 5) { 
                    start.X = (int)Math.Round(start.X * 1.1);
                    start.Y = (int)Math.Round(start.Y * 1.1);
                    finish.X = (int)Math.Round(finish.X * 1.1);
                    finish.Y = (int)Math.Round(finish.Y * 1.1);
                    thick = (int)Math.Round(thick * 1.5);
                }
            }
            else if (lines > 0)
            {
                //if (start.X > old.X || start.Y > old.Y)
                //{
                if(wheel_line > 0){
                    start.X = (int)Math.Round(start.X * 0.9);
                    start.Y = (int)Math.Round(start.Y * 0.9);
                    finish.X = (int)Math.Round(finish.X * 0.9);
                    finish.Y = (int)Math.Round(finish.Y * 0.9);
                    thick = (int)Math.Round(thick * 0.55);
                }
                else if (thick > pre_thick)
                {
                    start.X = old.X;
                    start.Y = old.Y;
                    finish.X = current.X;
                    finish.Y = current.Y;
                    thick = pre_thick;
                }

            }

        }

    }
}