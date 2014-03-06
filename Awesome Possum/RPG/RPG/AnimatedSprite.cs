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
        int CurrentFrame = 0;  //Keep track of current frame.

        public float Interval { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int XOffset { get; set; }
        public int YOffset { get; set; }

        public Texture2D Texture { get; set; }

        public int Version { get; set; }

        public AnimatedSprite(Texture2D texture, int spriteWidth, int spriteHeight)
        {
            Texture = texture;
            Width = spriteWidth;
            Height = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Timer > Interval)
            {
                CurrentFrame++;

                if (!(CurrentFrame < Texture.Width / Width))
                {
                    CurrentFrame = 0;
                }
                Timer = 0f;
            }
        }

        public void Draw(SpriteBatch sb, int worldOffset)
        {
            sb.Begin();
            sb.Draw(Texture, new Rectangle(X - worldOffset - XOffset, Y - YOffset, Width, Height), new Rectangle(CurrentFrame * Width, Version * Height, Width, Height), Color.White);
            sb.End();
        }
    }
}
