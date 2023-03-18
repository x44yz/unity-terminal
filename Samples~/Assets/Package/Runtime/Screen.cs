using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Screen
    {
        public RenderTerminal terminal = null;

        /// Whether this screen is bound to a [RenderTerminal].
        ///
        /// If this is `false`, then [terminal] cannot be accessed.
        bool isBind => terminal != null;

        /// Whether this screen allows any screens under it to be visible.
        ///
        /// Subclasses can override this. Defaults to `false`.
        public bool isTransparent => false;

        // public bool isTop
        // {
        //     get 
        //     {
        //         if (terminal == null)
        //             return false;
        //         return terminal.IsTopScreen(this);
        //     }
        // }

        /// Binds this screen to [terminal].
        public void Bind(RenderTerminal tel)
        {
            Debug.Assert(terminal == null);
            terminal = tel;

            Resize(terminal.width, terminal.height);
        }

        /// Unbinds this screen from the [terminal] that owns it.
        public void Unbind()
        {
            Debug.Assert(terminal != null);
            terminal = null;
        }

        /// Marks the user interface as needing to be rendered.
        ///
        /// Call this during [update] to indicate that a subsequent call to [render]
        /// is needed.
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
        public virtual void Tick(float dt) { }
        public virtual void HandleInput() { }
        public virtual void Render(Terminal terminal) { }
        /// Called when the [UserInterface] has been bound to a new terminal with a
        /// different size while this [Screen] is present.
        public virtual void Resize(int width, int height) { }
    }
}