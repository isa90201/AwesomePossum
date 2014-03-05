using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG
{
    public interface IDrawable
    {
        AnimatedSprite GetAnimatedSprite();
        Vector2 GetVector2D();
    }
}
