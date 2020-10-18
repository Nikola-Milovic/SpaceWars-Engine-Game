using System;
using Microsoft.Xna.Framework;
namespace Engine.Events {

    public class LeftMouseButtonReleased : InputEvent {

        public Point mousePosition;

        public LeftMouseButtonReleased (Point position) {
            this.mousePosition = position;
        }
    }

}