using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG
{
    class HeartItem : IItem, IDrawable
    {
        public Texture2D HeartTexture { get; set; }
        public Vector2 HeartVector { get; set; }

        public Texture2D GetSprite()
        {
            //TODO
            return null;
        }

        public void DoEffect(Character c)
        {
            c.CurrentHP += 50;
        }

        public AnimatedSprite GetAnimatedSprite()
        {
            return new AnimatedSprite(HeartTexture, HeartTexture.Width, HeartTexture.Height);
        }

        public Vector2 GetVector2D()
        {
            return HeartVector;
        }
    }
}
