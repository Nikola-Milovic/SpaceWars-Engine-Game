using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gameplay.Scenes {
    public class GameScene : Engine.Scenes.Scene {

        Texture2D player;

        public override void InitializeScene (ContentManager contentManager) {
            base.InitializeScene (contentManager);

            player = content.Load<Texture2D> ("sprites\\puppet");
        }

        // public override void Dispose () {
        //     content.Unload ();
        // }

        public override void Update (GameTime gameTime) { }

        public override void Draw (SpriteBatch spriteBatch) {
            spriteBatch.Begin ();

            spriteBatch.Draw (player, new Vector2 (300, 300), Color.White);

            spriteBatch.End ();
        }

    }
}