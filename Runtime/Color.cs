using System;
using Mathf = UnityEngine.Mathf;

namespace UnityTerminal
{
    [Serializable]
    public struct Color
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

        public static Color darkCoolGray = new Color(0x26, 0x2a, 0x42);
        public static Color lightWarmGray = new Color(0x84, 0x7e, 0x87);
        public static Color ash = new Color(0xe2, 0xdf, 0xf0);

        public int r;
        public int g;
        public int b;

        public UnityEngine.Color ToUnityColor() => new UnityEngine.Color(r / 255f, g / 255f, b / 255f, 1f);

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public static bool operator ==(Color a, Color b)
        {
            return a.r == b.r && a.g == b.g && a.b == b.b;
        }

        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                var k = (Color)obj;
                return this == k;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return r.GetHashCode() ^ g.GetHashCode() ^ b.GetHashCode();
        }

        public Color Add(Color other, float fractionOther = 1.0f)
        {
            return new Color(
                (int)Mathf.Clamp(r + other.r * fractionOther, 0, 255),
                (int)Mathf.Clamp(g + other.g * fractionOther, 0, 255),
                (int)Mathf.Clamp(b + other.b * fractionOther, 0, 255));
        }

        public Color Blend(Color other, double fractionOther)
        {
            var fractionThis = 1.0f - fractionOther;
            return new Color(
                (int)(r * fractionThis + other.r * fractionOther),
                (int)(g * fractionThis + other.g * fractionOther),
                (int)(b * fractionThis + other.b * fractionOther));
        }

        public Color BlendPercent(Color other, int percentOther) =>
            Blend(other, percentOther / 100f);
    }
}
