using System.Collections;
using System.Collections.Generic;

namespace UnityTerminal
{
    // public static class TerminalColor
    // {
    //     public static Color Rgba255(byte r, byte g, byte b, byte a = 255)
    //     {
    //         // return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    //         return new Color(r, g, b, a);
    //     }

    //     public static Color black = Rgba255(0, 0, 0);
    //     public static Color white = Rgba255(255, 255, 255);

    //     public static Color lightGray = Rgba255(192, 192, 192);
    //     public static Color gray = Rgba255(128, 128, 128);
    //     public static Color darkGray = Rgba255(64, 64, 64);

    //     public static Color lightRed = Rgba255(255, 160, 160);
    //     public static Color red = Rgba255(220, 0, 0);
    //     public static Color darkRed = Rgba255(100, 0, 0);

    //     public static Color lightOrange = Rgba255(255, 200, 170);
    //     public static Color orange = Rgba255(255, 128, 0);
    //     public static Color darkOrange = Rgba255(128, 64, 0);

    //     public static Color lightGold = Rgba255(255, 230, 150);
    //     public static Color gold = Rgba255(255, 192, 0);
    //     public static Color darkGold = Rgba255(128, 96, 0);

    //     public static Color lightYellow = Rgba255(255, 255, 150);
    //     public static Color yellow = Rgba255(255, 255, 0);
    //     public static Color darkYellow = Rgba255(128, 128, 0);

    //     public static Color lightGreen = Rgba255(130, 255, 90);
    //     public static Color green = Rgba255(0, 128, 0);
    //     public static Color darkGreen = Rgba255(0, 64, 0);

    //     public static Color lightAqua = Rgba255(128, 255, 255);
    //     public static Color aqua = Rgba255(0, 255, 255);
    //     public static Color darkAqua = Rgba255(0, 128, 128);

    //     public static Color lightBlue = Rgba255(128, 160, 255);
    //     public static Color blue = Rgba255(0, 64, 255);
    //     public static Color darkBlue = Rgba255(0, 37, 168);

    //     public static Color lightPurple = Rgba255(200, 140, 255);
    //     public static Color purple = Rgba255(128, 0, 255);
    //     public static Color darkPurple = Rgba255(64, 0, 128);

    //     public static Color lightBrown = Rgba255(190, 150, 100);
    //     public static Color brown = Rgba255(160, 110, 60);
    //     public static Color darkBrown = Rgba255(100, 64, 32);
    
    //     public static Color darkCoolGray = Rgba255(0x26, 0x2a, 0x42);

    //     public static Color lightWarmGray = Rgba255(0x84, 0x7e, 0x87);
    //     public static Color ash = Rgba255(0xe2, 0xdf, 0xf0);
    // }

    public static class TerminalUtils
    {
        public static void DrawBox(Terminal terminal, int x, int y, Color? color = null)
        {
            DrawBox(terminal, x, y, terminal.width - x * 2, terminal.height - y * 2, color);
        }

        public static void DrawBox(Terminal terminal, int x, int y, 
            int width, int height, Color? color = null)
        {
            DrawBox(terminal, x, y, width, height, color, 
                "┌", "─", "┐", "│", "└", "─", "┘");
        }

        // public static void DrawBox(Terminal terminal, Panel p, int x, int y, Color? color = null)
        // {
        //     DrawBox(terminal, p, x, y, p.w - x * 2, p.h - y * 2, color);
        // }

        // public static void DrawBox(Terminal terminal, Panel p, int x, int y, 
        //     int width, int height, Color? color = null)
        // {
        //     DrawBox(terminal, p.x + x, p.y + y, width, height, color);
        // }

        public static void DrawFrame(Terminal terminal, int x, int y, 
            Color? color = null)
        {
            DrawFrame(terminal, x, y, terminal.width - x * 2, 
                    terminal.height - y * 2, color);
        }

