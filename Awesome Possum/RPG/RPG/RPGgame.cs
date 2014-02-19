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
        //MOVE units
        const int MOVE_X = 5;
        const int MOVE_Y = 5;

        //GRAPHICS stuff
        GraphicsDevice device;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch_BG, spriteBatch_H, spriteBatch_AI;
        Texture2D backgroundTexture, humanTexture, aiTexture; //for images
        Texture2D upTexture, downTexture, leftTexture, rightTexture, attackTexture, collisonTexture;
        Rectangle screenRectangle;
        Vector2 H_position, AI_position;
        int screenWidth, screenHeight;

        //INPUT stuff
        KeyboardState oldState;
        HumanController myController;

        //COLORS
        Color fillColor;
        Color upColor = Color.LightBlue,
            downColor = Color.Green,
            leftColor = Color.Orange,
            rightColor = Color.Yellow,
            attackColor = Color.Red,
            jumpColor = Color.Violet,
            collisionColor = Color.Magenta,
            idleColor = Color.White;

        //GAME stuff
        EnemyAI enemyAI;
        Level testLevel;
        GameSave gameSave;
        Character testCharacter;


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
            myController = new HumanController(); // ADDED
            oldState = Keyboard.GetState(); //REMOVE
            enemyAI = new EnemyAI(1); //ADDED


            //GameSave Tsst Objects;
            var bg_array = new List<Background>();
            bg_array.Add(new Background() { FilePath = @"C:\Stage0.png" });
            bg_array.Add(new Background() { FilePath = @"C:\Stage1.png" });
            bg_array.Add(new Background() { FilePath = @"C:\Stage2.png" });
            testLevel = new Level() { StageBackgrounds = bg_array };
            gameSave = new GameSave();

            testCharacter = new Character("Jesus", 10, 15, 20);
            H_position = new Vector2(50, 400);
            AI_position = new Vector2(1000, 400);
        }

        //-------------------------------------------------------------

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            backgroundTexture = Content.Load<Texture2D>("Stage1");
            humanTexture = CreateRectangle(100, 200, idleColor);
            aiTexture = CreateRectangle(100, 200, idleColor);
            upTexture = CreateRectangle(100, 200, upColor);
            downTexture = CreateRectangle(100, 200, downColor);
            leftTexture = CreateRectangle(100, 200, leftColor);
            rightTexture = CreateRectangle(100, 200, rightColor);
            attackTexture = CreateRectangle(100, 200, attackColor);
            collisonTexture = CreateRectangle(100, 200, collisionColor);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch_BG = new SpriteBatch(GraphicsDevice);
            spriteBatch_H = new SpriteBatch(GraphicsDevice);
            spriteBatch_AI = new SpriteBatch(GraphicsDevice);
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

            // Allows the game to exit
            if (myController.CurrentState.IsKeyDown(Keys.Escape))
            {
                gameSave.SaveCharacter(testCharacter);
                gameSave.SaveLevel(testLevel);
                this.Exit();
            }

            UpdateHumanInput();
            base.Update(gameTime);
        }

        //-------------------------------------------------------------

        private void UpdateHumanInput()  //INPUT check
        {
            myController.GetInput();


            if (myController.UpIsPressed() && !myController.DownIsPressed()) // UP combos
            {
                fillColor = upColor;
                MoveVertical(-MOVE_Y, H_position);

                if (myController.LeftIsPressed() && !myController.RightIsPressed())
                {
                    MoveHorizontal(-MOVE_X, H_position);
                }
                else if (myController.RightIsPressed() && !myController.LeftIsPressed())
                {
                    MoveHorizontal(MOVE_X, H_position);
                }
            }
            else if (myController.DownIsPressed() && !myController.UpIsPressed()) // DOWN combos
            {
                fillColor = downColor;
                MoveVertical(MOVE_Y, H_position);

                if (myController.LeftIsPressed() && !myController.RightIsPressed())
                {
                    MoveHorizontal(-MOVE_X, H_position);
                }
                else if (myController.RightIsPressed() && !myController.LeftIsPressed())
                {
                    MoveHorizontal(MOVE_X, H_position);
                }
            }
            else if (myController.LeftIsPressed() && !myController.RightIsPressed())
            {
                fillColor = leftColor;
                MoveHorizontal(-MOVE_X, H_position);
            }
            else if (myController.RightIsPressed() && !myController.LeftIsPressed())
            {
                fillColor = rightColor;
                MoveHorizontal(MOVE_X, H_position);
            }
            else if (myController.AttackIsPressed())
            {
                fillColor = attackColor;
            }
            else if (myController.JumpIsPressed())
            {
                fillColor = jumpColor;
            }
        }

        //-------------------------------------------------------------

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(idleColor); //Clear screen to color of your choice

            DrawScenery();
            DrawCharacter(humanTexture, H_position, spriteBatch_H);
            DrawCharacter(aiTexture, AI_position, spriteBatch_AI);

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

        private void DrawScenery() //ADDED
        {
            spriteBatch_BG.Begin();
            spriteBatch_BG.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch_BG.End();
        }

        //-------------------------------------------------------------

        private void DrawCharacter(Texture2D characterTexture, Vector2 position, SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(characterTexture, position, fillColor);
            sb.End();
        }

        //-------------------------------------------------------------

        private void MoveHorizontal(int x, Vector2 position)
        {
            position.X += x;
        }

        //-------------------------------------------------------------

        private void MoveVertical(int y, Vector2 position)
        {
            position.Y += y;
        }

        //-------------------------------------------------------------
    }
}
