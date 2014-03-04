using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public interface IItem
    {
        Texture2D GetSprite();
        void DoEffect(Character c);
    }
}