        public static void DrawFrame(Terminal terminal, int x, int y, 
            int width, int height, Color? color = null)
        {
            DrawBox(terminal, x, y, width, height, color, 
                "╒", "═", "╕", "│", "└", "─", "┘");
        }

        // public static void DrawFrame(Terminal terminal, Panel p, int x, 
        //     int y, Color? color = null)
        // {
        //     DrawFrame(terminal, p, x, y, p.w - x * 2, 
        //         p.h - y * 2, color);
        // }

        // public static void DrawFrame(Terminal terminal, Panel p, int x, 
        //     int y, int width, int height, Color? color = null)
        // {
        //     DrawBox(terminal, p.x + x, p.y + y, width, height, color, 
        //         "╒", "═", "╕", "│", "└", "─", "┘");
        // }

        public static void DrawBox(Terminal terminal, int x, int y,
            int width, int height, Color? color,
            string topLeft,
            string top,
            string topRight,
            string vertical,
            string bottomLeft,
            string bottom,
            string bottomRight)
        {
            color ??= Color.darkCoolGray;

            // left/right bar
            for (int i = 1; i < height - 1; ++i)
            {
                terminal.WriteAt(x, y + i, vertical, color);
                terminal.WriteAt(x + width - 1, y + i, vertical, color);
            }

            // top/bottom row
            for (int i = 0; i < width; ++i)
            {
                if (i == 0)
                {
                    terminal.WriteAt(x + i, y, topLeft, color);
                    terminal.WriteAt(x + i, y + height - 1, bottomLeft, color);
                }
                else if (i == width - 1)
                {
                    terminal.WriteAt(x + i, y, topRight, color);
                    terminal.WriteAt(x + i, y + height - 1, bottomRight, color);
                }
                else
                {
                    terminal.WriteAt(x + i, y, top, color);
                    terminal.WriteAt(x + i, y + height - 1, bottom, color);
                }
            }
        }

        public static void DrawHelpKeys(Terminal terminal, 
                Dictionary<string, string> helpKeys,
                string query = null, Color? queryBoxColor = null,
                Color? queryTextColor = null, Color? keyColor = null,
                Color? textColor = null, Color? symbolColor = null)
        {
            queryBoxColor ??= Color.lightWarmGray;
            queryTextColor ??= Color.ash;
            keyColor ??= Color.gold;
            textColor ??= Color.lightWarmGray;
            symbolColor ??= Color.darkCoolGray;

            // Draw the help.
            var helpTextLength = 0;
            foreach (var kv in helpKeys) {
                var key = kv.Key;
                var text = kv.Value;
                if (helpTextLength > 0)
                    helpTextLength += 2;
                helpTextLength += key.Length + text.Length + 3;
            }

            var x = (terminal.width - helpTextLength) / 2;

            // Show the query string, if there is one.
            if (query != null) {
                DrawBox(terminal, x - 2, terminal.height - 4, helpTextLength + 4, 5,
                    queryBoxColor);
                terminal.WriteAt((terminal.width - query.Length) / 2,
                    terminal.height - 3, query, queryTextColor);
                } else {
                DrawBox(terminal, x - 2, terminal.height - 2, helpTextLength + 4, 3,
                    queryBoxColor);
            }

            var first = true;
            foreach (var kv in helpKeys) {
                var key = kv.Key;
                var text = kv.Value;

                if (!first) {
                    terminal.WriteAt(x, terminal.height - 1, ", ", symbolColor);
                    x += 2;
                }

                terminal.WriteAt(x, terminal.height - 1, "[", symbolColor);
                x++;
                terminal.WriteAt(x, terminal.height - 1, key, keyColor);
                x += key.Length;
                terminal.WriteAt(x, terminal.height - 1, "] ", symbolColor);
                x += 2;

                terminal.WriteAt(x, terminal.height - 1, text, textColor);
                x += text.Length;

                first = false;
            }
        }
    }
}
