using TetrisLib;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisCross
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private GameRunner _runner;
        private SpriteBatch _spriteBatch;
        private Texture2D _block;
        private Texture2D _grid;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _runner = new GameRunner();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _runner.GameStart();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _block = Content.Load<Texture2D>("Test");
            _grid = Content.Load<Texture2D>("Grid");
            //Board.LoadContent
        }

		private const float _delay = 15; // seconds
		private float _remainingDelay = _delay;

		protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here

			var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

			_remainingDelay -= timer;

			if (_remainingDelay <= 0)
			{
			    _runner.AdvanceGameState();
				_remainingDelay = _delay;
			}

            var keyStates = Keyboard.GetState();
            if(keyStates.IsKeyDown(Keys.Right)) 
            {
                _runner.MoveActivePieceRight();
            }
            if (keyStates.IsKeyDown(Keys.Left))
			{
				_runner.MoveActivePieceLeft();
			}
			if (keyStates.IsKeyDown(Keys.Down))
			{
				_runner.MoveActivePieceDown();
			}

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //Board.Draw();
            var tileSize = 10;
			for (int i = 0; i < 10; ++i)
			{
				for (int j = 0; j < 20; ++j)
				{
                    if (_runner.CurrentBoard.grid[j, i] != 0)
                    {
					    _spriteBatch.Draw(_block, new Rectangle(i * tileSize, j * tileSize, tileSize, tileSize), Color.Beige);
                    }
                    else
                    {
						_spriteBatch.Draw(_grid, new Rectangle(i * tileSize, j * tileSize, tileSize, tileSize), Color.Beige);

					}
				}
			}

			_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}