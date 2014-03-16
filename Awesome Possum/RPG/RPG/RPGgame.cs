#define DEBUG_GAME //Uncomment this to debug game.

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
using System.IO;
using System.Text;

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
        SpriteBatch spriteBatch_BG, spriteBatch_H, spriteBatch_A, spriteBacth_SBG;
        Texture2D backgroundTexture; //for images
        Rectangle screenRectangle, sourceRectangle;
        int screenWidth, screenHeight, sourceWidth, sourceHeight;
        int WorldOffsetX;
        int MaxWorldOffsetX, MaxCx, WalkToleranceG;
        public SpriteCollection RHOSpriteSheet { get; set; }
        public SpriteCollection IPOOSpriteSheet { get; set; }
        public SpriteCollection OPOOSpriteSheet { get; set; }
        public SpriteCollection APOOSpriteSheet { get; set; }

        //SOUND stuff
        Song backgroundMusic;

        //INPUT stuff
        HumanController UserController;
        List<IController> Controllers;

        //GAME stuff
        World CurrentWorld;
        Level CurrentLevel;
        GameSave gameSave;
        Character UserCharacter;
        List<Character> Characters;
        List<Character> Enemies;
        Spawner EnemySpanwer;

        //Level Stuff
        //string World1_Path, World2_Path, World3_Path;
        int WorldNumber, LevelNumber;
        StringBuilder[] World_Paths;

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
            base.Initialize();

            // TODO: Add your initialization logic here

            //WINDOW Properties
            graphics.PreferredBackBufferWidth = 1280; //PREFERRED WIDTH =  1280
            graphics.PreferredBackBufferHeight = 800; // PREFERRED HEIGHT = 800

#if DEBUG_GAME
            graphics.IsFullScreen = false;
#else
            graphics.IsFullScreen = true;
