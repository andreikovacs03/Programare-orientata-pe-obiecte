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
            MonsterBall.InitializeBalls();
            RepellentBall.InitializeBalls();
        }

        public static void DrawAllBalls(System.Drawing.Graphics gfx)
        {
            DrawRegularBalls(gfx);
            DrawMonsterBalls(gfx);
            DrawRepelentBalls(gfx);
        }

        public static void DrawRegularBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in RegularBall.Balls)
                ball.Draw(gfx);
        }

        public static void DrawMonsterBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in MonsterBall.Balls)
                ball.Draw(gfx);
        }

        public static void DrawRepelentBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in RepellentBall.Balls)
                ball.Draw(gfx);
        }

        public static void MoveAllBalls()
        {
            MoveRegularBalls();
            MoveRepelentBalls();

            CollisionAllBalls();
            OutOfBoundsFixAllBalls();
        }

        static void MoveRegularBalls()
        {
            foreach (var ball in RegularBall.Balls)
                ball.Move();
        }

        static void MoveRepelentBalls()
        {
            foreach (var ball in RepellentBall.Balls)
                ball.Move();
        }

        public static void CollisionAllBalls()
        {
            RegularBall.CollisionWith(RegularBall.Balls);
            RegularBall.CollisionWith(MonsterBall.Balls);
            //RegularBall.CollisionWith(RepellentBall.Balls);

            //RepellentBall.CollisionWith(RepellentBall.Balls);
        }

        static void OutOfBoundsFixAllBalls()
        {
            RegularBall.OutOfBoundsFixBalls();
            MonsterBall.OutOfBoundsFixBalls();
            //RepellentBall.OutOfBoundsFixBalls();
        }
    }
}
