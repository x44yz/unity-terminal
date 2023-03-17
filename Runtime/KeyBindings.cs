// using System;
// using System.Collections.Generic;

// namespace UnityTerminal
// {
//   public class KeyBindings<T> {
//     /// The high-level inputs and the low level keyboard bindings that are mapped
//     /// to them.
//     public Dictionary<_KeyBinding, T> _bindings = new Dictionary<_KeyBinding, T>();

//     public void bind(T input, int keyCode, bool shift = false, bool alt = false) {
//       _bindings[new _KeyBinding(keyCode, shift: shift, alt: alt)] = input;
//     }

//     public T find(int keyCode, bool shift = false, bool alt = false) {
//       return _bindings[new _KeyBinding(keyCode, shift: shift, alt: alt)];
//     }
//   }

//   /// Defines a specific key input (character code and modifier keys) that can be
//   /// bound to a higher-level input in the application domain.
//   public class _KeyBinding {
//     /// The character code this is bound to.
//     public int charCode;

//     /// Whether this key binding requires the shift modifier key to be pressed.
//     public bool shift;

//     // TODO: Mac-specific. What should this be?
//     /// Whether this key binding requires the alt modifier key to be pressed.
//     public bool alt;

//     public _KeyBinding(int charCode, bool shift, bool alt)
//     {
//       this.charCode = charCode; 
//       this.shift = shift;
//       this.alt = alt;
//     }

//     public static bool operator ==(_KeyBinding a, _KeyBinding b) {
//         return a.charCode == b.charCode &&
//             a.shift == b.shift &&
//             a.alt == b.alt;
//     }

//     public static bool operator !=(_KeyBinding a, _KeyBinding b) {
//         return (a == b) == false;
//     }

//     int hashCode => charCode.GetHashCode() ^ shift.GetHashCode() ^ alt.GetHashCode();

//     string toString() {
//       var result = $"key({charCode}";
//       if (shift) result += " shift";
//       if (alt) result += " alt";
//       return result + ")";
//     }
//   }
// }