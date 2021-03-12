using GameRocket.GameLogic;
using GameRocket.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameRocket
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Создание ракеты (Местоположение, угол поворота, размер)
        Rocket rocket = new Rocket(new Vector2(670, 350), 0 , 1f);

        static Random rand = new Random();
        //Создание космонавтов (Местоположение, угол поворота, размер)    
        Cosmonaut cosmonaut1 = new Cosmonaut(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI, 1.2f);
        Cosmonaut cosmonaut2 = new Cosmonaut(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI / 2, 1.2f);
        Cosmonaut cosmonaut3 = new Cosmonaut(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI, 1.2f);

        //Создание астероидов (Местоположение, угол поворота, размер)
        Asteroid asteroid = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), 0, 1f);
        Asteroid asteroid2 = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 2, 0.9f);
        Asteroid asteroid3 = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 2, 1f);
        Asteroid asteroid4 = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI, 1.5f);
        Asteroid asteroid5 = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 2, 0.8f);
        Asteroid asteroid6 = new Asteroid(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 2, 1.2f);

        CollideRocketAsteroid collideRocketAsteroid = new CollideRocketAsteroid();      //Класс столкновения ракеты с астероидом 
        CollideRocketCosmonaut collideRocketCosmonaut = new CollideRocketCosmonaut();   //Класс столкновения ракеты с космонавтом

        private Texture2D background;   //фон
        private Texture2D _nasa;        //картинка наса
        private Texture2D _control;     //картинка клавиатуры управления
        private Texture2D _B;           //картинка буквы В управления
        private Texture2D _M;           //картинка буквы М управления
        SpriteFont textCosm;            //шрифт для очков Cosmonauts
        SpriteFont textHP;              //шрифт для жизней HP
        SpriteFont gameOver;            //шрифт для GameOver
        int cosm=0;                     //счетчик Cosmonauts
        int HP=3;                       //счетчик HP

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1350;
            graphics.PreferredBackBufferHeight = 700;
            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize(); // здесь загружается текстура
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background");
            _nasa = Content.Load<Texture2D>("nasa");
            _control = Content.Load<Texture2D>("control");
            _B = Content.Load<Texture2D>("b");
            _M = Content.Load<Texture2D>("m");
            textCosm = Content.Load<SpriteFont>("Font");
            textHP = Content.Load<SpriteFont>("Font");
            gameOver = Content.Load<SpriteFont>("FontGameOver");

            rocket.LoadContent(Content, "rocket");

            cosmonaut1.LoadContent(Content, "cosmonaut1");
            cosmonaut2.LoadContent(Content, "cosmonaut2");
            cosmonaut3.LoadContent(Content, "cosmonaut3");

            asteroid.LoadContent(Content);
            asteroid2.LoadContent(Content);
            asteroid3.LoadContent(Content);
            asteroid4.LoadContent(Content);
            asteroid5.LoadContent(Content);
            asteroid6.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            rocket.Update(4);

            cosmonaut1.Update(0.01);
            cosmonaut2.Update(-0.005);
            cosmonaut3.Update(-0.003);

            asteroid.Update(3);
            asteroid2.Update(4);
            asteroid3.Update(5);
            asteroid4.Update(6);
            asteroid5.Update(5);
            asteroid6.Update(4);

            #region Столкновение ракеты с космонавтами

            List<Cosmonaut> cosmonauts = new List<Cosmonaut>();
            cosmonauts.Add(cosmonaut1);
            cosmonauts.Add(cosmonaut2);
            cosmonauts.Add(cosmonaut3);

            foreach (Cosmonaut cosmonaut in cosmonauts)
            {
                if (collideRocketCosmonaut.CollideCosmonaut(rocket, cosmonaut))
                {
                    rocket._color = Color.Green;
                    cosmonaut.RandomSpaceCosmonaut();
                    cosm++;
                }
                else
                {
                    rocket._color = Color.White;
                }
            }
            #endregion

            #region Столкновение ракеты с астероидами

            List<Asteroid> asteroids = new List<Asteroid>();
            asteroids.Add(asteroid);
            asteroids.Add(asteroid2);
            asteroids.Add(asteroid3);
            asteroids.Add(asteroid4);
            asteroids.Add(asteroid5);
            asteroids.Add(asteroid6);

            foreach (Asteroid asteroid in asteroids)
            {
                if (collideRocketAsteroid.CollideAsteroid(rocket, asteroid))
                {
                    rocket._color = Color.Red;
                    asteroid.RandomSpaceAsteroid();
                    HP--;
                }
                else
                {
                    rocket._color = Color.White;
                }
            }
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 1350, 700), Color.Gray);
            spriteBatch.Draw(_nasa, new Rectangle(10,10,120,105),Color.White);

            rocket.Draw(spriteBatch);

            cosmonaut1.Draw(spriteBatch);
            cosmonaut2.Draw(spriteBatch);
            cosmonaut3.Draw(spriteBatch);

            asteroid.Draw(spriteBatch);
            asteroid2.Draw(spriteBatch);
            asteroid3.Draw(spriteBatch);
            asteroid4.Draw(spriteBatch);
            asteroid5.Draw(spriteBatch);
            asteroid6.Draw(spriteBatch);

            spriteBatch.Draw(_control, new Rectangle(1210, 20, 120, 80), Color.Gray);
            spriteBatch.Draw(_B, new Rectangle(1220, 110, 50, 50), Color.Gray);
            spriteBatch.Draw(_M, new Rectangle(1270, 110, 50, 50), Color.Gray);

            string stringCosm = $"Cosmonauts: {cosm}";
            spriteBatch.DrawString(textCosm, stringCosm, new Vector2(140, 10), Color.WhiteSmoke); // вывод очков
            string stringHP = $"HP: {HP}";
            spriteBatch.DrawString(textHP, stringHP, new Vector2(420, 10), Color.Red); // вывод жизней

            if (HP<1)          // Конец игры
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 1350, 700), Color.Black);
                spriteBatch.DrawString(gameOver, "GAME OVER",
                    new Vector2(520, 300),
                    Color.Red);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
