using System;
using System.Collections.Generic;
using Mathf = UnityEngine.Mathf;

namespace UnityTerminal
{
    // like old school DOS
    public class RetroTerminal : RenderTerminal
    {
        // for dos.png/short-dos.png
        public static Dictionary<int, int> Code2SpriteIdx = new Dictionary<int, int>()
        {
            // 1 - 15.
            {CharCode.whiteSmilingFace, 1},
            {CharCode.blackSmilingFace, 2},
            {CharCode.blackHeartSuit, 3},
            {CharCode.blackDiamondSuit, 4},
            {CharCode.blackClubSuit, 5},
            {CharCode.blackSpadeSuit, 6},
            {CharCode.bullet, 7},
            {CharCode.inverseBullet, 8},
            {CharCode.whiteCircle, 9},
            {CharCode.inverseWhiteCircle, 10},
            {CharCode.maleSign, 11},
            {CharCode.femaleSign, 12},
            {CharCode.eighthNote, 13},
            {CharCode.beamedEighthNotes, 14},
            {CharCode.whiteSunWithRays, 15},

            // 16 - 31.
            {CharCode.blackRightPointingPointer, 16},
            {CharCode.blackLeftPointingPointer, 17},
            {CharCode.upDownArrow, 18},
            {CharCode.doubleExclamationMark, 19},
            {CharCode.pilcrow, 20},
            {CharCode.sectionSign, 21},
            {CharCode.blackRectangle, 22},
            {CharCode.upDownArrowWithBase, 23},
            {CharCode.upwardsArrow, 24},
            {CharCode.downwardsArrow, 25},
            {CharCode.rightwardsArrow, 26},
            {CharCode.leftwardsArrow, 27},
            {CharCode.rightAngle, 28},
            {CharCode.leftRightArrow, 29},
            {CharCode.blackUpPointingTriangle, 30},
            {CharCode.blackDownPointingTriangle, 31},

            // 127.
            {CharCode.house, 127},

            // 128 - 143.
            {CharCode.latinCapitalLetterCWithCedilla, 128},
            {CharCode.latinSmallLetterUWithDiaeresis, 129},
            {CharCode.latinSmallLetterEWithAcute, 130},
            {CharCode.latinSmallLetterAWithCircumflex, 131},
            {CharCode.latinSmallLetterAWithDiaeresis, 132},
            {CharCode.latinSmallLetterAWithGrave, 133},
            {CharCode.latinSmallLetterAWithRingAbove, 134},
            {CharCode.latinSmallLetterCWithCedilla, 135},
            {CharCode.latinSmallLetterEWithCircumflex, 136},
            {CharCode.latinSmallLetterEWithDiaeresis, 137},
            {CharCode.latinSmallLetterEWithGrave, 138},
            {CharCode.latinSmallLetterIWithDiaeresis, 139},
            {CharCode.latinSmallLetterIWithCircumflex, 140},
            {CharCode.latinSmallLetterIWithGrave, 141},
            {CharCode.latinCapitalLetterAWithDiaeresis, 142},
            {CharCode.latinCapitalLetterAWithRingAbove, 143},

            // 144 - 159.
            {CharCode.latinCapitalLetterEWithAcute, 144},
            {CharCode.latinSmallLetterAe, 145},
            {CharCode.latinCapitalLetterAe, 146},
            {CharCode.latinSmallLetterOWithCircumflex, 147},
            {CharCode.latinSmallLetterOWithDiaeresis, 148},
            {CharCode.latinSmallLetterOWithGrave, 149},
            {CharCode.latinSmallLetterUWithCircumflex, 150},
            {CharCode.latinSmallLetterUWithGrave, 151},
            {CharCode.latinSmallLetterYWithDiaeresis, 152},
            {CharCode.latinCapitalLetterOWithDiaeresis, 153},
            {CharCode.latinCapitalLetterUWithDiaeresis, 154},
            {CharCode.centSign, 155},
            {CharCode.poundSign, 156},
            {CharCode.yenSign, 157},
            {CharCode.pesetaSign, 158},
            {CharCode.latinSmallLetterFWithHook, 159},

            // 160 - 175.
            {CharCode.latinSmallLetterAWithAcute, 160},
            {CharCode.latinSmallLetterIWithAcute, 161},
            {CharCode.latinSmallLetterOWithAcute, 162},
            {CharCode.latinSmallLetterUWithAcute, 163},
            {CharCode.latinSmallLetterNWithTilde, 164},
            {CharCode.latinCapitalLetterNWithTilde, 165},
            {CharCode.feminineOrdinalIndicator, 166},
            {CharCode.masculineOrdinalIndicator, 167},
            {CharCode.invertedQuestionMark, 168},
            {CharCode.reversedNotSign, 169},
            {CharCode.notSign, 170},
            {CharCode.vulgarFractionOneHalf, 171},
            {CharCode.vulgarFractionOneQuarter, 172},
            {CharCode.invertedExclamationMark, 173},
            {CharCode.leftPointingDoubleAngleQuotationMark, 174},
            {CharCode.rightPointingDoubleAngleQuotationMark, 175},

            // 176 - 191.
            {CharCode.lightShade, 176},
            {CharCode.mediumShade, 177},
            {CharCode.darkShade, 178},
            {CharCode.boxDrawingsLightVertical, 179},
            {CharCode.boxDrawingsLightVerticalAndLeft, 180},
            {CharCode.boxDrawingsVerticalSingleAndLeftDouble, 181},
            {CharCode.boxDrawingsVerticalDoubleAndLeftSingle, 182},
            {CharCode.boxDrawingsDownDoubleAndLeftSingle, 183},
            {CharCode.boxDrawingsDownSingleAndLeftDouble, 184},
            {CharCode.boxDrawingsDoubleVerticalAndLeft, 185},
            {CharCode.boxDrawingsDoubleVertical, 186},
            {CharCode.boxDrawingsDoubleDownAndLeft, 187},
            {CharCode.boxDrawingsDoubleUpAndLeft, 188},
            {CharCode.boxDrawingsUpDoubleAndLeftSingle, 189},
            {CharCode.boxDrawingsUpSingleAndLeftDouble, 190},
            {CharCode.boxDrawingsLightDownAndLeft, 191},

            // 192 - 207.
            {CharCode.boxDrawingsLightUpAndRight, 192},
            {CharCode.boxDrawingsLightUpAndHorizontal, 193},
            {CharCode.boxDrawingsLightDownAndHorizontal, 194},
            {CharCode.boxDrawingsLightVerticalAndRight, 195},
            {CharCode.boxDrawingsLightHorizontal, 196},
            {CharCode.boxDrawingsLightVerticalAndHorizontal, 197},
            {CharCode.boxDrawingsVerticalSingleAndRightDouble, 198},
            {CharCode.boxDrawingsVerticalDoubleAndRightSingle, 199},
            {CharCode.boxDrawingsDoubleUpAndRight, 200},
            {CharCode.boxDrawingsDoubleDownAndRight, 201},
            {CharCode.boxDrawingsDoubleUpAndHorizontal, 202},
            {CharCode.boxDrawingsDoubleDownAndHorizontal, 203},
            {CharCode.boxDrawingsDoubleVerticalAndRight, 204},
            {CharCode.boxDrawingsDoubleHorizontal, 205},
            {CharCode.boxDrawingsDoubleVerticalAndHorizontal, 206},
            {CharCode.boxDrawingsUpSingleAndHorizontalDouble, 207},

            // 208 - 223.
            {CharCode.boxDrawingsUpDoubleAndHorizontalSingle, 208},
            {CharCode.boxDrawingsDownSingleAndHorizontalDouble, 209},
            {CharCode.boxDrawingsDownDoubleAndHorizontalSingle, 210},
            {CharCode.boxDrawingsUpDoubleAndRightSingle, 211},
            {CharCode.boxDrawingsUpSingleAndRightDouble, 212},
            {CharCode.boxDrawingsDownSingleAndRightDouble, 213},
            {CharCode.boxDrawingsDownDoubleAndRightSingle, 214},
            {CharCode.boxDrawingsVerticalDoubleAndHorizontalSingle, 215},
            {CharCode.boxDrawingsVerticalSingleAndHorizontalDouble, 216},
            {CharCode.boxDrawingsLightUpAndLeft, 217},
            {CharCode.boxDrawingsLightDownAndRight, 218},
            {CharCode.fullBlock, 219},
            {CharCode.lowerHalfBlock, 220},
            {CharCode.leftHalfBlock, 221},
            {CharCode.rightHalfBlock, 222},
            {CharCode.upperHalfBlock, 223},

            // 224 - 239.
            {CharCode.greekSmallLetterAlpha, 224},
            {CharCode.latinSmallLetterSharpS, 225},
            {CharCode.greekCapitalLetterGamma, 226},
            {CharCode.greekSmallLetterPi, 227},
            {CharCode.greekCapitalLetterSigma, 228},
            {CharCode.greekSmallLetterSigma, 229},
            {CharCode.microSign, 230},
            {CharCode.greekSmallLetterTau, 231},
            {CharCode.greekCapitalLetterPhi, 232},
            {CharCode.greekCapitalLetterTheta, 233},
            {CharCode.greekCapitalLetterOmega, 234},
            {CharCode.greekSmallLetterDelta, 235},
            {CharCode.infinity, 236},
            {CharCode.greekSmallLetterPhi, 237},
            {CharCode.greekSmallLetterEpsilon, 238},
            {CharCode.intersection, 239},

            // 240 - 255.
            {CharCode.identicalTo, 240},
            {CharCode.plusMinusSign, 241},
            {CharCode.greaterThanOrEqualTo, 242},
            {CharCode.lessThanOrEqualTo, 243},
            {CharCode.topHalfIntegral, 244},
            {CharCode.bottomHalfIntegral, 245},
            {CharCode.divisionSign, 246},
            {CharCode.almostEqualTo, 247},
            {CharCode.degreeSign, 248},
            {CharCode.bulletOperator, 249},
            {CharCode.middleDot, 250},
            {CharCode.squareRoot, 251},
            {CharCode.superscriptLatinSmallLetterN, 252},
            {CharCode.superscriptTwo, 253},
            {CharCode.blackSquare, 254},
        };

