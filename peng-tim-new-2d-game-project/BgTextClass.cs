using Raylib_cs;
using System;
using System.Numerics;
using Color = Raylib_cs.Color;

public class BgTextClass
{
    private string text;
    private Font font;
    private Vector2 position;
    private Color color;
    private int scrollSpeed = 25; // Adjust scroll speed as needed

    public BgTextClass()
    {
        font = Raylib.LoadFont("arial.ttf");
        color = Color.DarkGray;
        position = new Vector2(10, 10);

        // Example of a long text to scroll
        text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi 
        ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
        in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur 
        sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
        mollit anim id est laborum.";

        // Make text start off-screen at the top
        position.Y = -155;
    }

    public void Update()
    {
        // Update the position to scroll the text
        position.Y += scrollSpeed * Raylib.GetFrameTime();

        // Reset position when text has scrolled off-screen
        if (position.Y > Raylib.GetScreenHeight())
        {
            position.Y = -155;
        }
    }

    public void Draw()
    {
        Raylib.DrawTextEx(font, text, position, 9, 0, color);
    }
}
