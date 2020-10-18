using System;
using Microsoft.Xna.Framework;
namespace Engine.Events {

    public class LeftMouseButtonPressed : InputEvent {

        public Point mousePosition;

        public LeftMouseButtonPressed (Point position) {
            this.mousePosition = position;
        }
    }

}