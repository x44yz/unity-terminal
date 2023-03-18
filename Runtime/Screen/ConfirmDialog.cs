using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class ConfirmDialog : Screen
    {
        public string title;
        public string message;
        public Color boxColor = TerminalColor.green;
        public int sx = 2; // s - start
        public int sy = 1;
        public int titlePaddingX = 0;
        public int titlePaddingY = 0;
        public int msgPaddingX = 0;
        public int msgPaddingY = 1;

        public static ConfirmDialog Create(string title,
            string msg)
        {
            var dialog = new ConfirmDialog();
            dialog.title = title;
            dialog.message = msg;
            dialog.isTransparent = true;
            return dialog;
        }

        public override void Render(Terminal terminal)
        {
            TerminalUtils.DrawBox(terminal, sx, sy, boxColor);

            int tx = sx + titlePaddingX + 1;
            int ty = sy + titlePaddingY + 1;
            terminal.WriteAt(tx, ty, title);

            int mx = sx + msgPaddingX + 1;
            int my = sy + msgPaddingY + 1;
            terminal.WriteAt(mx, my, message);

            return;
        }
    }
}

