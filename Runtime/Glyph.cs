using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Glyph
    {
        public int ch;
        public Color fore;

        public Glyph(char ch, Color? fore = null)
        {
            this.ch = ch;
            this.fore = fore != null ? fore.Value : Color.white;
        }


        public Glyph(int ch, Color? fore = null)
        {
            this.ch = ch;
            this.fore = fore != null ? fore.Value : Color.white;
        }

        public bool isEqual(int ch, Color fore)
        {
            return this.ch == ch && this.fore.Equals(fore);
        }

        public bool isEqual(Glyph other)
        {
            if (other == null)
                return false;
            return isEqual(other.ch, other.fore);
        }
    }
}