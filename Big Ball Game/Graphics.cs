using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Big_Ball_Game
{
    static class Graphics
    {
        internal static int MAX_WIDTH { get; set; }
        internal static int MAX_HEIGHT { get; set; }

        //static System.Drawing.Graphics gfx;

        static RegularBall[] RegularBalls = new RegularBall[RegularBall.Count];

        public static void Initialize(Size CanvasSize)
        {
            MAX_WIDTH = 800;
            MAX_HEIGHT = 600;
            InitializeRegularBalls();
        }

        static void InitializeRegularBalls()
        {
            for (int i = 0; i < RegularBalls.Length; i++)
                RegularBalls[i] = new RegularBall();
        }

        public static void Clear(System.Drawing.Graphics gfx) => gfx.Clear(Color.White);

        public static void DrawAllBalls(System.Drawing.Graphics gfx)
        {
            DrawRegularBalls(gfx);
        }

        public static void DrawRegularBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in RegularBalls)
                ball.Draw(gfx);
        }

        public static void MoveAllBalls()
        {
            MoveRegularBalls();
        }

        static void MoveRegularBalls()
        {
            foreach (var ball in RegularBalls)
                ball.Movement();
        }

        static void CollisionAllBalls()
        {
            CollisionRegularBalls();
        }

        static void CollisionRegularBalls()
        {

        }
    }
}
