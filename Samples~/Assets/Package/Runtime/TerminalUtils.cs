using System.Collections;
using System.Collections.Generic;

namespace UnityTerminal
{
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
            foreach (var kv in helpKeys)
            {
                var key = kv.Key;
                var text = kv.Value;
                if (helpTextLength > 0)
                    helpTextLength += 2;
                helpTextLength += key.Length + text.Length + 3;
            }

            var x = (terminal.width - helpTextLength) / 2;

            // Show the query string, if there is one.
            if (query != null)
            {
                DrawBox(terminal, x - 2, terminal.height - 4, helpTextLength + 4, 5,
                    queryBoxColor);
                terminal.WriteAt((terminal.width - query.Length) / 2,
                    terminal.height - 3, query, queryTextColor);
            }
            else
            {
                DrawBox(terminal, x - 2, terminal.height - 2, helpTextLength + 4, 3,
                    queryBoxColor);
            }

            var first = true;
            foreach (var kv in helpKeys)
            {
                var key = kv.Key;
                var text = kv.Value;

                if (!first)
                {
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
