namespace Big_Ball_Game
{
    internal interface IBall
    {
        float X { get; }
        float Y { get; }
        float Radius { get; }
        void Draw(System.Drawing.Graphics gfx);
        void Move();
        void OutOfBoundsFix();
    }
}