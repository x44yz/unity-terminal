using System;
using System.Collections.Generic;

namespace UnityTerminal
{
    /// A terminal that draws to a window within another parent terminal.
    class PortTerminal : Terminal
    {
        public int x;
        public int y;
        public Terminal parent;

        public PortTerminal(int x, int y, int w, int h, Terminal parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;

            width = w;
            height = h;
        }

        public override void WriteAt(int x, int y, string text,
                                Color? fore = null, Color? back = null)
        {
            for (var i = 0; i < text.Length; i++)
            {
                if (x + i >= width) break;
                WriteAt(x + i, y, text[i], fore, back);
            }
        }

        public override void WriteAt(int x, int y, int charCode,
                                Color? fore = null, Color? back = null)
        {
            if (x < 0) return;
            if (x >= width) return;
            if (y < 0) return;
            if (y >= height) return;

            parent.WriteAt(this.x + x, this.y + y, charCode, fore, back);
        }

        public override Terminal Rect(int x, int y, int width, int height)
        {
            // Overridden so we can flatten out nested PortTerminals.
            return new PortTerminal(this.x + x, this.y + y, width, height, parent);
        }
    }
}