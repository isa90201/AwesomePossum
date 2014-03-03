using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class SpriteAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int NumFrames { get; set; }
        public int FrameDelay { get; set; }

        public int HitWidth { get; set; }
        public int HitHeight { get; set; }

        public int ImgLDx { get; set; }
        public int ImgLDy { get; set; }
        public int ImgRDx { get; set; }
        public int ImgRDy { get; set; }

        public int HitLDx { get; set; }
        public int HitLDy { get; set; }
        public int HitRDx { get; set; }
        public int HitRDy { get; set; }
    }
}
