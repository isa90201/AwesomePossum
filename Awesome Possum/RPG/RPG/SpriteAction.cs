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

        public AnimatedSprite GetAnimatedSprite(Character.Directions direction, int x, int y)
        {
            Vector2 offset,
                position = new Vector2(x, y);

            int version;

            if (direction == Character.Directions.Right)
            {
                offset = new Vector2(ImgRDx, ImgRDy);
                version = 0;
            }
            else
            {
                offset = new Vector2(ImgLDx, ImgLDy);
                version = 1;
            }

            var animation = new AnimatedSprite(SpriteTexture, SpriteTexture.Width / NumFrames, SpriteTexture.Height / 2);
            animation.Position = position;
            animation.Origin = offset;
            animation.Version = version;

            return animation;
        }

        public void Load(GraphicsDevice gd)
        {
            SpriteTexture = Texture2D.FromStream(gd, File.OpenRead(FilePath));
        }
    }
}
