using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTerminal;
using Screen = UnityTerminal.Screen;


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

    public override bool KeyDown(KeyCode keyCode, bool shift, bool alt)
    {
      base.KeyDown(keyCode, shift, alt);

      Debug.Log("xx-- key down > " + keyCode);

      if (keyCode == KeyCode.Space)
      {
        // Debug.Log("space button down");
        // terminal.push(ConfirmDialog.Create(
        //     "hello",
        //     "ni hao ya"
        //   ));
        return true;
      }
      return false;
    }

    public override bool KeyUp(KeyCode keyCode, bool shift, bool alt)
    {
      Debug.Log("xx-- key up > " + keyCode);
      return false;
    }

  public override void Render(Terminal terminal) {
    // TerminalUtils.DrawBox(terminal, 2, 1, TerminalColor.green);

    terminal.WriteAt(x, 2, "P", TerminalColor.lightGold, TerminalColor.blue);
    terminal.WriteAt(0, 1, "å", TerminalColor.white, TerminalColor.blue);

    var t = terminal.Rect(7, 4, 10, 10);
    t.WriteAt(0, 0, "1");
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
    public RetroCanvas retroCanvas;

    [Header("RUNTIME")]
    public RetroTerminal retroTerminal = null;

    void Start()
    {
        retroTerminal = RetroTerminal.ShortDos(width, height, UnityEngine.Screen.width, UnityEngine.Screen.height, retroCanvas);

        retroTerminal.Push(new MainScreen());
        // _terminal.Push(Dialog.Create(
        //   "hello",
        //   "ni hao ya"
        // ));

        retroTerminal.running = true;

        Camera.main.orthographicSize = UnityEngine.Screen.height / retroCanvas.pixelToUnits / 2;
    }


    void Update()
    {
        if (retroTerminal != null)
            retroTerminal.Tick(Time.deltaTime);
    }
}
