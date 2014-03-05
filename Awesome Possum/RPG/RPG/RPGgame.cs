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
            graphics.IsFullScreen = true;  //CHANGE THIS
            graphics.ApplyChanges();
            Window.Title = "RHO";

            UserController = new HumanController();

            Controllers = new List<IController>();
            Controllers.Add(UserController);

            //GAMESAVE Test Objects;
            gameSave = new GameSave();

            //CREATE human character
            Characters = new List<Character>();
            UserCharacter = new Character("Jesus", 10, 15, 20)
            {
                Controller = UserController,
                X = 400,
                Y = 50,
                Speed = 5
            };
            MaxCx = CurrentLevel.BackgroundImage.Width - UserCharacter.Hitbox.W; //

            Characters.Add(UserCharacter);

            //Create AI controllers and respective characters
            for (int i = 1; i <= 5; ++i)
            {
                var ai = new AIController(new EnemyAI(i * 20));
                var c = new Character("IPOO", 10 * i, 5 * i, 3 * i)
                {
                    Controller = ai,
                    X = i * 200,
                    Y = i * 50,
                    Speed = 1
                };

                ai.Self = c;
                ai.Enemy = UserCharacter;

                Controllers.Add(ai);
                Characters.Add(c);
            }
            foreach (var c in Characters)
                c.Sprites = CharacterSpriteSheet;

        }

        //-------------------------------------------------------------

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch_BG = new SpriteBatch(GraphicsDevice);
            spriteBatch_H = new SpriteBatch(GraphicsDevice);
            spriteBatch_A = new SpriteBatch(GraphicsDevice); // ADDED
            spriteBacth_SBG = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            CharacterSpriteSheet = SpriteCollection.Load(@"C:\Res\Rho.xml");

            foreach (var ss in CharacterSpriteSheet.Actions)
                ss.Load(device);

            //Background Image and Screen Properties
            screenWidth = graphics.PreferredBackBufferWidth = 1280;
            screenHeight = graphics.PreferredBackBufferHeight = 800;
            sourceWidth = 6400;
            sourceHeight = 800;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight); //Screen Dimensions
            sourceRectangle = new Rectangle(0, 0, sourceWidth, sourceHeight); //BG dimesnions

            //Image textures
            CurrentWorld = World.Load(@"C:\Users\Isaias\Desktop\TestFolder1\TwerkCity.xml");
            CurrentLevel = CurrentWorld.Levels.First();
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

        private Vector2 GetSpawnLocation()  //SPAWN logic
        {
            Random RandomNumber = new Random();
            return new Vector2(RandomNumber.Next(CurrentLevel.BackgroundImage.Width) + 1, RandomNumber.Next(CurrentLevel.BackgroundImage.Height) + 1);
        }

        //-------------------------------------------------------------



        public SpriteCollection CharacterSpriteSheet { get; set; }
    }
}