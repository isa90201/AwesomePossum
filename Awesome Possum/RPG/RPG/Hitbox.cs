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
            if (Hitbox.IsNullOrEmpty(other))
                return false;

            return OverlapSide(X, W, other.X, other.W) && OverlapSide(Y, H, other.Y, other.H);
        }

        private bool OverlapSide(int x1_1, int w1, int x2_1, int w2)
        {
            var x1_2 = x1_1 + w1;
            var x2_2 = x2_1 + w2;

            var notOVerlap = (x1_1 < x2_1 && x1_1 < x2_2 && x1_2 < x2_1 && x1_2 < x2_2) ||
                             (x1_1 > x2_1 && x1_1 > x2_2 && x1_2 > x2_1 && x1_2 > x2_2);

            return !notOVerlap;
        }

        public static bool IsNullOrEmpty(Hitbox ret)
        {
            return ret == null || ret.W == 0 || ret.H == 0;
        }
    }
}
