using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Dialog : Screen
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

        public override bool isTransparent => true;

        public static Dialog Create(string title,
            string msg)
        {
            var dialog = new Dialog();
            dialog.title = title;
            dialog.message = msg;
            return dialog;
        }

        public override bool KeyDown(KeyCode keyCode, bool shift, bool alt)
        {
            // base.HandleInput();

            if (keyCode == KeyCode.Space)
                terminal.Pop(this);

            return false;
        }

        public override void Render()
        {
            base.Render();

            terminal.Fill(sx, sy, terminal.width - sx * 2, terminal.height - sy * 2);
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

