using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class TerminalCanvas : MonoBehaviour
    {
        public static Dictionary<string, Sprite[]> spritesMap = new Dictionary<string, Sprite[]>();

        public SpriteRenderer bg;
        public Transform glyphsRoot;
        public float pixelToUnits = 100; // default

        [Header("RUNTIME")]
        public Array2D<GlyphRender> glyphRenders;
        public Terminal terminal;
        public Sprite[] sprites = null;
        public Dictionary<int, int> char2SpriteIndexs;
        
        public void Init(Terminal terminal, string resName, Dictionary<int, int> char2SpriteIndexs)
        {
            if (spritesMap.ContainsKey(resName) == false)
            {
                var sprs = Resources.LoadAll<Sprite>(resName);
                spritesMap[resName] = sprs;
            }
            sprites = spritesMap[resName];

            glyphRenders = new Array2D<GlyphRender>(terminal.width, terminal.height, null);
            this.terminal = terminal;
            this.char2SpriteIndexs = char2SpriteIndexs;

            bg.transform.localScale = new Vector3(UnityEngine.Screen.width / pixelToUnits, UnityEngine.Screen.height / pixelToUnits, 1f);
        }

        private void Update() 
        {
 
        }

        public void Render()
        {
           if (terminal == null)
                return;

            (terminal as RetroTerminal).render((x, y, glyph) => {
                Debug.Log($"xx-- render > {x}, {y}, {glyph._char}");

                int sprIdx = glyph._char;
                if (char2SpriteIndexs.ContainsKey(glyph._char))
                {
                    sprIdx = char2SpriteIndexs[glyph._char];
                }

                if (sprIdx < 0 || sprIdx >= sprites.Length)
                {
                    Debug.LogError("not support glyph > " + glyph._char);
                    return;
                }

                // _display.setGlyph(x, y, glyph);
                this.Set(x, y, sprites[sprIdx], glyph.fore);
            });
        }

        public void Set(int x, int y, Sprite spr, Color foreColor)
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
            gr.SetColor(foreColor);
        }
    }
}