        public RetroCanvas canvas;
        public int charWidth;
        public int charHeight;
        public float scale;
        public int clearCode;
        public Array2D<Glyph> glyphs;
        public Color foreColor;

        public static RetroTerminal Dos(int width, int height,
                int displayWidthPixels, int displayHeightPixels, RetroCanvas canvas)
        {
            return new RetroTerminal("dos", width, height,
                9, 16, displayWidthPixels, displayHeightPixels, canvas, CharCode.space, Color.white);
        }

        public static RetroTerminal ShortDos(int width, int height,
                int displayWidthPixels, int displayHeightPixels, RetroCanvas canvas)
        {
            return new RetroTerminal("dos-short", width, height,
                9, 13, displayWidthPixels, displayHeightPixels, canvas, CharCode.space, Color.white);
        }

        RetroTerminal(string resName, int width, int height,
            int charWidth, int charHeight,
            int displayWidthPixels, int displayHeightPixels,
            RetroCanvas canvas,
            int clearCode, Color foreColor)
        {
            this.width = width;
            this.height = height;
            this.clearCode = clearCode;
            this.foreColor = foreColor;

            this.charWidth = charWidth;
            this.charHeight = charHeight;
            this.scale = Mathf.Min(displayHeightPixels * 1f / height / charHeight,
                            displayWidthPixels * 1f / width / charWidth);

            this.canvas = canvas;
            this.canvas.Init(this, resName, Code2SpriteIdx);

            glyphs = new Array2D<Glyph>(width, height, null);
            glyphs.Fill(() => { return new Glyph(clearCode, foreColor); });
        }

