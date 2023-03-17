using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public abstract class RenderTerminal : Terminal
    {
        public List<Screen> _screens = new List<Screen>();
        bool _dirty = true;

   /// Whether or not the UI is listening for keyboard events.
        ///
        /// Initially off.
        bool _handlingInput = false;

        bool _running = false;
        public bool running
        {
            get { return _running; }
            set
            {
                if (value == _running) return;

                _running = value;
                if (_running)
                {
                    // MalisonUnity.Inst.onUpdate = _tick;
                }
                else
                {
                    // MalisonUnity.Inst.onUpdate = null;
                }
            }
        }

        public abstract void render(System.Action<int, int, Glyph> renderGlyph);
        public abstract void krender();

        /// Given a point in pixel coordinates, returns the coordinates of the
        /// character that contains that pixel.
        // public abstract Vector2Int pixelToChar(Vector2Int pixel);

        /// Pushes [screen] onto the top of the stack.
        public void push(Screen screen)
        {
            screen._bind(this);
            _screens.Add(screen);
            _render();
        }

        /// Pops the top screen off the top of the stack.
        ///
        /// The next screen down is activated. If [result] is given, it is passed to
        /// the new active screen's [activate] method.
        void pop(object? result)
        {
            var screen = _screens[_screens.Count - 1];
            _screens.RemoveAt(_screens.Count - 1);
            screen._unbind();
            _screens[_screens.Count - 1].activate(screen, result);
            _render();
        }

  /// Switches the current top screen to [screen].
        ///
        /// This is equivalent to a [pop] followed by a [push].
        void goTo(Screen screen)
        {
            var old = _screens[_screens.Count - 1];
            _screens.RemoveAt(_screens.Count - 1);
            old._unbind();

            screen._bind(this);
            _screens.Add(screen);
            _render();
        }

        public void dirty()
        {
            _dirty = true;
        }
    

        // public override void tick(float dt)
        // {
        //     _tick(dt);
        // }

        // public void refresh()
        // {
        //     // Don't use a for-in loop here so that we don't run into concurrent
        //     // modification exceptions if a screen is added or removed during a call to
        //     // update().
        //     for (var i = 0; i < _screens.Count; i++)
        //     {
        //         _screens[i].update();
        //     }
        //     if (_dirty) 
        //         _render();
        // }

     /// Called every animation frame while the UI's game loop is running.
        public void _tick(float dt)
        {
            if (!_running)
                return;

            // Don't use a for-in loop here so that we don't run into concurrent
            // modification exceptions if a screen is added or removed during a call to
            // update().
            for (var i = 0; i < _screens.Count; i++)
            {
                _screens[i].update(dt);
            }
            if (_dirty) 
                _render();

            // if (_running) html.window.requestAnimationFrame(_tick);
        }

        void _render()
        {
            // // If the UI isn't currently bound to a terminal, there's nothing to render.
            clear();

            // Skip past all of the covered screens.
            int i;
            for (i = _screens.Count - 1; i >= 0; i--)
            {
                if (!_screens[i].isTransparent) break;
            }

            if (i < 0) i = 0;

            // Render the top opaque screen and any transparent ones above it.
            for (; i < _screens.Count; i++)
            {
                _screens[i].render(this);
            }

            krender();
            _dirty = false;
        }


    }
}
