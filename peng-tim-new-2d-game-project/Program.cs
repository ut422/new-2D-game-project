using Raylib_cs;
using System.Numerics;
using Color = Raylib_cs.Color;

public class Program
{
    static string title = "Simple Collision Game";
    static int screenWidth = 800;
    static int screenHeight = 600;
    static int targetFps = 60;

    // player variables
    static Vector2 position;
    static Vector2 size = new Vector2(40, 40); // player size
    static Vector2 velocity;
    static Vector2 gravity = new Vector2(0, 100); // gravity vector

    static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, title);
        Raylib.SetTargetFPS(targetFps);
        Setup();

        while (!Raylib.WindowShouldClose())
        {           
            Draw();
        }

        Raylib.CloseWindow();
    }

    static void Setup()
    {
        // initialize player position at center
        position = new Vector2(screenWidth / 2, screenHeight / 2);
        velocity = Vector2.Zero;
    }


    static void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        // draw player
        Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.DarkGreen);

        Raylib.EndDrawing();
    }



    static void CheckScreenBoundaries()
    {
        // ensure player stays within screen boundaries
        if (position.X < 0)
            position.X = 0;
        else if (position.X > screenWidth - size.X)
            position.X = screenWidth - size.X;

        if (position.Y < 0)
            position.Y = 0;
        else if (position.Y > screenHeight - size.Y)
            position.Y = screenHeight - size.Y;
    }
}
