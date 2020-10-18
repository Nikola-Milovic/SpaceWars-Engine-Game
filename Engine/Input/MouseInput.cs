using Engine.Events;
using Microsoft.Xna.Framework.Input;

namespace Engine.Input {

    public class MouseInput {

        private MouseState previousMouseState;
        private MouseState currentMouseState;

        public MouseInput () {
            previousMouseState = new MouseState ();
            currentMouseState = new MouseState ();
        }
        public void Update () {

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState ();

            EmitInputEvents ();

        }

        private void EmitInputEvents () {
            if (LeftMouseButtonPressed) {
                Globals.eventHandler.AddEvent (new LeftMouseButtonPressed (currentMouseState.Position));
            } else if (LeftMouseButtonDown) {
                Globals.eventHandler.AddEvent (new LeftMouseButtonDown (currentMouseState.Position));
            } else if (LeftMouseButtonReleased) {
                Globals.eventHandler.AddEvent (new LeftMouseButtonReleased (currentMouseState.Position));
            }

            //Todo add right mouse and wheel
            //    if (RightMouseButtonPressed) {
            //     Globals.eventHandler.AddEvent (new LeftMouseButtonPressed (currentMouseState.Position));
            // } else if (RightMouseButtonDown) {
            //     Globals.eventHandler.AddEvent ();
            // } else if (RightMouseButtonReleased) {
            //     Globals.eventHandler.AddEvent ();
            // }

        }

        //Left mouse button
        public bool LeftMouseButtonPressed =>
            currentMouseState.LeftButton == ButtonState.Pressed &&
            previousMouseState.LeftButton == ButtonState.Released;

        public bool LeftMouseButtonDown => currentMouseState.LeftButton == ButtonState.Pressed;

        public bool LeftMouseButtonReleased =>
            currentMouseState.LeftButton == ButtonState.Released &&
            previousMouseState.LeftButton == ButtonState.Pressed;

        //Right mouse button
        public bool RightMouseButtonPressed =>
            currentMouseState.RightButton == ButtonState.Pressed &&
            previousMouseState.RightButton == ButtonState.Released;

        public bool RightMouseButtonDown => currentMouseState.RightButton == ButtonState.Pressed;

        public bool RightMouseButtonReleased =>
            currentMouseState.RightButton == ButtonState.Released &&
            previousMouseState.RightButton == ButtonState.Pressed;

    }

}