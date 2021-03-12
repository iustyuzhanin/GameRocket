using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameRocket.GameObjects
{
    abstract class BaseGame
    {
        public Texture2D _tex;
        public Vector2 _position;
        protected double _alpha;
        protected Vector2 _origin;
        public float _scale;
        public Color _color;

        public abstract void Update(double speed);

        public void LoadContent(ContentManager contentManager, string image)
        {
            _tex = contentManager.Load<Texture2D>(image);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _tex,
                _position,
                null,  // прямоугольник
                _color,
                (float)_alpha, // угол вращения
                _origin = new Vector2(_tex.Width / 2, _tex.Height / 2), // точка вращения
                _scale, // коэф масштаб
                SpriteEffects.None,
                1);
        }
    }
}
