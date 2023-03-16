using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public abstract class RenderTerminal : Terminal
    {
        public abstract void render();

        /// Given a point in pixel coordinates, returns the coordinates of the
        /// character that contains that pixel.
        // public abstract Vector2Int pixelToChar(Vector2Int pixel);
    }
}
