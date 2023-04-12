using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisLib
{
    public class Sprite
    {
        private Texture2D texture;

        public Vector2 Velocity;
        public Vector2 Position;
        private float speed;
        public Rectangle rectangle { get => new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }

        public Sprite(Texture2D texture, int speed)
        {
            this.texture = texture;
            this.speed = speed;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if(DetectCollision(sprite))
                {
                    speed = 0;
                }
            }

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                Position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                Position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                Position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                Position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            Position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        public bool DetectCollision(Sprite sprite)
        {
            return rectangle.Intersects(sprite.rectangle);
        }
    }


}
