using System.Drawing;

namespace Big_Ball_Game
{
    interface IBall
    {
        float Radius { get; set; }
        float X { get; set; }
        float Y { get; set; }
        Color Color { get; set; }
        float DX { get; set; }
        float DY { get; set; }
        float Speed { get; set; }

        static int RADIUS_MIN { get; }
        static int RADIUS_MAX { get; }
        static int SPEED_MIN { get; }
        static int SPEED_MAX { get; }
        static int Count { get; }

        static void Initialize() { }
        static void Draw() { }
    }
}
