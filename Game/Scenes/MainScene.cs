using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.Properties;

namespace Gameplay.Scenes {

    public class MainScene : Engine.Scenes.Scene {

        private Gameplay.UI.MainMenu _mainMenu;

        private Desktop _desktop;

        public override void InitializeScene (ContentManager contentManager) {
            base.InitializeScene (contentManager);

            _desktop = new Desktop ();

            _mainMenu = new UI.MainMenu ();

            _desktop.Widgets.Add (_mainMenu);
        }

        // public override void Dispose () {
        //     content.Unload ();
        // }

        public override void Update (GameTime gameTime) { }

        public override void Draw (SpriteBatch spriteBatch) {
            _desktop.Render ();
        }

    }

}