using Raylib_cs;
using System.Numerics;
using Color = Raylib_cs.Color;

public class EnemyClass
{
    public Vector2 Position { get; private set; }
    public float Radius { get; private set; }
    public float Speed { get; private set; }
    public int LeftBoundary { get; private set; }
    public int RightBoundary { get; private set; }
    public bool MovingRight { get; private set; }

    public EnemyClass(float startX, float startY, float radius, float speed, int leftBoundary, int rightBoundary)
    {
        Position = new Vector2(startX, startY);
        Radius = radius;
        Speed = speed;
        LeftBoundary = leftBoundary;
        RightBoundary = rightBoundary;
        MovingRight = true;
    }

    public Vector2 GetPosition()
    {
        return Position;
    }

    public void Update(Vector2 position)
    {
        // Move enemy horizontally
        if (MovingRight)
        {
            position.X += Speed * Raylib.GetFrameTime();
            if (Position.X >= RightBoundary)
            {
                MovingRight = false;
            }
        }
        else
        {
            position.X -= Speed * Raylib.GetFrameTime();
            if (Position.X <= LeftBoundary)
            {
                MovingRight = true;
            }
        }
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color.Red);
    }
}
