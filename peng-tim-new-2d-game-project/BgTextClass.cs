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
    private int scrollSpeed = 25; // adjustable scroll speed

    public BgTextClass()
    {
        font = Raylib.LoadFont("arial.ttf");
        color = Color.DarkGray;
        position = new Vector2(10, 10);

        // wall of text
        text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi 
        ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
        in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur 
        sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
        mollit anim id est laborum.";

        // makes the text start up at the top (off screen)
        position.Y = -155;
    }

    public void Update()
    {
        // scroll text position update
        position.Y += scrollSpeed * Raylib.GetFrameTime();

        // once the text goes offscreen, it resets
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
