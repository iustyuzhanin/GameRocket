using GameRocket.GameObjects;
using Microsoft.Xna.Framework;

namespace GameRocket.GameLogic
{
    class CollideRocketAsteroid : Collide
    {
        public bool CollideAsteroid(Rocket rocket, Asteroid asteroid)
        {
            rocketSize = new Point(rocket._tex.Width, rocket._tex.Height);
            asteroidSize = new Point(asteroid._tex.Width, asteroid._tex.Height);

            Rectangle rocketRect = new Rectangle((int)rocket._position.X,
                (int)rocket._position.Y, rocketSize.X, rocketSize.Y);
            Rectangle asteroidRect = new Rectangle((int)asteroid._position.X,
                (int)asteroid._position.Y, asteroidSize.X, asteroidSize.Y);

            return rocketRect.Intersects(asteroidRect);
        }
    }
}
