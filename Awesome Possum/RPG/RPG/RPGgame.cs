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
using System.Threading;

namespace RPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RPGgame : Microsoft.Xna.Framework.Game
    {
        //GRAPHICS stuff
        GraphicsDevice device;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch_BG, spriteBatch_H;
        Texture2D backgroundTexture, humanTexture; //for images
        Rectangle screenRectangle;
        int screenWidth, screenHeight;

        //INPUT stuff
        HumanController UserController;
        List<IController> Controllers;

        //GAME stuff
        Level testLevel;
        GameSave gameSave;
        Character UserCharacter;
        List<Character> Characters;


        //-------------------------------------------------------------

        public RPGgame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";  //Content Path
        }

        //-------------------------------------------------------------

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Window Resizeability
            graphics.PreferredBackBufferWidth = 1280; //PREFERRED WIDTH
            graphics.PreferredBackBufferHeight = 800; // PREFERRED HEIGHT
            graphics.IsFullScreen = true;  //CHANGE THIS
            graphics.ApplyChanges();
            Window.Title = "RHO";

            base.Initialize();
            UserController = new HumanController(); // ADDED

            Controllers = new List<IController>();
            Controllers.Add(UserController);

            //GameSave Tsst Objects;
            var bg_array = new List<Background>();
            bg_array.Add(new Background() { FilePath = @"C:\Stage0.png" });
            bg_array.Add(new Background() { FilePath = @"C:\Stage1.png" });
            bg_array.Add(new Background() { FilePath = @"C:\Stage2.png" });
            testLevel = new Level() { StageBackgrounds = bg_array };
            gameSave = new GameSave();

            Characters = new List<Character>();
            UserCharacter = new Character("Jesus", 10, 15, 20)
            {
                Controller = UserController,
                X = 400,
                Y = 50,
                Speed = 5
            };

            Characters.Add(UserCharacter);

            for (int i = 1; i <= 5; ++i)
            {
                var ai = new AIController(new EnemyAI(i * 20));
                var c = new Character("IPOO", 10 * i, 5 * i, 3 * i)
                {
                    Controller = ai,
                    X = i * 200,
                    Y = i * 50,
                    Speed = 3
                };

                ai.Self = c;
                ai.Enemy = UserCharacter;

                Controllers.Add(ai);
                Characters.Add(c);
            }

        }

        //-------------------------------------------------------------

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Player textures
            humanTexture = CreateRectangle(100, 200, Color.White);

            //Image textures
            backgroundTexture = Content.Load<Texture2D>("Stage1");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch_BG = new SpriteBatch(GraphicsDevice);
            spriteBatch_H = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            //backgroundTexture = Content.Load<Texture2D>("background");
            //foregroundTexture = Content.Load<Texture2D>("foreground");
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight); //Initialize WINDOW


            // TODO: use this.Content to load your game content here
        }

        //-------------------------------------------------------------

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        //-------------------------------------------------------------

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // ADD YOUR UPDATE LOGIC HERE
            foreach (var c in Controllers)
            {
                c.Update();
            }

            // Allows the game to exit
            if (UserController.CurrentState.IsKeyDown(Keys.Escape))
            {
                gameSave.SaveCharacter(UserCharacter);
                gameSave.SaveLevel(testLevel);
                this.Exit();
            }

            foreach (var c in Characters)
            {
                c.Move();
            }
            base.Update(gameTime);
        }

        //-------------------------------------------------------------

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            DrawScenery();

            foreach (var c in Characters)
            {
                DrawCharacter(c.Hitbox, spriteBatch_H, Color.LightBlue);
            }

            base.Draw(gameTime);
        }

        //-------------------------------------------------------------

        private Texture2D CreateRectangle(int width, int height, Color c)
        {
            Texture2D rectangleTexture = new Texture2D(GraphicsDevice, width, height, false, SurfaceFormat.Color);
            Color[] color = new Color[width * height];

            for (int i = 0; i < color.Length; ++i)
            {
                color[i] = new Color(c.R, c.G, c.B, 255);
            }

            rectangleTexture.SetData(color);//set the color data on the texture
            return rectangleTexture;
        }

        //-------------------------------------------------------------

        private void DrawScenery()
        {
            spriteBatch_BG.Begin();
            spriteBatch_BG.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch_BG.End();
        }

        //-------------------------------------------------------------

        private void DrawCharacter(Hitbox hit, SpriteBatch sb, Color color)
        {
            sb.Begin();
            sb.Draw(humanTexture, new Vector2(hit.X, hit.Y), color);
            sb.End();
        }

        //-------------------------------------------------------------
    }
}
