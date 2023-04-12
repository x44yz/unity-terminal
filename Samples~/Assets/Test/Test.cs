using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTerminal;
using Screen = UnityTerminal.Screen;
using Color = UnityTerminal.Color;

class MainScreen : Screen
{
    public MainScreen()
    {
    }

    public int x = 7;
    public float tick = 0f;
    public override void Tick(float dt)
    {

        tick += dt;
        if (tick > 0.5f)
        {
            tick = 0f;
            x = (x + 1) % terminal.width;
        }

        Dirty();
    }

    public override bool KeyDown(KeyCode keyCode, bool shift, bool alt)
    {
        base.KeyDown(keyCode, shift, alt);

        Debug.Log("[test]key down > " + keyCode);
        return false;
    }

    public override bool KeyUp(KeyCode keyCode, bool shift, bool alt)
    {
        Debug.Log("[test]key up > " + keyCode);
        return false;
    }

    public override void Render(Terminal terminal)
    {
        terminal.WriteAt(x, 2, "P", Color.lightGold, Color.blue);
        terminal.WriteAt(0, 1, "å", Color.white, Color.blue);

        var t = terminal.Rect(7, 4, 10, 10);
        t.WriteAt(0, 0, "1");
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
        int sw = UnityEngine.Screen.width;
        int sh = UnityEngine.Screen.height;
        retroTerminal = RetroTerminal.ShortDos(width, height, sw, sh, retroCanvas);
        Camera.main.orthographicSize = sh / retroCanvas.pixelToUnits / 2;

        retroTerminal.Push(new MainScreen());
        retroTerminal.running = true;
    }

    void Update()
    {
        if (retroTerminal != null)
            retroTerminal.Tick(Time.deltaTime);
    }
}
