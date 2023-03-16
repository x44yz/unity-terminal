using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class TerminalCanvas : MonoBehaviour
    {
        public SpriteRenderer bg;
        public Transform glyphsRoot;
        public float pixelToUnits = 100; // default

        [Header("RUNTIME")]
        public Array2D<GlyphRender> glyphRenders;
        public Terminal terminal;
        
        public void Init(Terminal terminal)
        {
            glyphRenders = new Array2D<GlyphRender>(terminal.width, terminal.height, null);
            this.terminal = terminal;

            bg.transform.localScale = new Vector3(Screen.width / pixelToUnits, Screen.height / pixelToUnits, 1f);
        }

        public void Set(int x, int y, Sprite spr)
        {
            var rt = terminal as RetroTerminal;
            if (rt == null)
            {
                Debug.LogError("only support for RetroTerminal");
                return;
            }

            var gr = glyphRenders.Get(x, y);
            if (gr == null)
            {
                gr = GlyphRender.Create(glyphsRoot);
                glyphRenders.Set(x, y, gr);

                gr.transform.localPosition = new Vector3(
                    (x - terminal.width * 0.5f + 0.5f) * rt._charWidth * rt._scale / pixelToUnits, 
                    (rt.height * 0.5f - y - 0.5f) * rt._charHeight * rt._scale / pixelToUnits, 
                    0f);
                gr.transform.localScale = Vector3.one * rt._scale;
            }
            gr.SetSprite(spr);
        }
    }
}
