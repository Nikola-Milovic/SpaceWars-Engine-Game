using System;
using Microsoft.Xna.Framework;
namespace Engine.Events {

    public class LeftMouseButtonDown : InputEvent {

        public Point mousePosition;

        public LeftMouseButtonDown (Point position) {
            this.mousePosition = position;
        }
    }

}