using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Big_Ball_Game
{
    internal abstract class AbstractBall<T> : IBall where T : new()
    {
        public static int Count { get; }
        public float X { get; set; }
        public float Y { get; set; }

        public virtual float DX { get; set; } = new[] { -10, Graphics.MAX_WIDTH + 10 }[Rnd.Next(2)];
        public virtual float DY { get; set; } = new[] { -10, Graphics.MAX_HEIGHT + 10 }[Rnd.Next(2)];

        public float Radius { get; set; }
        protected float RADIUS_MIN => 2.5f;
        protected float RADIUS_MAX => 4f;
        protected float Speed { get; set; }

        protected static float SPEED_MIN => 1.5f;
        protected static float SPEED_MAX => 5.5f;

        public virtual Color Color { get; set; } = Color.FromArgb(Rnd.Next(256), Rnd.Next(256), Rnd.Next(256));
        protected static Color OutlineColor => Color.Black;
        protected static float OutlineWidth => 1.5f;

        protected float BallGrowth { get; set; }
        protected static float BallGrowthSpeed => 0.3f;

        public static List<T> Balls = new List<T>();

        protected static Random Rnd = new Random();

        private static float RandomFloat(float min, float max) =>
            (float)(Rnd.NextDouble() * (max - min) + min);

        protected AbstractBall()
        {
            X = RandomFloat(Radius, Graphics.MAX_WIDTH - Radius);
            Y = RandomFloat(Radius, Graphics.MAX_HEIGHT - Radius);

            Radius = RandomFloat(RADIUS_MIN, RADIUS_MAX);

            Speed = RandomFloat(SPEED_MIN, SPEED_MAX);
        }

        public void Draw(System.Drawing.Graphics gfx)
        {
            if (BallGrowth > 0)
            {
                Radius += BallGrowthSpeed;
                BallGrowth -= BallGrowthSpeed;
            }

            gfx.FillEllipse(new SolidBrush(Color), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            gfx.DrawEllipse(new Pen(OutlineColor, OutlineWidth), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        public static void DrawBalls(System.Drawing.Graphics gfx)
        {
            foreach (var ball in Balls.Cast<IBall>())
                ball.Draw(gfx);
        }

        public virtual void OutOfBoundsFix()
        {
            if (X <= Radius)
            {
                X += Radius - X;
                DX = Graphics.MAX_WIDTH - DX;
            }

            else if (X >= Graphics.MAX_WIDTH - Radius)
            {
                DX = Graphics.MAX_WIDTH - DX;
                X -= X + Radius - Graphics.MAX_WIDTH;
            }

            if (Y <= Radius)
            {
                Y += Radius - Y;
                DY = Graphics.MAX_HEIGHT - DY;
            }

            else if (Y >= Graphics.MAX_HEIGHT - Radius)
            {
                DY = Graphics.MAX_HEIGHT - DY;
                Y -= Y + Radius - Graphics.MAX_HEIGHT;
            }
        }

        public virtual void Move()
        {
            if (X < DX - Speed)
                X += Speed;
            else if (X > DX + Speed)
                X -= Speed;

            if (Y < DY - Speed)
                Y += Speed;
            else if (Y > DY + Speed)
                Y -= Speed;
        }

        public static void MoveBalls()
        {
            foreach (var ball in Balls.Cast<IBall>())
                ball.Move();
        }

        public static void OutOfBoundsFixBalls()
        {
            foreach (var ball in Balls.Cast<IBall>())
                ball.OutOfBoundsFix();
        }

        public bool IntersectsWith(IBall ball) =>
            Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y))
            - Radius - ball.Radius
            < 0;

        public abstract void Eats(RegularBall ball);
        public abstract void Eats(MonsterBall ball);
        public abstract void Eats(RepellentBall ball);
    }
}