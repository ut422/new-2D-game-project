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
    private int fontSize = 30;   // now with adjustable font size! 😱😱😱😱😱😱😱😱😱😱😱😱😱😱
    private int spacing = 5; //and with adjustable... sSPACING?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!??!?!?!?!?
    public BgTextClass()
    {
        color = Color.DarkGray;
        position = new Vector2(10, 10);

        // big chunk o' text
        text = @"pee pee poopoo";

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
        Raylib.DrawTextEx(font, text, position, fontSize, spacing, color);
    }

    // adjust text size 101
    public void SetFontSize(int size)
    {
        fontSize = size;
    }
    // adjust spacing 102
    public void SetSpacing(int space)
    {
        spacing = space;
    }
}
