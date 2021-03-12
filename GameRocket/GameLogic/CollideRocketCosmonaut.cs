using GameRocket.GameObjects;
using Microsoft.Xna.Framework;

namespace GameRocket.GameLogic
{
    class CollideRocketCosmonaut : Collide
    {
        public bool CollideCosmonaut(Rocket rocket, Cosmonaut cosmonaut)
        {
            rocketSize = new Point(rocket._tex.Width, rocket._tex.Height);
            cosmonautSize = new Point(cosmonaut._tex.Width, cosmonaut._tex.Height);

            Rectangle rocketRect = new Rectangle((int)rocket._position.X,
                (int)rocket._position.Y, rocketSize.X, rocketSize.Y);
            Rectangle cosmonautRect = new Rectangle((int)cosmonaut._position.X,
                (int)cosmonaut._position.Y, cosmonautSize.X, cosmonautSize.Y);

            return rocketRect.Intersects(cosmonautRect);
        }
    }
}
