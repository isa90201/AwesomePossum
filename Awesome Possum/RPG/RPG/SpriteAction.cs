using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using System.Xml.Serialization;

namespace RPG
{
    public class SpriteAction
    {
        public enum States
        {
            IDLE,
            WALKING,
            ATTACKING,
            DYING,
            HURT
        }

        public int Id { get; set; }
        public States Name { get; set; }
        public string FilePath { get; set; }
        public int NumFrames { get; set; }
        public int FrameDelay { get; set; }

        [XmlIgnoreAttribute]
        public Texture2D SpriteTexture { get; set; }

        public int HitWidth { get; set; }
        public int HitHeight { get; set; }

        public int AtkWidth { get; set; }
        public int AtkHeight { get; set; }

        public int ImgLDx { get; set; }
        public int ImgLDy { get; set; }
        public int ImgRDx { get; set; }
        public int ImgRDy { get; set; }

        public int HitLDx { get; set; }
        public int HitLDy { get; set; }
        public int HitRDx { get; set; }
        public int HitRDy { get; set; }

        public int AtkLDx { get; set; }
        public int AtkLDy { get; set; }
        public int AtkRDx { get; set; }
        public int AtkRDy { get; set; }

        public AnimatedSprite GetAnimatedSprite(Character.Directions direction)
        {
            var animation = new AnimatedSprite(SpriteTexture, SpriteTexture.Width / NumFrames, SpriteTexture.Height / 2);

            if (direction == Character.Directions.Right)
            {
                animation.XOffset = ImgRDx;
                animation.YOffset = ImgRDy;
                animation.Version = 0;
            }
            else
            {
                animation.XOffset = ImgLDx;
                animation.YOffset = ImgLDy;
                animation.Version = 1;
            }

            animation.Interval = FrameDelay;

            return animation;
        }

        public void Load(GraphicsDevice gd)
        {
            SpriteTexture = Texture2D.FromStream(gd, File.OpenRead(FilePath));
        }

        public Hitbox GetAttackBox(int x, int y, Character.Directions direction)
        {
            if (direction == Character.Directions.Left)
                return new Hitbox() { X = x - AtkLDx, Y = y + AtkLDy, W = AtkWidth, H = AtkHeight };
            else
                return new Hitbox() { X = x - AtkRDx, Y = y + AtkRDy, W = AtkWidth, H = AtkHeight };
        }

        public Hitbox GetHitbox(int x, int y, Character.Directions direction)
        {
            if (direction == Character.Directions.Left)
                return new Hitbox() { X = x - HitLDx, Y = y + HitLDy, W = HitWidth, H = HitHeight };
            else
                return new Hitbox() { X = x - HitRDx, Y = y + HitRDy, W = HitWidth, H = HitHeight };
        }
    }
}
