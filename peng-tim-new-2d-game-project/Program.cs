using Raylib_cs;
using System;
using System.Numerics;
using Color = Raylib_cs.Color;

public class Program
{
    static string title = "New 2D Game";
    static int screenWidth = 800;
    static int screenHeight = 600;
    static int targetFps = 60;

    // Player variables
    static Vector2 playerPosition;
    static Vector2 playerSize = new Vector2(40, 40); // player size
    static Vector2 playerVelocity;
    static Vector2 gravity = new Vector2(0, 300); // gravity vector
    static float jumpVelocity = -300; // velocity applied when jumping
    static bool isJumping = false; // flag to track if the player is jumping

    // Enemy instance
    static EnemyClass enemy;

    // Background text instance
    static BgTextClass bgText;

    static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, title);
        Raylib.SetTargetFPS(targetFps);
        Setup();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Raylib.CloseWindow();
    }

    static void Setup()
    {
        // initialize player position at center bottom
        playerPosition = new Vector2(screenWidth / 22 - playerSize.X / 2, screenHeight - playerSize.Y - 20);
        playerVelocity = Vector2.Zero;

        // initialize enemy
        enemy = new EnemyClass(screenWidth / 1, screenHeight - 20, 20, 200, 1, 799);

        // initialize background text
        bgText = new BgTextClass();
    }

    static void Update()
    {
        // input handling for player movement and jumping
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            playerPosition.X += 5;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            playerPosition.X -= 5;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Space) && !isJumping)
        {
            // only allow jumping if not already jumping
            playerVelocity.Y = jumpVelocity;
            isJumping = true;
        }

        // simulate gravity for player
        SimulateGravity();

        // update enemy position
        enemy.Update();

        // update background text
        bgText.Update();

        // check for collision between player and enemy
        if (CheckCollisionPlayerEnemy())
        {
            Raylib.CloseWindow(); // close the game window on collision
        }

        // check screen boundaries for player
        CheckPlayerScreenBoundaries();
    }

    static void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        // draw player
        Raylib.DrawRectangle((int)playerPosition.X, (int)playerPosition.Y, (int)playerSize.X, (int)playerSize.Y, Color.DarkGreen);

        // draw enemy
        enemy.Draw();

        // draw background text
        bgText.Draw();

        Raylib.EndDrawing();
    }

    static void SimulateGravity()
    {
        float deltaTime = Raylib.GetFrameTime(); // get the time elapsed since last frame
        Vector2 gravityForce = deltaTime * gravity; // calculate gravity force for this frame
        playerVelocity += gravityForce; // apply gravitational force to velocity
        playerPosition += playerVelocity * deltaTime; // update position based on velocity

        // check if player is on the ground (y velocity is non-positive)
        if (playerPosition.Y >= screenHeight - playerSize.Y - 20)
        {
            playerPosition.Y = screenHeight - playerSize.Y - 20; // snap to ground
            playerVelocity.Y = 0; // stop vertical velocity
            isJumping = false; // allow jumping again
        }
    }

    static bool CheckCollisionPlayerEnemy()
    {
        // check for bounding box collision
        float playerRight = playerPosition.X + playerSize.X;
        float playerBottom = playerPosition.Y + playerSize.Y;
        float enemyLeft = enemy.Position.X - enemy.Radius;
        float enemyRight = enemy.Position.X + enemy.Radius;
        float enemyTop = enemy.Position.Y - enemy.Radius;
        float enemyBottom = enemy.Position.Y + enemy.Radius;

        bool collisionX = playerPosition.X < enemyRight && playerRight > enemyLeft;
        bool collisionY = playerPosition.Y < enemyBottom && playerBottom > enemyTop;

        return collisionX && collisionY;
    }

    static void CheckPlayerScreenBoundaries()
    {
        // ensure player stays within screen boundaries
        if (playerPosition.X < 0)
            playerPosition.X = 0;
        else if (playerPosition.X > screenWidth - playerSize.X)
            playerPosition.X = screenWidth - playerSize.X;
    }
}
