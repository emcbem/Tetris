using TetrisLib;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisCross
{
    public class Game1 : Game
    {
        private List<Sprite> Tetrominos = new List<Sprite>();
        private Sprite s;
        private List<Sprite> sprites = new List<Sprite>();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Tetrominos.Add(s = new Sprite(Content.Load<Texture2D>("Test"), 100));
            sprites.Add(new Sprite(Content.Load<Texture2D>("Test"), 0) { Position = new Vector2(100, 300) });
            Tetrominos.Add(new Sprite(Content.Load<Texture2D>("Test"), 0) { Position = new Vector2(100, 300) });
            //Board.LoadContent
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //Board.Update()
            foreach (var sprite in Tetrominos)
            {
                sprite.Update(gameTime, sprites);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //Board.Draw();
            foreach (var sprite in Tetrominos)
            {
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}