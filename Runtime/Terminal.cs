using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

namespace UnityTerminal
{
    public abstract class Terminal
    {
        public int width;
        public int height;
        public Color backColor = Color.black;

        public virtual void Clear()
        {
            Fill(0, 0, width, height);
        }

        public virtual void Clear(int x, int y, int w, int h)
        {
            Fill(x, y, w, h);
        }

        public void Fill(int x, int y, int width, int height, Color? color = null)
        {
            color ??= backColor;

            for (var py = y; py < y + height; py++)
            {
                for (var px = x; px < x + width; px++)
                {
                    WriteAt(px, py, CharCode.space);
                }
            }
        }

        public bool CheckBounds(int x, int y, bool log = false)
        {
            if (x < 0 || x >= width ||
                y < 0 || y >= height)
            {
                if (log)
                    Debug.LogError($"[terminal]({x}, {y}) is out of terminal bounds.");
                return false;
            }
            return true;
        }

        public virtual void Tick(float dt) { }

        public virtual Terminal Rect(int x, int y, int w, int h)
        {
            return new PortTerminal(x, y, w, h, this);
        }

        // RetorTerminal
        public virtual void WriteAt(int x, int y, string text,
                                Color? fore = null, Color? back = null)
        { }
        public virtual void WriteAt(int x, int y, int charCode,
                                Color? fore = null, Color? back = null)
        { }
        public void WriteAt(int x, int y, Glyph glyph)
        {
            WriteAt(x, y, glyph.ch, glyph.fore, glyph.back);
        }
    }
}

