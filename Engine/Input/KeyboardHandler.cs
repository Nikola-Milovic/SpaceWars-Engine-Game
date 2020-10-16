#region Includes
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Engine.Input {
    public class KeyboardHandler {

        //Todo: Add held keys

        public KeyboardState newKeyboard, oldKeyboard;

        public List<KeyboardKey> pressedKeys = new List<KeyboardKey> (), previousPressedKeys = new List<KeyboardKey> ();

        public KeyboardHandler () {

        }

        public virtual void Update () {

            UpdateOld ();

            newKeyboard = Keyboard.GetState ();

            GetPressedKeys ();

        }

        public void UpdateOld () {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<KeyboardKey> ();
            for (int i = 0; i < pressedKeys.Count; i++) {
                previousPressedKeys.Add (pressedKeys[i]);
            }
        }

        public virtual void GetPressedKeys () {
            pressedKeys.Clear ();
            for (int i = 0; i < newKeyboard.GetPressedKeys ().Length; i++) {

                KeyboardKey key = new KeyboardKey (newKeyboard.GetPressedKeys () [i].ToString ());

                pressedKeys.Add (key);

                Globals.eventHandler.AddEvent (new Engine.Events.KeyboardKeyPressEvent (key));
            }
        }

    }
}