﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big_Ball_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FPS_Tick(object sender, EventArgs e)
        {
            Graphics.MoveAllBalls();
            Graphics.CollisionAllBalls();
            Canvas.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics.Initialize(ClientSize);
            FPS.Start();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics.DrawAllBalls(e.Graphics);
            //e.Graphics.FillEllipse(new SolidBrush(Color.Black), ClientSize.Width - 50, ClientSize.Height - 50, 100, 100);
        }
    }
}
