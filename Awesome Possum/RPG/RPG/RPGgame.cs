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
        GraphicsDeviceManager graphics;
        private HumanController myController; //remove private
        private EnemyAI enemyAI; // remove private
        KeyboardState oldState;
        Color backColor;
        Color upColor = Color.Orange,  //ADDED
            downColor = Color.LightCoral,
            leftColor = Color.Blue,
            rightColor = Color.LightCyan,
            attackColor = Color.Violet,
            pauseColor = Color.Gray,
            confirmColor = Color.Green,
            cancelColor = Color.Red;
        Level testLevel;
        GameSave gameSave;
        Character testCharacter;
        /*GraphicsDeviceManager graphics;  // ORIGINAL
        SpriteBatch spriteBatch;*/

        public RPGgame()
        {
            graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";  //ORIGINAL

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            myController = new HumanController(); // ADDED
            oldState = Keyboard.GetState(); //REMOVE
            enemyAI = new EnemyAI(1); //ADDED
            //prevMove = 0;

            //GameSave TEst Objects
            Background bg0 = new Background("Stage0", "C:\\Stage0.png");
            Background bg1 = new Background("Stage1", "C:\\Stage1.png");
            Background bg2 = new Background("Stage2", "C:\\Stage2.png");
            Background[] bg_array = new Background[3];
            bg_array[0] = bg0;
            bg_array[1] = bg1;
            bg_array[2] = bg2;
            testLevel = new Level(1, "Jungle", bg_array);
            gameSave = new GameSave();

            testCharacter = new Character("Jesus", 10, 15, 20);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            /*
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
             */
            //ORIGINAL
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Add your update logic here
            //TEST GameSave (writing to file)

            // Allows the game to exit
            if (myController.CurrentState.IsKeyDown(Keys.Escape))
            {
                gameSave.SaveCharacter(testCharacter);
                gameSave.SaveLevel(testLevel);
                this.Exit();
            }

            UpdateInput();
            base.Update(gameTime);
        }


        private void UpdateInput()  //REMOVE METHOD; Key testing
        {
            myController.GetInput();


            if (myController.UpIsPressed())
            {
                backColor = upColor;
            }
            else if (myController.DownIsPressed())
            {
                backColor = downColor;
            }
            else if (myController.LeftIsPressed())
            {
                backColor = leftColor;
            }
            else if (myController.RightIsPressed())
            {
                backColor = rightColor;
            }
            else if (myController.AttackIsPressed())
            {
                backColor = attackColor;
            }
            else if (myController.DownIsPressed())
            {
                backColor = downColor;
            }
            else if (myController.PauseIsPressed())
            {
                backColor = pauseColor;
            }
            else if (myController.ConfirmIsPressed())
            {
                backColor = confirmColor;
            }
            else if (myController.CancelIsPressed())
            {
                backColor = cancelColor;
            }
        }
        //oldState = myController.CurrentState;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(backColor);
            base.Draw(gameTime);
            //Thread.Sleep(500);
            /*
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
             * */
        }
    }
}
