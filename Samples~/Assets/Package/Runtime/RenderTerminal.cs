using System.Collections;
using System.Collections.Generic;
using Input = UnityEngine.Input;
using KeyCode = UnityEngine.KeyCode;

namespace UnityTerminal
{
    public abstract class RenderTerminal : Terminal
    {
        public List<Screen> screens = new List<Screen>();
        public bool dirty = true;
        public bool handlingInput = false;
        public bool running = false;

        public void Push(Screen screen)
        {
            screen.Bind(this);
            if (screens.Count > 0)
            {
                var curTopScreen = screens[screens.Count - 1];
                curTopScreen.UnActive(screen);
            }
            screens.Add(screen);
            _Render();
        }

        public void Pop(object result = null)
        {
            var screen = screens[screens.Count - 1];
            screens.RemoveAt(screens.Count - 1);
            screen.Unbind();
            screens[screens.Count - 1].Active(screen, result);
            _Render();
        }

        public void GoTo(Screen screen)
        {
            var old = screens[screens.Count - 1];
            screens.RemoveAt(screens.Count - 1);
            old.Unbind();

            screen.Bind(this);
            screens.Add(screen);
            _Render();
        }

        public void Dirty()
        {
            dirty = true;
        }

        public override void Tick(float dt)
        {
            if (!running)
                return;

            for (var i = 0; i < screens.Count; i++)
            {
                screens[i].Tick(dt);
            }

            if (dirty)
                _Render();
        }

        protected virtual void _Render()
        {
            Clear();

            // Skip past all of the covered screens.
            int i;
            for (i = screens.Count - 1; i >= 0; i--)
            {
                if (!screens[i].isTransparent)
                    break;
            }

            if (i < 0) i = 0;

            // Render the top opaque screen and any transparent ones above it.
            for (; i < screens.Count; i++)
            {
                screens[i].Render(this);
            }

            dirty = false;
        }

        // public bool IsTopScreen(Screen screen)
        // {
        //     if (screens == null)
        //         return false;
        //     return screens[screens.Count - 1] == screen;
        // }

        public void KeyDown(KeyCode keyCode)
        {
            if (keyCode == KeyCode.None)
                return;

            if (screens.Count > 0)
            {
                bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                bool alt = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
                screens[screens.Count - 1].KeyDown(keyCode, shift, alt);
            }
        }

        public void KeyUp(KeyCode keyCode)
        {
            if (keyCode == KeyCode.None)
                return;

            if (screens.Count > 0)
            {
                bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                bool alt = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
                screens[screens.Count - 1].KeyUp(keyCode, shift, alt);
            }
        }
    }
}
