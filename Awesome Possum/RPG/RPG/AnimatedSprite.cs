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
        Texture2D spriteTexture;
        float timer = 0f;  //Time required for sprite to move to the next frame.
        float interval = 50f; //Used to determine how often to step to next frame in the animation.
        int currentFrame = 0;  //Keep track of current frame.
        public int spriteWidth = 100; //= 32; MODIFIED   //remove public
        public int spriteHeight = 200; //= 48; MODIFIED  //remove public

        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return spriteTexture;
            }
            set
            {
                spriteTexture = value;
            }
        }

        public Rectangle SourceRect
        {
            get
            {
                return sourceRect;
            }
            set
            {
                sourceRect = value;
            }
        } // the rectangle in which our sprite will be drawn

        public AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (!(currentFrame < Texture.Width / spriteWidth))
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }

        }
    }
}
