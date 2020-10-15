using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Scenes {

    abstract public class Scene {

        protected ContentManager content;

        public virtual void InitializeScene (ContentManager contentManager) {
            this.content = new ContentManager (contentManager.ServiceProvider, contentManager.RootDirectory);
            content.RootDirectory = "Content";
        }

        public virtual void Dispose () {
            content.Unload ();
        }

        public virtual void Update (GameTime gameTime) { }

        public virtual void Draw (SpriteBatch spriteBatch) { }

    }

}