using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProgrammingII_Final
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Player 1
        int playerSpeed = 3;
        Texture2D player1Tex;
        Rectangle player1Pos = new Rectangle(400, 500, 39, 49);
        Vector2 player1PosVector = new Vector2(400,500);
        Texture2D player1ShotTex;
        List<Vector2> player1Shot = new List<Vector2>();
        int player1ShotTotal = 0;
        KeyboardState currentState;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.Title = "Space Shooty";
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player1Tex = Content.Load<Texture2D>("player1");
            player1ShotTex = Content.Load<Texture2D>("player1Shot");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            currentState = Keyboard.GetState();
            
            if (currentState.IsKeyDown(Keys.A) && player1Pos.X > 3){ player1Pos.X = player1Pos.X - playerSpeed;}
            if (currentState.IsKeyDown(Keys.D) && player1Pos.X < 760) { player1Pos.X = player1Pos.X + playerSpeed; } 

            if (currentState.IsKeyDown(Keys.Space))
            {
                player1Shot.Add(player1PosVector);
                player1ShotTotal++;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            spriteBatch.Draw(player1Tex, player1Pos, Color.Wheat);
            drawShots();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void drawShots()
        {
            if (player1ShotTotal == 0) //Should I draw shots?
            {
                int i = player1ShotTotal; //Shots counter
                while (i > 0) // Drawing shots
                {
                    i++;
                    spriteBatch.Draw(player1ShotTex, player1Shot[i], Color.White);
                }
            }
        }
    }
}
