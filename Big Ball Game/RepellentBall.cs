using System.Collections.Generic;
using System.Drawing;

namespace Big_Ball_Game
{
    internal class RepellentBall : AbstractBall<RepellentBall>
    {
        public new static int Count => 5;

        public override Color Color => Color.White;

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new RepellentBall());
        }

        public static void CollisionWith(List<RegularBall> regularBalls) => RegularBall.CollisionWith(Balls);

        public static void CollisionWith(List<RepellentBall> repellentBalls)
        {
            for (int i = 0; i < Balls.Count - 1; i++)
            for (int j = i + 1; j < Balls.Count; j++)
                if (Balls[i].IntersectsWith(Balls[j]))
                    Balls[i].Eats(Balls[j]);
        }

        public static void CollisionWith(List<MonsterBall> monsterBalls)
        {
            for (int i = 0; i < Balls.Count; i++)
            for (int j = 0; j < monsterBalls.Count; j++)
                if (Balls[i].IntersectsWith(monsterBalls[j]))
                {
                    monsterBalls[i].Eats(Balls[i]);

                    if (Balls[i].Radius < 0.4f)
                    {
                        Balls.Remove(Balls[i]);
                        i--;
                        break;
                    }
                }
        }

        public override void Eats(RegularBall ball)
        {
            //Color = ball.Color;

            DX = Graphics.MAX_WIDTH - DX;
            DY = Graphics.MAX_HEIGHT - DY;

            ball.DX = Graphics.MAX_WIDTH - ball.DX;
            ball.DY = Graphics.MAX_HEIGHT - ball.DY;
        }

        public override void Eats(MonsterBall ball) => ball.Eats(this);

        public override void Eats(RepellentBall ball)
        {
            (Color, ball.Color) = (ball.Color, Color);

            DX = Graphics.MAX_WIDTH - DX;
            DY = Graphics.MAX_HEIGHT - DY;

            ball.DX = Graphics.MAX_WIDTH - ball.DX;
            ball.DY = Graphics.MAX_HEIGHT - ball.DY;
        }
    }
}