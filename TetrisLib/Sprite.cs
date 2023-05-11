using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisLib
{
    public class Sprite
    {
        private Texture2D texture;

        public Vector2 Position;
        public Rectangle rectangle { get => new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

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
