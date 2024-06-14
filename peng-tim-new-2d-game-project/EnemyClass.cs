using Raylib_cs;
using System.Numerics;
using Color = Raylib_cs.Color;

public class EnemyClass
{
    public Vector2 Position;
    public float Radius;
    public float Speed;
    public int LeftBoundary;
    public int RightBoundary;
    public bool MovingRight;

    public EnemyClass(float startX, float startY, float radius, float speed, int leftBoundary, int rightBoundary)
    {
        Position = new Vector2(startX, startY);
        Radius = radius;
        Speed = speed;
        LeftBoundary = leftBoundary;
        RightBoundary = rightBoundary;
        MovingRight = true;
    }

    public void Update()
    {
        // move enemy horizontally
        if (MovingRight)
        {
            Position.X += Speed * Raylib.GetFrameTime();
            if (Position.X >= RightBoundary)
            {
                MovingRight = false;
            }
        }
        else
        {
            Position.X -= Speed * Raylib.GetFrameTime();
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
