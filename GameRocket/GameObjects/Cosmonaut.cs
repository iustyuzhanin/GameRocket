using Microsoft.Xna.Framework;
using System;

namespace GameRocket.GameObjects
{
    class Cosmonaut : BaseObject
    {
        public Cosmonaut(Vector2 position, double alpha, float scale)
            : base(position, alpha, scale) { }

        public override void Update(double rotationalSpeed)
        {
            _position.Y = _position.Y - (float)0.02;
            _position.X = _position.X - (float)0.02;
            _alpha = _alpha + rotationalSpeed;          //угол и скорость вращения

            // проверка на выход космонавтов за грани карты
            if (_position.X > 1300 || _position.X < 20 || _position.Y > 650 || _position.Y < 20)
            {
                RandomSpaceCosmonaut();
            }
        }

        public void RandomSpaceCosmonaut()
        {
            Random rand = new Random();
            _position.X = rand.Next(100, 1300);
            _position.Y = rand.Next(50, 650);
        }
    }
}
