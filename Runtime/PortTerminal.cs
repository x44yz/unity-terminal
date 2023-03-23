using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    /// A terminal that draws to a window within another parent terminal.
    class PortTerminal : Terminal
    {
        // public override int width => size.x;
        // public override int height => size.y;
        // public override Vector2Int size => _size;

        public int _x;
        public int _y;
        public Terminal _root;

        public PortTerminal(int _x, int _y, int w, int h, Terminal _root)
        {
            this._x = _x;
            this._y = _y;
            this._root = _root;

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

            _root.WriteAt(_x + x, _y + y, charCode, fore, back);
        }

        public override Terminal Rect(int x, int y, int width, int height) 
        {
            // TODO: Bounds check.
            // Overridden so we can flatten out nested PortTerminals.
            return new PortTerminal(_x + x, _y + y, width, height, _root);
        }
    }
}