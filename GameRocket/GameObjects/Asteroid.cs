using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace GameRocket.GameObjects
{
    class Asteroid : BaseObject
    {            
        public Asteroid(Vector2 position, double alpha, float scale)
            : base(position, alpha, scale) { }


        public void LoadContent(ContentManager contentManager)
        {
            _tex = contentManager.Load<Texture2D>("asteroid");
        }

        public override void Update(double speedAsteroid)
        {
            _position.X = _position.X - (int)speedAsteroid;

            // проверка на выход астероидов за грани карты
            Random rand = new Random();

            if (_position.X < 0)
            {
                RandomSpaceAsteroid();
            }
        }

        public void RandomSpaceAsteroid()
        {
            Random rand = new Random();
            _position.X = 1360;
            _position.Y = rand.Next(10, 600);
        }
    }
}
