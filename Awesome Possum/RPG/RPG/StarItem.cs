using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class StarItem : IItem
    {

        public Texture2D GetSprite()
        {
            return null;
        }

        public void DoEffect(Character c)
        {
            //TODO: figure out how to make character invincible
        }
    }
}
