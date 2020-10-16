using System.Diagnostics;
using Engine.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.Properties;

namespace Gameplay.Scenes {

    public class MainScene : Engine.Scenes.Scene, Engine.Events.EventListener {

        private Gameplay.UI.MainMenu _mainMenu;

        private Desktop _desktop;

        public override void InitializeScene (ContentManager contentManager) {
            base.InitializeScene (contentManager);

            _desktop = new Desktop ();

            _mainMenu = new UI.MainMenu ();

            _desktop.Widgets.Add (_mainMenu);

            Engine.Globals.eventHandler.RegisterListener (this);
        }

        // public override void Dispose () {
        //     content.Unload ();
        // }

        public override void Update (GameTime gameTime) { }

        public override void Draw (SpriteBatch spriteBatch) {
            _desktop.Render ();
        }

        public void onEvent (IEvent ev) {
            if (ev is KeyboardKeyPressEvent) {
                Debug.WriteLine ((ev as KeyboardKeyPressEvent).key.key);
            }
        }
    }

}