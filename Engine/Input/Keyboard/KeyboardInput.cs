#region Includes
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Engine.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Engine.Input {
    public class KeyboardInput {

        private KeyboardState currentKbState, previousKbState;

        private List<Keys> downKeys = new List<Keys> ();

        public KeyboardInput () {

        }

        public virtual void Update () {
            //  UpdateOld ();

            previousKbState = currentKbState;
            currentKbState = Keyboard.GetState ();

            // GetPressedKeys ();

            UpdateDownKeys ();

            EmitInputEvents ();
        }

        public void EmitInputEvents () {
            var keys = currentKbState.GetPressedKeys ();
            for (int i = 0; i < keys.Length; i++) {

                Keys key = keys[i];

                if (IsKeyDown (keys[i]) && !downKeys.Contains (key)) {
                    Globals.eventHandler.AddEvent (new KeyboardKeyDownEvent (key));
                }
                if (IsKeyPressed (key)) {
                    Globals.eventHandler.AddEvent (new KeyboardKeyPressEvent (key));
                }
            }

            //Difference between previous keys and current keys is the released keys, the keys who were down before but aren't anymore are released
            foreach (Keys key in previousKbState.GetPressedKeys ().Except (keys)) {
                if (IsKeyReleased (key)) {
                    Globals.eventHandler.AddEvent (new KeyboardKeyReleaseEvent (key));
                }
            }

        }

        public void UpdateDownKeys () {
            downKeys = currentKbState.GetPressedKeys ().Intersect (previousKbState.GetPressedKeys ()).ToList ();
        }

        private bool IsKeyPressed (Keys key) {
            return currentKbState.IsKeyDown (key) && !previousKbState.IsKeyDown (key);

        }
        private bool IsKeyDown (Keys key) {
            return currentKbState.IsKeyDown (key);
        }

        private bool IsKeyReleased (Keys key) {
            return !currentKbState.IsKeyDown (key) && previousKbState.IsKeyDown (key);
        }

    }
}