using Raylib_cs;
using System.Numerics;

public class BigCircleClass
{
    public Vector2 Position;
    public float Radius;
    public Vector2 Velocity;
    public float Gravity;

    public BigCircleClass(Vector2 position, float radius, float gravity)
    {
        Position = position;
        Radius = radius;
        Velocity = Vector2.Zero;
        Gravity = gravity;
    }

    public void Update()
    {
        Position.Y += Velocity.Y;
        Velocity.Y += Gravity;
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color.Red);
    }

    public bool CheckCollisionWithPlayer(Vector2 playerPosition, Vector2 playerSize)
    {
        Rectangle playerRect = new Rectangle(playerPosition.X, playerPosition.Y, playerSize.X, playerSize.Y);
        return Raylib.CheckCollisionCircleRec(Position, Radius, playerRect);
    }
}
