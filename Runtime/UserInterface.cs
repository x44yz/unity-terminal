using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    /// A simple modal user interface layer.
    ///
    /// It maintains a stack of screens. All screens in the stack update. Screens
    /// may indicate if they are opaque or transparent. Transparent screens allow
    /// the screen under them to render.
    ///
    /// In addition, the interface can define a number of global [KeyBindings]
    /// which screens can use to map raw keypresses to something higher-level.
    // public class UserInterface
    // {
    //     /// Keyboard bindings for key press events.
    //     // public KeyBindings<T> keyPress = new KeyBindings<T>();

    //     public List<TScreen> _screens = new List<TScreen>();
    //     public RenderTerminal _terminal;
    //     bool _dirty = true;


    //     /// Whether or not the UI is listening for keyboard events.
    //     ///
    //     /// Initially off.
    //     bool _handlingInput = false;

    //     /// Whether or not the game loop is running and the UI is refreshing itself
    //     /// every frame.
    //     ///
    //     /// Initially off.
    //     ///
    //     /// If you want to manually refresh the UI yourself when you know it needs
    //     /// to be updated -- maybe your game is explicitly turn-based -- you can
    //     /// leave this off.
    //     bool _running = false;
    //     public bool running
    //     {
    //         get { return _running; }
    //         set
    //         {
    //             if (value == _running) return;

    //             _running = value;
    //             if (_running)
    //             {
    //                 // MalisonUnity.Inst.onUpdate = _tick;
    //             }
    //             else
    //             {
    //                 // MalisonUnity.Inst.onUpdate = null;
    //             }
    //         }
    //     }

    //     public UserInterface(RenderTerminal _terminal = null)
    //     {
    //         this._terminal = _terminal;
    //     }

    //     public void setTerminal(RenderTerminal terminal)
    //     {
    //         var resized = terminal != null &&
    //             (_terminal == null ||
    //                 _terminal!.width != terminal.width ||
    //                 _terminal!.height != terminal.height);

    //         _terminal = terminal;
    //         dirty();

    //         // If the terminal size changed, let the screens known.
    //         if (resized)
    //         {
    //             foreach (var screen in _screens)
    //                 screen.resize(terminal.size);
    //         }
    //     }

    //     /// Pushes [screen] onto the top of the stack.
    //     public void push(TScreen screen)
    //     {
    //         screen._bind(this);
    //         _screens.Add(screen);
    //         _render();
    //     }

    //     /// Pops the top screen off the top of the stack.
    //     ///
    //     /// The next screen down is activated. If [result] is given, it is passed to
    //     /// the new active screen's [activate] method.
    //     void pop(object? result)
    //     {
    //         var screen = _screens[_screens.Count - 1];
    //         _screens.RemoveAt(_screens.Count - 1);
    //         screen._unbind();
    //         _screens[_screens.Count - 1].activate(screen, result);
    //         _render();
    //     }

    //     /// Switches the current top screen to [screen].
    //     ///
    //     /// This is equivalent to a [pop] followed by a [push].
    //     void goTo(TScreen screen)
    //     {
    //         var old = _screens[_screens.Count - 1];
    //         _screens.RemoveAt(_screens.Count - 1);
    //         old._unbind();

    //         screen._bind(this);
    //         _screens.Add(screen);
    //         _render();
    //     }

    //     public void dirty()
    //     {
    //         _dirty = true;
    //     }

    //     public void refresh()
    //     {
    //         // Don't use a for-in loop here so that we don't run into concurrent
    //         // modification exceptions if a screen is added or removed during a call to
    //         // update().
    //         for (var i = 0; i < _screens.Count; i++)
    //         {
    //             _screens[i].update();
    //         }
    //         if (_dirty) _render();
    //     }
    //     // if (screen.keyDown(keyCode, shift: event.shiftKey, alt: event.altKey)) {
    //     //   event.preventDefault();
    //     // }
    //     // if (screen.keyDown())
    //     // {

    //     // }

    //     void _keyUp()
    //     {
    //         // var keyCode = event.keyCode;

    //         // Firefox uses 59 for semicolon.
    //         // if (keyCode == 59) keyCode = KeyCode.semicolon;

    //         // var screen = _screens.last;
    //         // if (screen.keyUp(keyCode, shift: event.shiftKey, alt: event.altKey)) {
    //         //   event.preventDefault();
    //         // }
    //     }

    //     /// Called every animation frame while the UI's game loop is running.
    //     public void _tick(float dt)
    //     {
    //         if (!_running)
    //             return;

    //         refresh();

    //         // if (_running) html.window.requestAnimationFrame(_tick);
    //     }

    //     void _render()
    //     {
    //         // If the UI isn't currently bound to a terminal, there's nothing to render.
    //         var terminal = _terminal;
    //         if (terminal == null) return;

    //         terminal.clear();

    //         // Skip past all of the covered screens.
    //         int i;
    //         for (i = _screens.Count - 1; i >= 0; i--)
    //         {
    //             if (!_screens[i].isTransparent) break;
    //         }

    //         if (i < 0) i = 0;

    //         // Render the top opaque screen and any transparent ones above it.
    //         for (; i < _screens.Count; i++)
    //         {
    //             _screens[i].render(terminal);
    //         }

    //         _dirty = false;
    //         terminal.render();
    //     }
    // }
}