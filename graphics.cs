using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace EnJAO_alpha_test___Jimmy_Meatball
{
    class graphics
    {
        //members
        private Graphics drawHandle;
        private Thread renderThread;

        //you need to set the bitmaps here as textures
        //it makes gdi+ work faster

        private Bitmap tex_jmeat;


        //functions
        public graphics(Graphics g)
        {
            drawHandle = g;
        }

        public void init()
        {
            //must load assets before rendering duh
            loadAssets();
            Console.WriteLine("Assets loaded successfully");

            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        //loads resources
        private void loadAssets()
        {
            tex_jmeat = EnJAO_alpha_test___Jimmy_Meatball.Properties.Resources.jmeat;
        }


        public void stop()
        {
            renderThread.Abort();
            Console.Read();
        }

        private void render()
        {
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(Form1.myScreen.Bounds.Width, Form1.myScreen.Bounds.Height);
            Graphics frameGraphics = Graphics.FromImage(frame);

            while (true)
            {
                
                int width = Form1.myScreen.Bounds.Width;
                int height = Form1.myScreen.Bounds.Height;
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, width, height);

                //negrice
                int hHalf = Form1.myScreen.Bounds.Height / 2 - 32;
                int wHalf = Form1.myScreen.Bounds.Width / 2 -32;
                //acabou negrice
                frameGraphics.DrawImage(tex_jmeat, wHalf, hHalf);
                
                
                //draws the frame
                drawHandle.DrawImage(frame, 0, 0);

                //benchmarking
                framesRendered++;
                if(Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("gEngine: " + framesRendered + "fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }



        }
    }
}
