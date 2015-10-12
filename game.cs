using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EnJAO_alpha_test___Jimmy_Meatball
{
    class game
    {
        /* I was dumb. I didn't read about GDI+ and now this is a dead project, as GDI+ sucks
         and the performance of it is terrible. Rest in peace, EnJAO. */
        private graphics gEngine;

        public void startGraphics(Graphics g)
        {
            gEngine = new graphics(g);
            gEngine.init();

        }

        public static int cWidth = Form1.myScreen.Bounds.Width;
        public static int cHeigth = Form1.myScreen.Bounds.Height;

        public void stopGame()
        {
            gEngine.stop();
        }
    }
}
