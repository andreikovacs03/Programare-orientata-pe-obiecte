using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Big_Ball_Game
{
    class RepellentBall : AbstractBall<RepellentBall>
    {
        public static int Count { get => 5; }

        public RepellentBall() : base()
        {
            Color = Color.White;
        }

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new RepellentBall());
        }

        public static void OutOfBoundsFixBalls()
        {
            foreach (var ball in Balls)
                ball.OutOfBoundsFix();
        }

        public override void Eats(RegularBall ball)
        {
            //Color = ball.Color;

            DX = Graphics.MAX_WIDTH - DX;
            DY = Graphics.MAX_HEIGHT - DY;

            ball.DX = Graphics.MAX_WIDTH - ball.DX;
            ball.DY = Graphics.MAX_HEIGHT - ball.DY;
        }
        public static void CollisionWith(List<RegularBall> regularBalls) => RegularBall.CollisionWith(Balls);

        public static void CollisionWith(List<RepellentBall> repelentBalls)
        {
            for (int i = 0; i < Balls.Count - 1; i++)
                for (int j = i + 1; j < Balls.Count; j++)
                    if (Balls[i].IntersectsWith(Balls[j]))
                        Balls[i].Eats(Balls[j]);
        }


        public override void Eats(MonsterBall ball) => throw new NotImplementedException();
        public override void Eats(RepellentBall ball)
        {
            //(Color, ball.Color) = (ball.Color, Color);
        }
    }
}