        public override void WriteAt(int x, int y, string text,
                                Color? fore = null, Color? back = null)
        {
            if (CheckBounds(x, y) == false)
                return;

            for (var i = 0; i < text.Length; i++)
            {
                if (x + i >= width) break;
                WriteAt(x + i, y, text[i], fore, back);
            }
        }

        public override void WriteAt(int x, int y, int charCode,
                                Color? fore = null, Color? back = null)
        {
            if (CheckBounds(x, y) == false)
                return;

            fore ??= foreColor;
            DrawGlyph(x, y, charCode, fore, back);
        }

        // public override void WriteAt(Panel rt, int x, int y, string text, 
        //                         Color? fore = null, Color? back = null) 
        // {
        //     if (rt.y + y >= rt.y + rt.h)
        //         return;

        //     for (var i = 0; i < text.Length; i++)
        //     {
        //         if (rt.x + x + i >= width ||
        //             rt.x + x + i >= rt.x + rt.w) break;
        //         WriteAt(rt.x + x + i, rt.y + y, text[i], fore, back);
        //     }
        // }
        // public override void WriteAt(Panel rt, int x, int y, int charCode, 
        //                         Color? fore = null, Color? back = null)
        // {
        //     if (rt.x + x >= rt.x + rt.w ||
        //         rt.y + y >= rt.y + rt.h)
        //         return;
        //     WriteAt(rt.x + x, rt.y + y, charCode, fore, back);
        // }

        public void clearGlyph(int x, int y)
        {
            if (CheckBounds(x, y) == false)
                return;

            glyphs.Get(x, y).ch = clearCode;
        }

        public void DrawGlyph(int x, int y, int chr, Color? fore = null, Color? back = null)
        {
            if (CheckBounds(x, y) == false)
                return;

            var gh = glyphs.Get(x, y);
            if (gh != null && gh.isEqual(chr, fore, back) == false)
            {
                // Debug.Log($"xx-- set 1 > {x}, {y} " + glyph._char);
                gh.Set(chr, fore, back);
                // Debug.Log($"xx-- set > {x},{y},{chr}");
            }
        }

        protected override void _Render()
        {
            base._Render();

            canvas.Render();
        }

        // public void render(Action<int, int, Glyph> renderGlyph)
        // {
        //     for (var y = 0; y < height; y++) {
        //         for (var x = 0; x < width; x++) {
        //             var glyph = glyphs.Get(x, y);


        //             // Only draw glyphs that are different since the last call.
        //             // if (glyph == null) continue;
        //             // if (glyph.dirty == false) continue;

        //             renderGlyph(x, y, glyph);

        //             // It's up to date now.
        //             // _glyphs.Get(x, y)._char = glyph._char;
        //             // _glyphs.Get(x, y).fore = glyph.fore;
        //             // _changedGlyphs.Get(x, y)._char = Glyph.clear._char;
        //             // _changedGlyphs.Get(x, y).dirty = false;
        //             // _glyphs.Set(x, y, glyph);
        //             // _changedGlyphs.Set(x, y, null);
        //             // if (x == 0 && y == 1) Debug.Log("xx-- set 3 > null ");
        //         }
        //     }
        // }
    }
}