using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Big_Ball_Game
{
    class MonsterBall : AbstractBall<MonsterBall>
    {
        public static int Count { get => 30; }

        public override Color Color { get => Color.Black; }

        public MonsterBall() : base() { }

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

        public static void OutOfBoundsFixBalls()
        {
            foreach (var ball in Balls)
                ball.OutOfBoundsFix();
        }

        public override void Eats(RegularBall ball)
        {
            Radius += ball.Radius;
            OutOfBoundsFix();
            RegularBall.Balls.Remove(ball);
        }

        public override void Eats(MonsterBall ball) => throw new NotImplementedException();
        public override void Eats(RepellentBall ball) => throw new NotImplementedException();
    }
}