#endif

            graphics.ApplyChanges();
            Window.Title = "RHO";

            UserController = new HumanController();

            Controllers = new List<IController>();
            Controllers.Add(UserController);

            //GAMESAVE Test Objects;
            gameSave = new GameSave();

            //CREATE human character
            Characters = new List<Character>();

            EnemySpanwer = new Spawner()
            {
                Difficulty = 2,
                Sprites = new List<SpriteCollection>() {
                    IPOOSpriteSheet,
                    OPOOSpriteSheet,
                    //APOOSpriteSheet
                  }
            };

            Enemies = new List<Character>();
            UserCharacter = new Character("RHO", 100000, 15)
            {
                Controller = UserController,
                X = 400,
                Y = 50,
                Speed = 5
            };
            MaxCx = CurrentLevel.BackgroundImage.Width - UserCharacter.Hitbox.W;

            Characters.Add(UserCharacter);
            UserCharacter.Sprites = RHOSpriteSheet;

            //Create AI controllers and respective characters
            for (int i = 1; i <= 12; ++i)
            {
                var c = EnemySpanwer.GetEnemy(CurrentLevel.BackgroundImage.Width, CurrentLevel.BackgroundImage.Height / 2);
                var ai = c.Controller as AIController;

                Controllers.Add(ai);
                Characters.Add(c);
                Enemies.Add(c);
                ai.Enemy = UserCharacter;
            }
        }

        //-------------------------------------------------------------

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //World & Level stuff
            World_Paths = new StringBuilder[] { new StringBuilder("C:\\Res\\Worlds\\World1.xml"), new StringBuilder("C:\\Res\\Worlds\\World2.xml"), new StringBuilder("C:\\Res\\Worlds\\World3.xml") };
            WorldNumber = 0;
            LevelNumber = 0;

            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch_BG = new SpriteBatch(GraphicsDevice);
            spriteBatch_H = new SpriteBatch(GraphicsDevice);
            spriteBatch_A = new SpriteBatch(GraphicsDevice); // ADDED
            spriteBacth_SBG = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            IPOOSpriteSheet = SpriteCollection.Load(@"C:\Res\Sprites\IPOO.xml");
            OPOOSpriteSheet = SpriteCollection.Load(@"C:\Res\Sprites\OPOO.xml");
            APOOSpriteSheet = SpriteCollection.Load(@"C:\Res\Sprites\APOO.xml");
            RHOSpriteSheet = SpriteCollection.Load(@"C:\Res\Sprites\RHO.xml");

            //LOAD Sprite sheet actions
            foreach (var ss in IPOOSpriteSheet.Actions)
                ss.Load(device);
            foreach (var ss in RHOSpriteSheet.Actions)
                ss.Load(device);
            foreach (var ss in OPOOSpriteSheet.Actions)
                ss.Load(device);
            foreach (var ss in APOOSpriteSheet.Actions)
                ss.Load(device);

            //Background Image and Screen Properties
            screenWidth = graphics.PreferredBackBufferWidth = 1280;
            screenHeight = graphics.PreferredBackBufferHeight = 800;
            sourceWidth = 6400;
            sourceHeight = 800;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight); //Screen Dimensions
            sourceRectangle = new Rectangle(0, 0, sourceWidth, sourceHeight); //BG dimesnions

            //use strings above to change worlds.
            CurrentWorld = World.Load(World_Paths[WorldNumber].ToString());

            CurrentLevel = CurrentWorld.Levels.ElementAt(LevelNumber);
            //CurrentLevel = CurrentWorld.Levels.First();  ORIGINAL LINE

            backgroundTexture = CurrentLevel.BackgroundImage.GetTexture2D(device);

            MaxWorldOffsetX = CurrentLevel.BackgroundImage.Width - screenRectangle.Width;

            WalkToleranceG = screenRectangle.Width / 4;

            //Music Player
            backgroundMusic = CurrentLevel.Music.GetSong();
            MediaPlayer.Play(backgroundMusic);

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
            //UPDATE controller input(s)
            foreach (var c in Controllers)
            {
                c.Update();
            }

            // Allows the game to exit
            if (UserController.CurrentState.IsKeyDown(Keys.Escape))
            {
                gameSave.SaveCharacter(UserCharacter);
                gameSave.SaveLevel(CurrentLevel);
                this.Exit();
            }

            //Change Levels
            if (UserController.CurrentState.IsKeyDown(Keys.Space)) //DEBUG
            {
                GoToNextLevel();
            }

            //UPDATE character position(s)
            foreach (var c in Characters)
            {
                c.Move();

                if (c.X > CurrentLevel.BackgroundImage.Width)
                    c.X = CurrentLevel.BackgroundImage.Width;
                if (c.X < 0)
                    c.X = 0;

                if (c.Y > CurrentLevel.BackgroundImage.Height)
                    c.Y = CurrentLevel.BackgroundImage.Height;
                if (c.Y < CurrentLevel.BackgroundImage.Height / 2)
                    c.Y = CurrentLevel.BackgroundImage.Height / 2;

                var sprite = c.GetAnimatedSprite();
                if (sprite != null)
                    sprite.HandleSpriteMovement(gameTime);
            }

            //UPDATE Scrolling stuff

            //Character movement
            if (UserCharacter.X < (WorldOffsetX + WalkToleranceG))
                WorldOffsetX = UserCharacter.X - WalkToleranceG;
            else if (UserCharacter.X > (WorldOffsetX + 3 * WalkToleranceG))
                WorldOffsetX = UserCharacter.X - (3 * WalkToleranceG);

            //Background Bounds
            if (WorldOffsetX < 0)
                WorldOffsetX = 0;
            else if (WorldOffsetX > CurrentLevel.BackgroundImage.Width - screenRectangle.Width)
                WorldOffsetX = CurrentLevel.BackgroundImage.Width - screenRectangle.Width;

            //Attack stuff
            foreach (var c in Enemies)
            {
                var enemyAttackBox = c.GetAttackBox();

                if (!Hitbox.IsNullOrEmpty(enemyAttackBox))
                {
                    if (UserCharacter.IsHit(enemyAttackBox))
                    {
                        UserCharacter.TakeDamage(c);
                    }
                }
            }

            //So that enemies don't hurt each other
            var playerAttackbox = UserCharacter.GetAttackBox();

            if (!Hitbox.IsNullOrEmpty(playerAttackbox))
            {
                var hit = Enemies.Where(o => o.IsHit(playerAttackbox));

                foreach (var hitc in hit)
                {
                    hitc.TakeDamage(UserCharacter);
                }
            }

            Characters.RemoveAll(e => !e.IsAlive);
            Enemies.RemoveAll(e => !e.IsAlive);

            base.Update(gameTime);
        }

        //-------------------------------------------------------------

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //DrawScenery();
            DrawScrollingBackground();

            foreach (var c in Characters.OrderBy(x => x.Y))
            {
                var sprite = c.GetAnimatedSprite();
                if (sprite != null)
                {
                    sprite.Draw(spriteBatch_H, WorldOffsetX);
                }
            }

            base.Draw(gameTime);
        }

        //-------------------------------------------------------------

        private void DrawScrollingBackground()
        {
            spriteBatch_BG.Begin();
            spriteBatch_BG.Draw(backgroundTexture, new Rectangle(sourceRectangle.X - WorldOffsetX, sourceRectangle.Y, sourceWidth, sourceHeight), Color.White);
            spriteBatch_BG.End();
        }

        //-------------------------------------------------------------

        private void GoToNextLevel()
        {
            ++LevelNumber;

            if (WorldNumber < 3)
            {
                if (LevelNumber >= 3)
                {
                    LevelNumber = 0;
                    GoToNextWorld();
                }
                else
                {
                    CurrentLevel = CurrentWorld.Levels.ElementAt(LevelNumber);
                    backgroundTexture = CurrentLevel.BackgroundImage.GetTexture2D(device);
                    backgroundMusic = CurrentLevel.Music.GetSong();
                    MediaPlayer.Stop();
                    MediaPlayer.Play(backgroundMusic);
                }
            }
        }

        //-------------------------------------------------------------

        private void GoToNextWorld()
        {
            ++WorldNumber;

            if (WorldNumber < 3)
            {
                string path = World_Paths[WorldNumber].ToString();
                CurrentWorld = World.Load(path);
                CurrentLevel = CurrentWorld.Levels.ElementAt(LevelNumber);
                backgroundMusic = CurrentLevel.Music.GetSong();
                backgroundTexture = CurrentLevel.BackgroundImage.GetTexture2D(device);
                MediaPlayer.Stop();
                MediaPlayer.Play(backgroundMusic);
            }
        }

        //-------------------------------------------------------------

        private Vector2 GetSpawnLocation()  //SPAWN logic
        {
            Random RandomNumber = new Random();
            return new Vector2(RandomNumber.Next(CurrentLevel.BackgroundImage.Width) + 1, RandomNumber.Next(CurrentLevel.BackgroundImage.Height) + 1);
        }

        //-------------------------------------------------------------

        private void SpawnCharacter()
        {

            // TODO
            /*
             * 1) Get Spawn Location.
             * 2) Create new Character.
             * 3) Add to Characters List. (Will be drawn to screen now.)
             */
        }

    }
}