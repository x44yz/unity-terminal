using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    public class Screen
    {
        // UserInterface _ui;

        /// The [UserInterface] this screen is bound to.
        ///
        /// Throws an exception if the screen is not currently bound to an interface.
        // public UserInterface ui => _ui!;
        public RenderTerminal terminal = null;

        /// Whether this screen is bound to a [UserInterface].
        ///
        /// If this is `false`, then [ui] cannot be accessed.
        bool isBound => terminal != null;

        /// Whether this screen allows any screens under it to be visible.
        ///
        /// Subclasses can override this. Defaults to `false`.
        public bool isTransparent => false;

        /// Binds this screen to [ui].
        public void _bind(RenderTerminal tel)
        {
            Debug.Assert(terminal == null);
            terminal = tel;

            resize(terminal.width, terminal.height);
        }

        /// Unbinds this screen from the [ui] that owns it.
        public void _unbind()
        {
            Debug.Assert(terminal != null);
            terminal = null;
        }

        /// Marks the user interface as needing to be rendered.
        ///
        /// Call this during [update] to indicate that a subsequent call to [render]
        /// is needed.
        public void dirty()
        {
            // If we aren't bound (yet), just do nothing. The screen will be dirtied
            // when it gets bound.
            if (terminal == null) return;

            terminal!.dirty();
        }

        /// Called when the screen above this one ([popped]) has been popped and this
        /// screen is now the top-most screen. If a value was passed to [pop()], it
        /// will be passed to this as [result].
        public virtual void activate(Screen popped, object result) { }

        public virtual void update() { }

        public virtual void render(Terminal terminal) { }

        /// Called when the [UserInterface] has been bound to a new terminal with a
        /// different size while this [Screen] is present.
        public virtual void resize(int width, int height) { }
    }
}