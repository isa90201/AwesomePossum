using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace RPG
{
    public class AnimatedSprite
    {
        float Timer = 0f;  //Time required for sprite to move to the next frame.
        float Interval = 50f; //Used to determine how often to step to next frame in the animation.
        int CurrentFrame = 0;  //Keep track of current frame.
        public int SpriteWidth;
        public int SpriteHeight;

        public Texture2D SpriteTexture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public int Version { get; set; }

        public Rectangle SourceRect { get; set; }

        public AnimatedSprite(Texture2D texture, int spriteWidth, int spriteHeight)
        {
            SpriteTexture = texture;
            SpriteWidth = spriteWidth;
            SpriteHeight = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            SourceRect = new Rectangle(CurrentFrame * SpriteWidth, Version * SpriteHeight, SpriteWidth, SpriteHeight);
            Origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Timer > Interval)
            {
                CurrentFrame++;

                if (!(CurrentFrame < SpriteTexture.Width / SpriteWidth))
                {
                    CurrentFrame = 0;
                }
                Timer = 0f;
            }

        }

        public void Draw(SpriteBatch sb, int worldOffset)
        {
            sb.Begin();
            sb.Draw(SpriteTexture, new Vector2(Position.X - worldOffset, Position.Y), SourceRect, Color.White, 0f, Origin, 1.0f, SpriteEffects.None, 0);
            sb.End();
        }
    }
}
