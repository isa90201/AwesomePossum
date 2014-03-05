using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace RPG
{
    class StarItem : IItem, IDrawable
    {
        public Texture2D StarTexture { get; set; }
        public Vector2 StarVector { get; set; }
        public float EffectTime { get; set; }

        public Texture2D GetSprite()
        {
            return null;
            //return Texture2D.FromStream(g, File.OpenRead(FilePath));
        }

        public void DoEffect(Character c)
        {
            //TODO: figure out how to make character invincible
            c.Hitbox = null;
        }

        public AnimatedSprite GetAnimatedSprite()
        {
            return new AnimatedSprite(StarTexture, StarTexture.Width, StarTexture.Height);
        }

        public Vector2 GetVector2D()
        {
            return StarVector;
        }
    }
}
