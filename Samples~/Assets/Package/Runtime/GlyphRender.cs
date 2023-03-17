using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class GlyphRender : MonoBehaviour
    {
        [Header("RUNTIME")]
        public SpriteRenderer spr;

        public static GlyphRender Create(Transform parent)
        {
            var obj = new GameObject(/*$"spr{x}x{y}"*/);
            obj.transform.SetParent(parent);
            var glyphRender = obj.AddComponent<GlyphRender>();
            glyphRender.spr = obj.AddComponent<SpriteRenderer>();
            return glyphRender;
        }

        public void SetSprite(Sprite s)
        {
            spr.sprite = s;
        }

        public void SetColor(Color color)
        {
            spr.color = color;
        }
    }
}

