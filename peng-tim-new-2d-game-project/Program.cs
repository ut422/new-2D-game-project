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

    // player variables
    static Vector2 playerPosition;
    static Vector2 playerSize = new Vector2(40, 40); // player size
    static Vector2 playerVelocity;
    static Vector2 gravity = new Vector2(0, 300); // gravity vector
    static float jumpVelocity = -300; // velocity applied when jumping
    static bool isJumping = false; // flag to track if the player is jumping

    // enemy instance
    static EnemyClass enemy;


    static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, title);
        Raylib.SetTargetFPS(targetFps);
        Setup();

        // Modify enemy speed and radius
        enemy.Speed = 150; // adjustable speed
        enemy.Radius = 30; // adjustable radius

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

        // gravity stuff
        SimulateGravity();

        // enemy pos
        enemy.Update();



        // checks for collision between player and enemy
        if (CheckCollisionPlayerEnemy())
        {
            Raylib.CloseWindow(); // closes the game window on collision
        }

        // check screen boundaries for player
        CheckPlayerScreenBoundaries();
    }

    static void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        // draws the player
        Raylib.DrawRectangle((int)playerPosition.X, (int)playerPosition.Y, (int)playerSize.X, (int)playerSize.Y, Color.DarkGreen);

        // draws the enemy
        enemy.Draw();



        Raylib.EndDrawing();
    }

    static void SimulateGravity()
    {
        float deltaTime = Raylib.GetFrameTime(); // gets the time elapsed since last frame
        Vector2 gravityForce = deltaTime * gravity; // calculate gravity force for this frame
        playerVelocity += gravityForce; // apply gravitational force to velocity
        playerPosition += playerVelocity * deltaTime; // update position based on velocity

        // check if player is on the ground (y velocity isn't positive)
        if (playerPosition.Y >= screenHeight - playerSize.Y - 20)
        {
            playerPosition.Y = screenHeight - playerSize.Y - 20; // snaps to ground
            playerVelocity.Y = 0; // stops vertical velocity
            isJumping = false; // jumping allowed again
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
        // MAKES SURE the player stays within screen boundaries
        if (playerPosition.X < 0)
            playerPosition.X = 0;
        else if (playerPosition.X > screenWidth - playerSize.X)
            playerPosition.X = screenWidth - playerSize.X;
    }
}
