using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_client
{
    class DoublePanel : Panel
    {
            public DoublePanel()
            {
                this.SetStyle(ControlStyles.DoubleBuffer |
         ControlStyles.UserPaint |
         ControlStyles.AllPaintingInWmPaint,
       true);
                this.UpdateStyles();
            }

    }
  
}
