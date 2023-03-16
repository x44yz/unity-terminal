using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTerminal;

class MainScreen : TScreen {
  public List<Ball> balls = new List<Ball>();

  public MainScreen() {
    var colors = new List<Color>{
      Color.red,
      ColorX.orange,
      ColorX.gold,
      Color.yellow,
      Color.green,
      ColorX.aqua,
      Color.blue,
      ColorX.purple
    };

    foreach (var _char in "0123456789") {
      foreach (var color in colors) {
        balls.Add(new Ball(
            color,
            _char,
            UnityEngine.Random.Range(0f, 1.0f) * Ball.pitWidth,
            UnityEngine.Random.Range(0f, 1.0f) * (Ball.pitHeight / 2.0f),
            UnityEngine.Random.Range(0f, 1.0f) + 0.2f,
            0.0f));
      }
    }
  }

  void profile() {
    ui.running = true;
    for (var i = 0; i < 1000; i++) {
      update();
      ui.refresh();
    }
  }

  public override void update() {
    foreach (var ball in balls) {
      ball.update();
    }

    dirty();
  }

  public override void render(Terminal terminal) {
    terminal.writeAt(0, 0, "☺");
    terminal.writeAt(0, 1, "å");
    terminal.writeAt(7, 4, "å");
    return;

    // terminal.clear();

    // void colorBar(int y, string name, Color light, Color medium, Color dark) {
    //   terminal.writeAt(2, y, name, Color.gray);
    //   terminal.writeAt(10, y, "light", light);
    //   terminal.writeAt(16, y, "medium", medium);
    //   terminal.writeAt(23, y, "dark", dark);

    //   terminal.writeAt(28, y, " light ", Color.black, light);
    //   terminal.writeAt(35, y, " medium ", Color.black, medium);
    //   terminal.writeAt(43, y, " dark ", Color.black, dark);
    // }

    // terminal.writeAt(0, 0, "Predefined colors:");
    // terminal.writeAt(59, 0, "switch terminal [tab]", Color.darkGray);
    // terminal.writeAt(75, 0, "[tab]", Color.lightGray);
    // colorBar(1, "gray", Color.lightGray, Color.gray, Color.darkGray);
    // colorBar(2, "red", Color.lightRed, Color.red, Color.darkRed);
    // colorBar(3, "orange", Color.lightOrange, Color.orange, Color.darkOrange);
    // colorBar(4, "gold", Color.lightGold, Color.gold, Color.darkGold);
    // colorBar(5, "yellow", Color.lightYellow, Color.yellow, Color.darkYellow);
    // colorBar(6, "green", Color.lightGreen, Color.green, Color.darkGreen);
    // colorBar(7, "aqua", Color.lightAqua, Color.aqua, Color.darkAqua);
    // colorBar(8, "blue", Color.lightBlue, Color.blue, Color.darkBlue);
    // colorBar(9, "purple", Color.lightPurple, Color.purple, Color.darkPurple);
    // colorBar(10, "brown", Color.lightBrown, Color.brown, Color.darkBrown);

    // terminal.writeAt(0, 12, "Code page 437:");
    // var lines = new string[]{
    //   " ☺☻♥♦♣♠•◘○◙♂♀♪♫☼",
    //   "►◄↕‼¶§▬↨↑↓→←∟↔▲▼",
    //   " !\"#\\$%&'()*+,-./",
    //   "0123456789:;<=>?",
    //   "@ABCDEFGHIJKLMNO",
    //   "PQRSTUVWXYZ[\\]^_",
    //   "`abcdefghijklmno",
    //   "pqrstuvwxyz{|}~⌂",
    //   "ÇüéâäàåçêëèïîìÄÅ",
    //   "ÉæÆôöòûùÿÖÜ¢£¥₧ƒ",
    //   "áíóúñÑªº¿⌐¬½¼¡«»",
    //   "░▒▓│┤╡╢╖╕╣║╗╝╜╛┐",
    //   "└┴┬├─┼╞╟╚╔╩╦╠═╬╧",
    //   "╨╤╥╙╘╒╓╫╪┘┌█▄▌▐▀",
    //   "αßΓπΣσµτΦΘΩδ∞φε∩",
    //   "≡±≥≤⌠⌡÷≈°∙·√ⁿ²■"
    // };

    // var y = 13;
    // foreach (var line in lines) {
    //   terminal.writeAt(3, y++, line, Color.lightGray);
    // }

    // terminal.writeAt(22, 12, "Simple game loop:");
    // terminal.writeAt(66, 12, "toggle [space]", Color.darkGray);
    // terminal.writeAt(73, 12, "[space]", Color.lightGray);

    // foreach (var ball in balls) {
    //   ball.render(terminal);
    // }
  }
}

class Ball {
  public const float pitWidth = 56.0f;
  public const float pitHeight = 17.0f;

  public Color color;
  public int charCode;

  float x, y, h, v;

  public Ball(Color color, int charCode, 
        float x, float y, float h, float v)
  {
    this.color = color;
    this.charCode = charCode;
    this.x = x;
    this.y = y;
    this.h = h;
    this.v = v;
  }

