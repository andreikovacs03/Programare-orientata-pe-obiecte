using System;
using System.Drawing;

namespace Big_Ball_Game
{
    internal class MonsterBall : AbstractBall<MonsterBall>
    {
        public new static int Count => 5;

        public override Color Color => Color.Black;

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new MonsterBall());
        }

        public override void OutOfBoundsFix()
        {
            if (X <= Radius)
                X += Radius - X;

            else if (X >= Graphics.MAX_WIDTH - Radius)
                X -= X + Radius - Graphics.MAX_WIDTH;

            if (Y <= Radius)
                Y += Radius - Y;

            else if (Y >= Graphics.MAX_HEIGHT - Radius)
                Y -= Y + Radius - Graphics.MAX_HEIGHT;
        }

        public override void Eats(RegularBall ball)
        {
            BallGrowth += ball.Radius;
            OutOfBoundsFix();
            RegularBall.Balls.Remove(ball);
        }

        public override void Eats(MonsterBall ball) => throw new NotImplementedException();

        public override void Eats(RepellentBall ball)
        {
            ball.Radius /= 2;
            ball.DX = Graphics.MAX_WIDTH - ball.DX;
            ball.DY = Graphics.MAX_HEIGHT - ball.DY;
        }
    }
}