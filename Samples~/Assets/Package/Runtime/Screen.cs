using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Screen
    {
        public RenderTerminal terminal = null;

        /// Whether this screen is bound to a [RenderTerminal].
        bool isBind => terminal != null;

        /// Whether this screen allows any screens under it to be visible.
        public bool isTransparent = false;

        public void Bind(RenderTerminal tel)
        {
            Debug.Assert(terminal == null);
            terminal = tel;

            Resize(terminal.width, terminal.height);
        }

        public void Unbind()
        {
            Debug.Assert(terminal != null);
            terminal = null;
        }

        public void Dirty()
        {
            // If we aren't bound (yet), just do nothing. The screen will be dirtied
            // when it gets bound.
            if (terminal == null) return;

            terminal.Dirty();
        }

        /// Called when the screen above this one ([popped]) has been popped and this
        /// screen is now the top-most screen. If a value was passed to [pop()], it
        /// will be passed to this as [result].
        public virtual void Activate(Screen popped, object result) { }
        public virtual void UnActive(Screen last) { }
        public virtual void Tick(float dt) { }
        public virtual void HandleInput() { }
        public virtual void Render(Terminal terminal) { }
        /// Called when the [UserInterface] has been bound to a new terminal with a
        /// different size while this [Screen] is present.
        public virtual void Resize(int width, int height) { }
        public virtual void OnBind() { }
        public virtual void OnUnBind() { }
    }
}