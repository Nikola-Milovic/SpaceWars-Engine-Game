using System;
using Microsoft.Xna.Framework.Input;
namespace Engine.Events {

    public class KeyboardKeyPressEvent : InputEvent {

        public String key;
        public KeyboardKeyPressEvent (Keys key) {
            this.key = key.ToString ();
        }

    }

}