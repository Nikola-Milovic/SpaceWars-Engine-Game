using Engine;
using Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;

namespace SpaceWars {
    public class Main : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Engine.Input.KeyboardHandler keyboard;

        public Main () {
            _graphics = new GraphicsDeviceManager (this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize () {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 340;
            _graphics.PreferredBackBufferWidth = 480;
            _graphics.ApplyChanges ();

            Globals.sceneManager = new SceneManager ();
            Globals.eventHandler = new Engine.Events.EventHandler ();
            keyboard = new Engine.Input.KeyboardHandler ();

            base.Initialize ();
        }

        protected override void LoadContent () {
            MyraEnvironment.Game = this;

            _spriteBatch = new SpriteBatch (GraphicsDevice);

            Scene scene = new Gameplay.Scenes.MainScene (); //new Gameplay.Scenes.GameScene ();

            Globals.sceneManager.LoadScene (scene, this.Content);

            base.LoadContent ();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update (GameTime gameTime) {
            if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
                Exit ();
            // TODO: Add your update logic here

            keyboard.Update ();

            Globals.sceneManager.Update (gameTime);

            Globals.eventHandler.Update ();

            base.Update (gameTime);
        }

        protected override void Draw (GameTime gameTime) {
            GraphicsDevice.Clear (Color.CornflowerBlue);

            Globals.sceneManager.Draw (_spriteBatch);
            // TODO: Add your drawing code here

            base.Draw (gameTime);
        }
    }
}