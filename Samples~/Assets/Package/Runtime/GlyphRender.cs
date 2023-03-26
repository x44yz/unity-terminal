using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class GlyphRender : MonoBehaviour
    {
        [Header("RUNTIME")]
        public SpriteRenderer backSpr;
        public SpriteRenderer foreSpr;

        public static GlyphRender Create(Transform parent)
        {
            var obj = new GameObject();
            obj.transform.SetParent(parent);
            var glyphRender = obj.AddComponent<GlyphRender>();
            glyphRender.foreSpr = obj.AddComponent<SpriteRenderer>();
            return glyphRender;
        }

        public void SetForeSprite(Sprite s, Color? color)
        {
            SetSprite(foreSpr, s);
            SetColor(foreSpr, color);
        }

        public void SetBackSprite(Sprite s, Color? color)
        {
            if (backSpr == null)
            {
                var obj = new GameObject("bg");
                obj.transform.SetParent(transform);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localScale = Vector3.one;
                backSpr = obj.AddComponent<SpriteRenderer>();
                backSpr.sortingOrder = -1;
                backSpr.sprite = s;
            }
            if (color == null || color == Color.black)
            {
                backSpr.enabled = false;
                return;
            }
            backSpr.enabled = true;
            SetColor(backSpr, color);
        }

        public void SetSprite(SpriteRenderer spr, Sprite s)
        {
            if (spr == null)
                return;

            if (s == null)
            {
                spr.enabled = false;
                return;
            }

            if (spr.enabled == false)
                spr.enabled = true;
            spr.sprite = s;
        }

        public void SetColor(SpriteRenderer spr, Color? color)
        {
            if (spr == null)
                return;

            if (color == null)
                spr.color = Color.white.ToUnityColor();
            else
                spr.color = color.ToUnityColor();
        }
    }
}

