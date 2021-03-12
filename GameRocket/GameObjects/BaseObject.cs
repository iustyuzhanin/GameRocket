using Microsoft.Xna.Framework;

namespace GameRocket.GameObjects
{
    abstract class BaseObject : BaseGame
    {
        public BaseObject(Vector2 position, double alpha, float scale)
        {
            _tex = null;
            _origin = new Vector2(0, 0);
            _position = position;
            _alpha = alpha;
            _scale = scale;
            _color = Color.White;
        }
    }
}