  public void update() {
    x += h;
    if (x < 0.0) {
      x = -x;
      h = -h;
    } else if (x > pitWidth) {
      x = pitWidth - x + pitWidth;
      h = -h;
    }

    v += 0.03f;
    y += v;
    if (y > pitHeight) {
      y = pitHeight - y + pitHeight;
      v = -v;
    }
  }

  public void render(Terminal terminal) {
    terminal.drawGlyph(24 + (int)x, 13 + (int)y, (char)charCode, color);
  }
}

public class Test : MonoBehaviour
{
    public int width = 80;
    public int height = 45;
    public float offX = 0f;
    public float offY = 0f;

    public UserInterface ui = new UserInterface();

    public float glyphScale = 1f;
    /// A few different terminals to choose from.
    public Terminal terminals(int idx) {
      float scale = Mathf.Min(swidth / (width * 9.0f), sheight / (height * 13.0f));
      scale = glyphScale;

      return RetroTerminal.shortDos(width, height, scale, terminalCanvas); 

        // if (idx == 0) return RetroTerminal.dos(width, height);
        // else if (idx == 1) return RetroTerminal.shortDos(width, height, scale); // 9x13
        // else if (idx == 2) return CanvasTerminal.create(width, height,
        // new Malison.Font("Menlo, Consolas", size: 12, w: 8, h: 14, x: 1, y: 11));
        // else if (idx == 3) return CanvasTerminal.create(
        // width, height, new Malison.Font("Courier", size: 13, w: 10, h: 15, x: 1, y: 11));
        // else if (idx == 4) return CanvasTerminal.create(
        // width, height, new Malison.Font("Courier", size: 12, w: 8, h: 14, x: 1, y: 10));
        // UnityEngine.Debug.LogError("not sumpper > " + idx);
        return null;
    }

    /// Index of the current terminal in [terminals].
    int terminalIndex = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool init = false;
    public TerminalCanvas terminalCanvas;

    void Init()
    {
        if (init /*|| MalisonUnity.Inst == null*/)
            return;
        init = true;

             // Set up the keybindings.
        // ui.keyPress.bind("next terminal", Malison.KeyCode.tab);
        // ui.keyPress.bind("prev terminal", Malison.KeyCode.tab, shift: true);
        // ui.keyPress.bind("animate", Malison.KeyCode.space);
        // ui.keyPress.bind("profile", Malison.KeyCode.p);

        updateTerminal();

        ui.push(new MainScreen());

        // ui.handlingInput = true;
        ui.running = true;

        gscale = Screen.height * 1f / height / (ui._terminal as RetroTerminal)._charHeight;
        Camera.main.orthographicSize = Screen.height / pixelToUnits / 2;
    }

    void updateTerminal() {
        // html.document.body!.children.clear();
        ui.setTerminal((RenderTerminal)terminals(terminalIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
            Init();

        if (ui != null)
            ui._tick(Time.deltaTime);
    }

    public float swidth;
    public float sheight;
    public bool showDisplay = false;
    public UnityEngine.Color displayColor;
    public float pixelToUnits = 100.0f;
    public float gizmoPos = -7f;
    public float gscale = 1f;
    private void OnDrawGizmos() {
      if (!showDisplay)
        return;

      if (ui._terminal == null)
        return;

      if (terminalCanvas == null)
        return;

      // if (MalisonUnity.Inst == null)
      //   return;

      // 600 / 1.2
      // float pixelToUnits = Camera.main.ScreenToWorldPoint
      float charWidth = (ui._terminal as RetroTerminal)._charWidth;
      float charHeight = (ui._terminal as RetroTerminal)._charHeight;
      // var scale = Mathf.Min(swidth / (ui._terminal.width * charWidth), sheight / (ui._terminal.height * charHeight));

      charWidth *= gscale;
      charHeight *= gscale;

      var fx = offX - ui._terminal.width * charWidth * 0.5f;
      var fy = ui._terminal.height * charHeight * 0.5f - offY;
      var off = new Vector3(fx / pixelToUnits, fy / pixelToUnits, 0f);

      Gizmos.color = displayColor;

      for (int i = 0; i <= ui._terminal.width; ++i)
      {
          Vector3 bpos = terminalCanvas.glyphsRoot.position + off + new Vector3(i * charWidth / pixelToUnits, 0 * charHeight/ pixelToUnits, gizmoPos);
          Vector3 epos = terminalCanvas.glyphsRoot.position + off + new Vector3(i * charWidth/ pixelToUnits, -ui._terminal.height * charHeight/ pixelToUnits, gizmoPos);
          Gizmos.DrawLine(bpos, epos);
      }

      for (int j = 0; j <= ui._terminal.height; ++j)
      {
          Vector3 bpos = terminalCanvas.glyphsRoot.position + off + new Vector3(0 * charWidth/ pixelToUnits, -j * charHeight/ pixelToUnits, gizmoPos);
          Vector3 epos = terminalCanvas.glyphsRoot.position + off + new Vector3(ui._terminal.width * charWidth/ pixelToUnits, -j * charHeight/ pixelToUnits, gizmoPos);
          Gizmos.DrawLine(bpos, epos);
      }
    }
}
