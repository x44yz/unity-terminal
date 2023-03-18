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
        public Vector2Int _size;
        public Terminal _root;

        public PortTerminal(int _x, int _y, Vector2Int size, Terminal _root)
        {
            this._x = _x;
            this._y = _y;
            this._size = size;
            this._root = _root;

            width = size.x;
            height = size.y;
        }

        public override void Tick(float dt)
        {
            // nothing
        }
    }
}