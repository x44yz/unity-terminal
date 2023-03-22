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
        public virtual bool isTransparent => false;

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
        public virtual void Active(Screen popped, object result = null) { }
        public virtual void UnActive(Screen pushed) { }
        public virtual void Tick(float dt) { }
        public virtual void HandleInput() { }
        public virtual void Render() { }
        /// Called when the [UserInterface] has been bound to a new terminal with a
        /// different size while this [Screen] is present.
        public virtual void Resize(int width, int height) { }

        // public virtual void WriteAt(int x, int y, string text, 
        //                         Color? fore = null, Color? back = null) 
        // {
        //     if (terminal == null)
        //         return;
        //     terminal.WriteAt(x, y, text, fore, back);
        // }
        // public virtual void WriteAt(int x, int y, int charCode, 
        //                         Color? fore = null, Color? back = null)
        // {
        //     if (terminal == null)
        //         return;
        //     terminal.WriteAt(x, y, charCode, fore, back);
        // }

        // Dictionary<string, Panel> panels;
        // public Panel GetPanel(string name)
        // {
        //     if (panels == null)
        //         return null;

        //     Panel p = null;
        //     panels.TryGetValue(name, out p);
        //     return p;
        // }

        // public Panel AddPanel(int x, int y, int w, int h)
        // {
        //     string name = $"{x}_{y}_{w}_{h}";
        //     return AddPanel(name, x, y, w ,h);
        // }
        
        // public Panel AddPanel(string name, int x, int y, int w, int h)
        // {
        //     Panel p = GetPanel(name);
        //     if (p != null)
        //         return p;

        //     // lazy init
        //     if (panels == null)
        //         panels = new Dictionary<string, Panel>();
            
        //     p = new Panel();
        //     p.Init(this, x, y, w, h);
        //     panels[name] = p;
        //     return p;
        // }
    }
}