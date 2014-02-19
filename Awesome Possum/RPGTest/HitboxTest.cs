using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTest
{
    [TestClass]
    public class HitboxTest
    {
        [TestMethod]
        public void TestX()
        {
            Hitbox r = new Hitbox() { X = 0, Y = 1, W = 2, H = 3 };
            Assert.AreEqual(0, r.X, "X is not set properly.");
        }

        [TestMethod]
        public void TestY()
        {
            Hitbox r = new Hitbox() { X = 0, Y = 1, W = 2, H = 3 };
            Assert.AreEqual(1, r.Y, "Y is not set properly.");
        }

        [TestMethod]
        public void TestW()
        {
            Hitbox r = new Hitbox() { X = 0, Y = 1, W = 2, H = 3 };
            Assert.AreEqual(2, r.W, "W is not set properly.");
        }

        [TestMethod]
        public void TestH()
        {
            Hitbox r = new Hitbox() { X = 0, Y = 1, W = 2, H = 3 };
            Assert.AreEqual(3, r.H, "H is not set properly.");
        }

        [TestMethod]
        public void TestOverlap()
        {
            // NO OVERLAP
            Hitbox r = new Hitbox() { X = 0, Y = 2, W = 2, H = 2 };
            Hitbox s = new Hitbox() { X = 5, Y = 5, W = 1, H = 1 };

            Assert.IsFalse(r.Overlap(s));

            // OVERLAP
            s = new Hitbox() { X = 0, Y = 3, W = 3, H = 3 };
            Assert.IsTrue(r.Overlap(s));
        }
    }
}
