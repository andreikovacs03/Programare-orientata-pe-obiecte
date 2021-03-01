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


        public static void Initialize(Size FormSize)
        {
            MAX_WIDTH = FormSize.Width;
            MAX_HEIGHT = FormSize.Height;
            RegularBall.InitializeBalls();
        }


        public static void Clear(System.Drawing.Graphics gfx) => gfx.Clear(Color.White);

        public static void DrawAllBalls(System.Drawing.Graphics gfx)
        {
            DrawRegularBalls(gfx);
        }

        public static void DrawRegularBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in RegularBall.Balls)
                ball.Draw(gfx);
        }

        public static void MoveAllBalls()
        {
            MoveRegularBalls();
        }

        static void MoveRegularBalls()
        {
            foreach (var ball in RegularBall.Balls)
                ball.Move();
        }

        public static void CollisionAllBalls()
        {
            CollisionRegularBalls();
        }

        static void CollisionRegularBalls()
        {
            for (int i = 0; i < RegularBall.Balls.Count - 1; i++)
            {
                for (int j = i + 1; j < RegularBall.Balls.Count; j++)

                    if (RegularBall.Balls[i].IntersectsWith(RegularBall.Balls[j]))
                    {
                        if (RegularBall.Balls[i].Radius > RegularBall.Balls[j].Radius)
                            RegularBall.Balls[i].Eats(RegularBall.Balls[j]);
                        else
                        {
                            RegularBall.Balls[j].Eats(RegularBall.Balls[i]);
                            j--;
                        }
                    }

                RegularBall.Balls[i].OutOfBoundsFix();
            }

            RegularBall.Balls[RegularBall.Balls.Count - 1].OutOfBoundsFix();
        }
    }
}
