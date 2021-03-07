using System.Drawing;

namespace Big_Ball_Game
{
    internal static class Graphics
    {
        internal static int MAX_WIDTH { get; set; }
        internal static int MAX_HEIGHT { get; set; }

        public static void Initialize(Size formSize)
        {
            MAX_WIDTH = formSize.Width;
            MAX_HEIGHT = formSize.Height;
            RegularBall.InitializeBalls();
            MonsterBall.InitializeBalls();
            RepellentBall.InitializeBalls();
        }

        public static void DrawAllBalls(System.Drawing.Graphics gfx)
        {
            RegularBall.DrawBalls(gfx);
            MonsterBall.DrawBalls(gfx);
            RepellentBall.DrawBalls(gfx);
        }

        public static void MoveAllBalls()
        {
            RegularBall.MoveBalls();
            RepellentBall.MoveBalls();

            CollisionAllBalls();
            OutOfBoundsFixAllBalls();
        }

        public static void CollisionAllBalls()
        {
            RegularBall.CollisionWith(RegularBall.Balls);
            RegularBall.CollisionWith(MonsterBall.Balls);
            RegularBall.CollisionWith(RepellentBall.Balls);

            RepellentBall.CollisionWith(RepellentBall.Balls);
            RepellentBall.CollisionWith(MonsterBall.Balls);
        }

        public static void OutOfBoundsFixAllBalls()
        {
            RegularBall.OutOfBoundsFixBalls();
            MonsterBall.OutOfBoundsFixBalls();
            RepellentBall.OutOfBoundsFixBalls();
        }
    }
}
