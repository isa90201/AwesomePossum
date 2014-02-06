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
        int prevMove; // ADDED
        Color backColor;
        Color upColor = Color.Orange,  //ADDED
            downColor = Color.LightCoral,
            leftColor = Color.Blue,
            rightColor = Color.LightCyan,
            attackColor = Color.Violet,
            pauseColor = Color.Gray,
            confirmColor = Color.Green,
            cancelColor = Color.Red;
        Party testParty;
        Level testLevel;
        GameSave gameSave;
        GameSaveXmlWriter xmlWriter;
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
            prevMove = 0;

            //GameSave TEst Objects
            testLevel = new Level();
            testLevel.Name = "The Ghetto";
            testLevel.LevelId = 5;

            Character testCharacter = new Character("Jesus", 10, 15, 20);
            Weapon testWeapon = new Weapon("Pimp Cane", 30);
            Armor testArmor = new Armor("Fur Coat", 5);
            Inventory testInventory = new Inventory();
            testInventory.EquippedWeapon = testWeapon;
            testInventory.EquippedArmor = testArmor;
            testParty = new Party(testCharacter, testInventory);
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
            //TEST GameSave (writing to file)
            gameSave = new GameSave(testParty, testLevel);
            // Allows the game to exit
            if (myController.CurrentState.IsKeyDown(Keys.Escape))
            {
                xmlWriter = new GameSaveXmlWriter(gameSave);
                this.Exit();
            }

            UpdateInput();

            base.Update(gameTime);
            /* //ORIGINAL
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
             * */
        }

        /*private int Move()
        {
            Random r = new Random();
            int i = r.Next(1, 5);

            if (enemyAI.IsMoving())
            {
                return i;
            }
            return 0;
        }*/

        private void UpdateInput()  //REMOVE METHOD; Key testing
        {
            /*int move = Move();

            if (move != 0)
            {
                if (move == 1)
                {
                    backColor = upColor;
                }
                else if (move == 2)
                {
                    backColor = downColor;
                }
                else if (move == 3)
                {
                    backColor = leftColor;
                }
                else if (move == 4)
                {
                    backColor = rightColor;
                }
            }
            else
                prevMove = move;*/

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
