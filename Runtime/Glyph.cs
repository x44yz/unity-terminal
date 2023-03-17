using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class ColorX
    {
        public static Color black = new Color(0, 0, 0);
        public static Color white = new Color(255, 255, 255);

        public static Color lightGray = new Color(192, 192, 192);
        public static Color gray = new Color(128, 128, 128);
        public static Color darkGray = new Color(64, 64, 64);

        public static Color lightRed = new Color(255, 160, 160);
        public static Color red = new Color(220, 0, 0);
        public static Color darkRed = new Color(100, 0, 0);

        public static Color lightOrange = new Color(255, 200, 170);
        public static Color orange = new Color(255, 128, 0);
        public static Color darkOrange = new Color(128, 64, 0);

        public static Color lightGold = new Color(255, 230, 150);
        public static Color gold = new Color(255, 192, 0);
        public static Color darkGold = new Color(128, 96, 0);

        public static Color lightYellow = new Color(255, 255, 150);
        public static Color yellow = new Color(255, 255, 0);
        public static Color darkYellow = new Color(128, 128, 0);

        public static Color lightGreen = new Color(130, 255, 90);
        public static Color green = new Color(0, 128, 0);
        public static Color darkGreen = new Color(0, 64, 0);

        public static Color lightAqua = new Color(128, 255, 255);
        public static Color aqua = new Color(0, 255, 255);
        public static Color darkAqua = new Color(0, 128, 128);

        public static Color lightBlue = new Color(128, 160, 255);
        public static Color blue = new Color(0, 64, 255);
        public static Color darkBlue = new Color(0, 37, 168);

        public static Color lightPurple = new Color(200, 140, 255);
        public static Color purple = new Color(128, 0, 255);
        public static Color darkPurple = new Color(64, 0, 128);

        public static Color lightBrown = new Color(190, 150, 100);
        public static Color brown = new Color(160, 110, 60);
        public static Color darkBrown = new Color(100, 64, 32);
    }

    public class Glyph
    {
        public static Glyph clear = new Glyph(CharCode.space);

        public int _char;
        public Color fore;
        public Color back;

        public Glyph(string ch, Color? fore = null, Color? back = null)
        {
            this._char = ch[0];
            this.fore = fore != null ? fore.Value : Color.white;
            this.back = back != null ? back.Value : Color.black;
        }


        public Glyph(int ch, Color? fore = null, Color? back = null)
        {
            this._char = ch;
            this.fore = fore != null ? fore.Value : Color.white;
            this.back = back != null ? back.Value : Color.black;
        }

        public static Glyph fromDynamic(object charOrCharCode, Color? fore = null, Color? back = null)
        {
            if (charOrCharCode is string)
                return new Glyph(charOrCharCode.ToString(), fore, back);
            return new Glyph((int)charOrCharCode, fore, back);
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
    }
}