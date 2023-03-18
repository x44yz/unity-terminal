using System;
using System.Collections.Generic;
using UnityEngine;

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

        void Fill(int x, int y, int width, int height, Color? color = null)
        {
            color ??= backColor;

            for (var py = y; py < y + height; py++) {
              for (var px = x; px < x + width; px++) {
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
                    Debug.LogError($"{{{x}, {y}}} is out of terminal bounds.");
                return false;
            }
            return true;
        }

        public abstract void Tick(float dt);

        // RetorTerminal
        public virtual void WriteAt(int x, int y, string text, Color? fore = null) {}
        public virtual void WriteAt(int x, int y, int charCode, Color? fore = null) {}
    }
}

