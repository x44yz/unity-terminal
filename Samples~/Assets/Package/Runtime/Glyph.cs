using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class ColorX
    {
        public static Color black = new Color(0/255.0f, 0/255.0f, 0/255.0f);
        public static Color white = new Color(255/255.0f, 255/255.0f, 255/255.0f);

        public static Color lightGray = new Color(192/255.0f, 192/255.0f, 192/255.0f);
        public static Color gray = new Color(128/255.0f, 128/255.0f, 128/255.0f);
        public static Color darkGray = new Color(64/255.0f, 64/255.0f, 64/255.0f);

        public static Color lightRed = new Color(255/255.0f, 160/255.0f, 160/255.0f);
        public static Color red = new Color(220/255.0f, 0/255.0f, 0/255.0f);
        public static Color darkRed = new Color(100/255.0f, 0/255.0f, 0/255.0f);

        public static Color lightOrange = new Color(255/255.0f, 200/255.0f, 170/255.0f);
        public static Color orange = new Color(255/255.0f, 128/255.0f, 0/255.0f);
        public static Color darkOrange = new Color(128/255.0f, 64/255.0f, 0/255.0f);

        public static Color lightGold = new Color(255/255.0f, 230/255.0f, 150/255.0f);
        public static Color gold = new Color(255/255.0f, 192/255.0f, 0/255.0f);
        public static Color darkGold = new Color(128/255.0f, 96/255.0f, 0/255.0f);

        public static Color lightYellow = new Color(255/255.0f, 255/255.0f, 150/255.0f);
        public static Color yellow = new Color(255/255.0f, 255/255.0f, 0/255.0f);
        public static Color darkYellow = new Color(128/255.0f, 128/255.0f, 0/255.0f);

        public static Color lightGreen = new Color(130/255.0f, 255/255.0f, 90/255.0f);
        public static Color green = new Color(0/255.0f, 128/255.0f, 0/255.0f);
        public static Color darkGreen = new Color(0/255.0f, 64/255.0f, 0/255.0f);

        public static Color lightAqua = new Color(128/255.0f, 255/255.0f, 255/255.0f);
        public static Color aqua = new Color(0/255.0f, 255/255.0f, 255/255.0f);
        public static Color darkAqua = new Color(0/255.0f, 128/255.0f, 128/255.0f);

        public static Color lightBlue = new Color(128/255.0f, 160/255.0f, 255/255.0f);
        public static Color blue = new Color(0/255.0f, 64/255.0f, 255/255.0f);
        public static Color darkBlue = new Color(0/255.0f, 37/255.0f, 168/255.0f);

        public static Color lightPurple = new Color(200/255.0f, 140/255.0f, 255/255.0f);
        public static Color purple = new Color(128/255.0f, 0/255.0f, 255/255.0f);
        public static Color darkPurple = new Color(64/255.0f, 0/255.0f, 128/255.0f);

        public static Color lightBrown = new Color(190/255.0f, 150/255.0f, 100/255.0f);
        public static Color brown = new Color(160/255.0f, 110/255.0f, 60/255.0f);
        public static Color darkBrown = new Color(100/255.0f, 64/255.0f, 32/255.0f);
    }

    public class Glyph
    {
        public static Glyph clear = new Glyph(CharCode.space);

        public int _char;
        public Color fore;
        public Color back;
        public bool dirty;

        // public static Glyph fromDynamic(object charOrCharCode, Color? fore = null, Color? back = null)
        // {
        //     if (charOrCharCode is string)
        //         return new Glyph(charOrCharCode.ToString(), fore, back);
        //     return new Glyph((int)charOrCharCode, fore, back);
        // }

        public Glyph(char ch, Color? fore = null, Color? back = null)
        {
            this._char = ch;
            this.fore = fore != null ? fore.Value : Color.white;
            this.back = back != null ? back.Value : Color.black;
        }


        public Glyph(int ch, Color? fore = null, Color? back = null)
        {
            this._char = ch;
            this.fore = fore != null ? fore.Value : Color.white;
            this.back = back != null ? back.Value : Color.black;
        }

        public bool isEqual(int ch, Color fore)
        {
            return _char == ch && this.fore.Equals(fore);
        }

        public bool isEqual(Glyph other)
        {
            if (other == null)
                return false;
            return _char == other._char && fore == other.fore && back == other.back;
        }

        public bool isNotEqual(Glyph other)
        {
            return !isEqual(other);
        }

        // public bool clear()
        // {
        //     _char = Glyph.empty._char;
        //     dirty = true;
        // }
    }
}