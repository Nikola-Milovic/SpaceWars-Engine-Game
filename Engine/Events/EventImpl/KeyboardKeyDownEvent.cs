using System;
using Microsoft.Xna.Framework.Input;

namespace Engine.Events {

    public class KeyboardKeyDownEvent : InputEvent {

        public String key;
        public KeyboardKeyDownEvent (Keys key) {
            this.key = key.ToString ();
        }

    }

}