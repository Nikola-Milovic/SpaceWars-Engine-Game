using System;
using Microsoft.Xna.Framework.Input;

namespace Engine.Events {

    public class KeyboardKeyReleaseEvent : InputEvent {

        public String key;
        public KeyboardKeyReleaseEvent (Keys key) {
            this.key = key.ToString ();
        }

    }

}