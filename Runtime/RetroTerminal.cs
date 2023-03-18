using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTerminal
{
    // like old school DOS
    public class RetroTerminal : RenderTerminal
    {
        // for dos.png/short-dos.png
        public static Dictionary<int, int> code2SpriteIdx = new Dictionary<int, int>()
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

        public TerminalCanvas terminalCanvas;
        // public Display _display;
        public float _scale;

        public int _charWidth;
        public int _charHeight;

        // public int width => _display.width;
        // public int height => _display.height;

        /// The current display state. The glyphs here mirror what has been rendered.
        public Array2D<Glyph> _glyphs;

        /// The glyphs that have been modified since the last call to [render].
        // public Array2D<Glyph> _changedGlyphs;

        public static RetroTerminal dos(int width, int height,
                float scale, TerminalCanvas canvas) =>
                RetroTerminal.create(width, height, "dos",
                charWidth: 9, charHeight: 16, scale: scale, canvas);

        public static RetroTerminal shortDos(int width, int height, float scale, TerminalCanvas canvas) =>
                RetroTerminal.create(width, height, "dos-short",
                charWidth: 9, charHeight: 13, scale: scale, canvas);

        /// Creates a new terminal using a font image at [imageUrl].
        public static RetroTerminal create(int width, int height, string resName,
            int charWidth,
            int charHeight,
            float scale,
            TerminalCanvas canvas)
        {
            // var display = new Display(width, height);

            return new RetroTerminal(width, height, charWidth, charHeight, scale, resName, canvas);
        }

        RetroTerminal(int width, int height, int _charWidth, int _charHeight,
            float _scale, string resName,
            TerminalCanvas canvas)
        {
            this.width = width;
            this.height = height;

            // this._display = _display;
            this._charWidth = _charWidth;
            this._charHeight = _charHeight;
            this._scale = _scale;

            this.terminalCanvas = canvas;
            this.terminalCanvas.Init(this, resName, code2SpriteIdx);

            _glyphs = new Array2D<Glyph>(width, height, null);
            for (int i = 0; i < _glyphs.width; ++i)
            {
                for (int j = 0; j < _glyphs.height; ++j)
                    _glyphs.Set(i, j, Glyph.clear);
            }

            // _changedGlyphs = new Array2D<Glyph>(width, height, Glyph.clear);
        }

        public override void clearGlyph(int x, int y)
        {
            if (x < 0) return;
            if (x >= width) return;
            if (y < 0) return;
            if (y >= height) return;

            // _changedGlyphs.Get(x, y)._char = Glyph.clear._char;
            // _changedGlyphs.Get(x, y).dirty = true;
            _glyphs.Get(x, y)._char = CharCode.space;
            // _changedGlyphs.Set(x, y, null);
            // Debug.Log($"xx-- set > {x},{y},{Glyph.clear._char}");
        }

        public override void drawGlyph(int x, int y, char chr, Color? fore = null, Color? back = null)
        {
            if (x < 0) return;
            if (x >= width) return;
            if (y < 0) return;
            if (y >= height) return;

            // todo: optimize
            // var glyph = _glyphs.Get(x, y);
            // if (glyph.isEqual(chr, fore.Value) == false) {
            //     _changedGlyphs.Get(x, y)._char = chr;
            //     _changedGlyphs.Get(x, y).dirty = true;
            // } else {
            //     _changedGlyphs.Get(x, y)._char = Glyph.clear._char;
            //     _changedGlyphs.Get(x, y).dirty = true;
            // }
            // var glyph = new Glyph(chr, fore, back);
            if (_glyphs.Get(x, y).isEqual(chr, fore.Value) == false)
            {
                // Debug.Log($"xx-- set 1 > {x}, {y} " + glyph._char);
                _glyphs.Get(x, y)._char = chr;
                _glyphs.Get(x, y).fore = fore.Value;
                Debug.Log($"xx-- set > {x},{y},{chr}");
            }
            // else
            // {
            //     // if (x == 0 && y == 1) Debug.Log("xx-- set 2 > null ");
            //     _changedGlyphs.Set(x, y, null);
            // }
        }

        protected override void _render()
        {
            base._render();

            terminalCanvas.Render();
        }

        public void render(Action<int, int, Glyph> renderGlyph)
        {
            for (var y = 0; y < height; y++) {
                for (var x = 0; x < width; x++) {
                    var glyph = _glyphs.Get(x, y);
                    

                    // Only draw glyphs that are different since the last call.
                    // if (glyph == null) continue;
                    // if (glyph.dirty == false) continue;

                    renderGlyph(x, y, glyph);

                    // It's up to date now.
                    // _glyphs.Get(x, y)._char = glyph._char;
                    // _glyphs.Get(x, y).fore = glyph.fore;
                    // _changedGlyphs.Get(x, y)._char = Glyph.clear._char;
                    // _changedGlyphs.Get(x, y).dirty = false;
                    // _glyphs.Set(x, y, glyph);
                    // _changedGlyphs.Set(x, y, null);
                    // if (x == 0 && y == 1) Debug.Log("xx-- set 3 > null ");
                }
            }
        }

        // public override void render()
        // {
        //     // if (!_imageLoaded) return;

        //     // if (sprs == null)
        //     //     sprs = new Array2D<SpriteRenderer>(width, height, null);

        //     _display.render((x, y, glyph) =>
        //     {
        //         var _char = glyph._char;

        //         // Remap it if it's a Unicode character.
        //         if (code2SpriteIdx.ContainsKey(_char))
        //             _char = code2SpriteIdx[_char];

        //         var sx = (_char % 32) * _charWidth;
        //         var sy = (_char / 32) * _charHeight;

        //         // Fill the background.
        //         // _context.fillStyle = glyph.back.cssColor;
        //         // _context.fillRect(x * _charWidth * _scale, y * _charHeight * _scale,
        //         //     _charWidth * _scale, _charHeight * _scale);

        //         // Don't bother drawing empty characters.
        //         if (_char == 0 || _char == CharCode.space) return;

        //         terminalCanvas.Set(x, y, sprites[_char]);
              

        //         // var color = _getColorFont(glyph.fore);
        //         // _context.imageSmoothingEnabled = false;
        //         // _context.drawImageScaledFromSource(
        //         //     color,
        //         //     sx,
        //         //     sy,
        //         //     _charWidth,
        //         //     _charHeight,
        //         //     x * _charWidth * _scale,
        //         //     y * _charHeight * _scale,
        //         //     _charWidth * _scale,
        //         //     _charHeight * _scale);

        //     });
        // }
    }
}