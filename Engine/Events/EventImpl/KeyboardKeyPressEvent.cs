using System.Diagnostics.Tracing;
using Engine.Input;

namespace Engine.Events {

    public class KeyboardKeyPressEvent : InputEvent {

        public KeyboardKey key;

        public KeyboardKeyPressEvent (KeyboardKey key) {
            this.key = key;
        }

    }

}