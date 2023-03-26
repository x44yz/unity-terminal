using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class RetroCanvas : TerminalCanvas
    {
        public static Dictionary<string, Sprite[]> spritesMap = new Dictionary<string, Sprite[]>();

        public SpriteRenderer bg;
        public Transform glyphsRoot;
        public float pixelToUnits = 100; // default
        public Sprite glyphBackSpr;
        public bool showGlyphGrid;
        public UnityEngine.Color glyphGridColor = UnityEngine.Color.red;
        public bool logKeyEvent;

        [Header("RUNTIME")]
        public RetroTerminal terminal;
        public Array2D<GlyphRender> glyphRenders;
        public Sprite[] sprites = null;
        public Dictionary<int, int> char2SpriteIndexs;

        public void Init(RetroTerminal terminal, string resName, Dictionary<int, int> char2SpriteIndexs)
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

        public override void Render()
        {
           if (terminal == null)
                return;

            for (var x = 0; x < terminal.width; x++) {
                for (var y = 0; y < terminal.height; y++) {
                    var glyph = terminal.glyphs.Get(x, y);
                
                    if (glyph == null /*|| glyph.ch == CharCode.space*/)
                    {
                        this.Set(x, y, null, Color.white, null);
                    }
                    else
                    {
                        // Debug.Log($"xx-- render > {x}, {y}, {glyph.ch}");
                        var foreSpr = GetSprite(glyph.ch);
    
                        // _display.setGlyph(x, y, glyph);
                        this.Set(x, y, foreSpr, glyph.fore, glyph.back);
                    }
                }
            }
        }

        private Sprite GetSprite(int ch)
        {
            int sprIdx = ch;
            if (char2SpriteIndexs.ContainsKey(ch))
            {
                sprIdx = char2SpriteIndexs[ch];
            }

            if (sprIdx < 0 || sprIdx >= sprites.Length)
            {
                Debug.LogError("not support glyph > " + ch);
                return null;
            }
            return sprites[sprIdx];
        }

        public void Set(int x, int y, Sprite foreSpr, Color? foreColor, Color? backColor)
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
                gr.name = $"SPR_{x}_{y}";
                glyphRenders.Set(x, y, gr);

                gr.transform.localPosition = new Vector3(
                    (x - terminal.width * 0.5f + 0.5f) * rt.charWidth * rt.scale / pixelToUnits, 
                    (rt.height * 0.5f - y - 0.5f) * rt.charHeight * rt.scale / pixelToUnits, 
                    0f);
                gr.transform.localScale = Vector3.one * rt.scale;
            }
            gr.SetForeSprite(foreSpr, foreColor);
            gr.SetBackSprite(glyphBackSpr, backColor);
        }

        private void OnGUI() 
        {
            if (terminal == null)
                return;

            if (Event.current.type == EventType.KeyDown)
            {
                if (Input.GetKeyDown(Event.current.keyCode))
                {
                    terminal.KeyDown(Event.current.keyCode);
                    if (logKeyEvent)
                        Debug.Log($"[input]key down > {Event.current.keyCode}");
                }
            }
            else if (Event.current.type == EventType.KeyUp)
            {
                if (Input.GetKeyUp(Event.current.keyCode))
                {
                    terminal.KeyUp(Event.current.keyCode);
                    if (logKeyEvent)
                        Debug.Log($"[input]key up > {Event.current.keyCode}");
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!showGlyphGrid)
                return;

            if (terminal == null)
                return;

            float charWidth = terminal.charWidth * terminal.scale;
            float charHeight = terminal.charHeight * terminal.scale;

            var fx =  -terminal.width * charWidth * 0.5f;
            var fy = terminal.height * charHeight * 0.5f;
            var off = new Vector3(fx / pixelToUnits, fy / pixelToUnits, 0f);

            Gizmos.color = glyphGridColor;
            for (int i = 0; i <= terminal.width; ++i)
            {
                Vector3 bpos = glyphsRoot.position + off + new Vector3(i * charWidth/pixelToUnits, 0 * charHeight/pixelToUnits, -1);
                Vector3 epos = glyphsRoot.position + off + new Vector3(i * charWidth/pixelToUnits, -terminal.height * charHeight/pixelToUnits, -1);
                Gizmos.DrawLine(bpos, epos);
            }

            for (int j = 0; j <= terminal.height; ++j)
            {
                Vector3 bpos = glyphsRoot.position + off + new Vector3(0 * charWidth/pixelToUnits, -j * charHeight/pixelToUnits, -1);
                Vector3 epos = glyphsRoot.position + off + new Vector3(terminal.width * charWidth/pixelToUnits, -j * charHeight/pixelToUnits, -1);
                Gizmos.DrawLine(bpos, epos);
            }
        }
#endif
    }
}

