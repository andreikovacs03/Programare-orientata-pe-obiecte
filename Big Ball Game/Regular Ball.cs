using System;
using System.Drawing;
using System.Collections.Generic;

namespace Big_Ball_Game
{
    class RegularBall : IBall
    {
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public float DX { get; set; }
        public float DY { get; set; }

        static float RADIUS_MIN { get => 2.5f; }
        static float RADIUS_MAX { get => 4f; }

        public float Speed { get; set; }
        static float SPEED_MIN { get => 1.5f; }
        static float SPEED_MAX { get => 5.5f; }

        public Color Color { get; set; }
        static float OutlineWidth { get => 1.5f; }

        public static List<RegularBall> Balls = new List<RegularBall>();
        public static int Count { get => 100; }

        static Random rnd = new Random();

        static float RandomFloat(float min, float max)
        {
            return (float)(new Random().NextDouble() * (max - min) + min);
        }

        public RegularBall()
        {
            Radius = RandomFloat(RADIUS_MIN, RADIUS_MAX);

            X = RandomFloat(Radius, Graphics.MAX_WIDTH - Radius);
            Y = RandomFloat(Radius, Graphics.MAX_HEIGHT - Radius);

            DX = new int[] { 0, Graphics.MAX_WIDTH }[rnd.Next(2)];
            DY = new int[] { 0, Graphics.MAX_HEIGHT }[rnd.Next(2)];

            Speed = RandomFloat(SPEED_MIN, SPEED_MAX);

            Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public void Draw(System.Drawing.Graphics gfx)
        {
            gfx.FillEllipse(new SolidBrush(Color), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            gfx.DrawEllipse(new Pen(Color.Black, OutlineWidth), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        public void Move()
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

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new RegularBall());
        }

        public void OutOfBoundsFix()
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

        public bool IntersectsWith(RegularBall ball) =>
            Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y))
            - Radius - ball.Radius
            < 0;

        public void Eats(RegularBall ball)
        {
            Radius += ball.Radius;
            OutOfBoundsFix();
            Balls.Remove(ball);
        }
    }
}