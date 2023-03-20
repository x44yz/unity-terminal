using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Panel
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public Panel(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        // public void Init(Screen s, int x, int y, int width, int height)
        // {
        //     parent = s;
        //     this.sx = x;
        //     this.sy = y;
        //     this.width = width;
        //     this.height = height;
        // }

        // public void WriteAt(int x, int y, string text, 
        //                 Color? fore = null, Color? back = null) 
        // {
        //     if (parent == null)
        //         return;
        //     parent.WriteAt(sx + x, sy + y, text, fore, back);
        // }
        // public void WriteAt(int x, int y, int charCode, 
        //                 Color? fore = null, Color? back = null)
        // {
        //     if (parent == null)
        //         return;
        //     parent.WriteAt(sx + x, sy + y, charCode, fore, back);
        // }
    }
}