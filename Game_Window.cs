using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace EnJAO_alpha_test___Jimmy_Meatball
{
    public partial class Form1 : Form
    {
        //main game object for managing stuff
        private game Game = new game();

        public Form1()
        {
            InitializeComponent();
        }

        //canvas paint function - launches all the shit to draw and stuff
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = canvas.CreateGraphics();
            Game.startGraphics(g);
        }

        //stops the game before the form is closed, so it wont give an error
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.stopGame();
        }

        //gets screen resolution
        public static Screen myScreen = Screen.PrimaryScreen;
        public int sWidth = (myScreen.Bounds.Width);
        public int sHeight = (myScreen.Bounds.Height);


        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        //cmd debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();



    }
}
