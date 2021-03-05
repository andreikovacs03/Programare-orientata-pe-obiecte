using System;
using System.Drawing;
using System.Collections.Generic;

namespace Big_Ball_Game
{
    abstract class AbstractBall<T>
    {
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public virtual float DX { get; set; }
        public virtual float DY { get; set; }

        protected float RADIUS_MIN { get => 2.5f; }
        protected float RADIUS_MAX { get => 4f; }
        protected float Speed { get; set; }

        protected static float SPEED_MIN { get => 1.5f; }
        protected static float SPEED_MAX { get => 5.5f; }

        public virtual Color Color { get; set; }
        protected static Color OutlineColor { get => Color.Black; }
        protected static float OutlineWidth { get => 1.5f; }

        protected static float BallGrowth { get; set; }
        protected static float BallGrowthSpeed { get => 1f; }

        public static List<T> Balls = new List<T>();

        protected static Random rnd = new Random();

        public static float RandomFloat(float min, float max)
        {
            return (float)(new Random().NextDouble() * (max - min) + min);
        }

        public AbstractBall()
        {
            Radius = RandomFloat(RADIUS_MIN, RADIUS_MAX);

            X = RandomFloat(Radius, Graphics.MAX_WIDTH - Radius);
            Y = RandomFloat(Radius, Graphics.MAX_HEIGHT - Radius);

            DX = new int[] { -1, Graphics.MAX_WIDTH + 1 }[rnd.Next(2)];
            DY = new int[] { -1, Graphics.MAX_HEIGHT + 1 }[rnd.Next(2)];

            Speed = RandomFloat(SPEED_MIN, SPEED_MAX);

            Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
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


        virtual public void OutOfBoundsFix()
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

        public bool IntersectsWith(RegularBall ball) =>
               Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y))
               - Radius - ball.Radius
               < 0;

        public bool IntersectsWith(MonsterBall ball) =>
               Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y))
               - Radius - ball.Radius
               < 0;

        public bool IntersectsWith(RepellentBall ball) =>
               Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y))
               - Radius - ball.Radius
               < 0;

        public abstract void Eats(RegularBall ball);
        public abstract void Eats(MonsterBall ball);
        public abstract void Eats(RepellentBall ball);

    }
}
