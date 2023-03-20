using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTerminal;
using Screen = UnityTerminal.Screen;

class PlayerInfoPanel : Panel {

}

class HudPanel : Panel {

}

class MainScreen : Screen {
  // public List<Ball> balls = new List<Ball>();

  public MainScreen() {
    var colors = new List<Color>{
      Color.red,
      TerminalColor.orange,
      TerminalColor.gold,
      Color.yellow,
      Color.green,
      TerminalColor.aqua,
      Color.blue,
      TerminalColor.purple
    };

    // foreach (var _char in "0123456789") {
    //   foreach (var color in colors) {
    //     balls.Add(new Ball(
    //         color,
    //         _char,
    //         UnityEngine.Random.Range(0f, 1.0f) * Ball.pitWidth,
    //         UnityEngine.Random.Range(0f, 1.0f) * (Ball.pitHeight / 2.0f),
    //         UnityEngine.Random.Range(0f, 1.0f) + 0.2f,
    //         0.0f));
    //   }
    // }
  }

  // void profile() {
  //   ui.running = true;
  //   for (var i = 0; i < 1000; i++) {
  //     update();
  //     ui.refresh();
  //   }
  // }

  public int x = 7;
  public float tick = 0f;
  public override void Tick(float dt) {
    // foreach (var ball in balls) {
    //   ball.update();
    // }
    tick += dt;
    if (tick > 0.5f)
    {
      tick = 0f;
      x = (x + 1)%terminal.width;
      // Debug.Log("xx-- x > " + x);
    }

    Dirty();
  }

  public override void HandleInput()
  {
    // check input
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("space button down");
      // terminal.push(ConfirmDialog.Create(
      //     "hello",
      //     "ni hao ya"
      //   ));
    }
  }

  public override void Render() {
    // TerminalUtils.DrawBox(terminal, 2, 1, TerminalColor.green);

    WriteAt(x, 2, "P", TerminalColor.lightGold, TerminalColor.blue);
    WriteAt(0, 1, "å", TerminalColor.white, TerminalColor.blue);

    var p = AddPanel("t1", 7, 4, 10, 10);
    p.WriteAt(0, 0, "1");
    // terminal.writeAt(7, 4, "å");
    // terminal.writeAt(0, 0, "Predefined colors:");
    // terminal.writeAt(59, 0, "switch terminal [tab]", ColorX.darkGray);
    // terminal.writeAt(75, 0, "[tab]", ColorX.lightGray);
    return;
  }
}

public class Test : MonoBehaviour
{
    public int width = 80;
    public int height = 45;
    public float offX = 0f;
    public float offY = 0f;

    // public UserInterface ui = new UserInterface();

    /// Index of the current terminal in [terminals].
    int terminalIndex = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool init = false;
    public RetroCanvas retroCanvas;
    public RetroTerminal _terminal = null;

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

        // gscale = Mathf.Min(UnityEngine.Screen.height * 1f / height / 13.0f, UnityEngine.Screen.width * 1f / width / 9f);

        // updateTerminal();
        _terminal = RetroTerminal.ShortDos(width, height, UnityEngine.Screen.width, UnityEngine.Screen.height, retroCanvas as RetroCanvas);
        gscale = _terminal.scale;

        // ui.push(new MainScreen());
        _terminal.Push(new MainScreen());
        // _terminal.Push(Dialog.Create(
        //   "hello",
        //   "ni hao ya"
        // ));

        // ui.handlingInput = true;
        // ui.running = true;
        _terminal.running = true;

        
        Camera.main.orthographicSize = UnityEngine.Screen.height / pixelToUnits / 2;
    }

    // void updateTerminal() {
    //     // html.document.body!.children.clear();
    //     ui.setTerminal((RenderTerminal)terminals(terminalIndex));
    // }

    // Update is called once per frame
    void Update()
    {
        if (!init)
            Init();

        if (_terminal != null)
            _terminal.Tick(Time.deltaTime);
    }

    public float swidth;
    public float sheight;
    public bool showDisplay = false;
    public UnityEngine.Color displayColor;
    public float pixelToUnits = 100.0f;
    public float gizmoPos = -7f;
    public float gscale = 1f;
}
