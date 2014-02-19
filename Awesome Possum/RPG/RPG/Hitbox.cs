using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Hitbox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        public bool Overlap(Hitbox other)
        {
            return OverlapSide(X, W, other.X, other.W) && OverlapSide(Y, H, other.Y, other.H);
        }

        private bool OverlapSide(int x1, int w1, int x2, int w2)
        {
            return (x1 > x2 && x1 < x2 + w2) || (x1 + w1 > x2 && x1 + w1 < x2 + w2);
        }
    }
}
