using System;
using System.Drawing;

namespace Big_Ball_Game
{
    class RegularBall : IBall
    {
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public float DX { get; set; }
        public float DY { get; set; }
        public float Speed { get; set; }

        static int RADIUS_MIN { get => 10; }
        static int RADIUS_MAX { get => 100; }
        static int SPEED_MIN { get => 3; }
        static int SPEED_MAX { get => 10; }
        public static int Count { get => 50; }

        Random rnd = new Random();

        public RegularBall()
        {
            Radius = rnd.Next(RADIUS_MIN, RADIUS_MAX);
            X = rnd.Next((int)Radius + 1, Graphics.MAX_WIDTH - ((int)Radius + 1) + 1);
            Y = rnd.Next((int)Radius + 1, Graphics.MAX_HEIGHT - ((int)Radius + 1) + 1);
            Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            DX = rnd.Next((int)Radius + 1, Graphics.MAX_WIDTH - ((int)Radius + 1) + 1);
            DY = rnd.Next((int)Radius + 1, Graphics.MAX_HEIGHT - ((int)Radius + 1) + 1);
            Speed = rnd.Next(SPEED_MIN, SPEED_MAX + 1);
        }

        public void Draw(System.Drawing.Graphics gfx) => gfx.FillEllipse(new SolidBrush(Color), X - Radius, Y - Radius, Radius, Radius);

        public void Movement()
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

        public void FixBounds()
        {
            if (X < (int)Radius + 1 || X > Graphics.MAX_WIDTH - ((int)Radius + 1) + 1)
                DX *= -1;
            if (Y < (int)Radius + 1 || Y > Graphics.MAX_HEIGHT - ((int)Radius + 1) + 1)
                DY *= -1;
        }

        public bool IntersectsWith(RegularBall ball) =>
                (X + Radius > ball.X - ball.Radius || X - Radius < ball.X - ball.Radius) &&
                (Y + Radius > ball.Y - ball.Radius || Y - Radius < ball.Y - ball.Radius);
    }
}