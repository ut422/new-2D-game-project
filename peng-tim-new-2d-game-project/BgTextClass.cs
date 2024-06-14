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
    private int scrollSpeed = 25; // adjustable scroll speed....
    private int fontSize = 20;   // now with adjustable font size! 😱😱😱😱😱😱😱😱😱😱😱😱😱😱

    public BgTextClass()
    {
        color = Color.DarkGray;
        position = new Vector2(10, 10);

        // big chunk o' text
        text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi 
        ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
        in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur 
        sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
        mollit anim id est laborum.";

        // makes sure the text starts up at the top (off screen as well)
        position.Y = -155;
    }

    public void Update()
    {
        // text scolling position update
        position.Y += scrollSpeed * Raylib.GetFrameTime();

        // resets text position when text goes offscreen
        if (position.Y > Raylib.GetScreenHeight())
        {
            position.Y = -155;
        }
    }

    public void Draw()
    {
        Raylib.DrawTextEx(font, text, position, fontSize, 0, color);
    }

    // adjust text size 101
    public void SetFontSize(int size)
    {
        fontSize = size;
    }
}
