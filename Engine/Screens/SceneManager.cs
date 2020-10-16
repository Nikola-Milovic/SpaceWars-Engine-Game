using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Scenes {

    public class SceneManager {

        private static SceneManager instance;

        public Scene currentScene;

        public ContentManager content;

        //Singleton
        public static SceneManager Instance {
            get {
                if (instance != null) {
                    instance = new SceneManager ();
                }
                return instance;
            }

        }

        public void LoadScene (Scene scene, ContentManager content) {
            if (this.content == null) {
                this.content = content;
            }

            if (currentScene != null) {
                currentScene.Dispose ();
                currentScene = null;
            }

            currentScene = scene;
            currentScene.InitializeScene (content);

        }

        public void UnloadScene () {
            currentScene.Dispose ();
            currentScene = null;
        }

        public void Update (GameTime gameTime) { }

        public void Draw (SpriteBatch spriteBatch) {
            if (currentScene != null) {
                currentScene.Draw (spriteBatch);
            }
        }

    }

}