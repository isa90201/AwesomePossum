using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTest
{
    [TestClass]
    public class HumanPlayerTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var h = new HumanPlayer("Isa", 100, 10, 10);

            Assert.AreEqual(0, h.Experience, "Experience not set to minimum");
            Assert.AreEqual(1, h.Level, "Level not set to minimum");
        }

        [TestMethod]
        public void TestGainExperience()
        {
            var h = new HumanPlayer("Isa", 100, 10, 10);

            h.GainExperience(-10);
            Assert.AreEqual(0, h.Experience, "Experience not set to minimum");
            h.GainExperience(10);
            Assert.AreEqual(10, h.Experience, "Level not set properly");
            h.GainExperience(1000);
            Assert.AreEqual(100, h.Experience, "Level not set to maximum");
        }

        [TestMethod]
        public void TestLevelUp()
        {
            var h = new HumanPlayer("Isa", 100, 10, 10);

            h.LevelUp(-1);
            Assert.AreEqual(1, h.Level, "Level not set to minimum");
            h.LevelUp(49);
            Assert.AreEqual(50, h.Level, "Level not set properly");
            h.LevelUp(100);
            Assert.AreEqual(100, h.Level, "Level not set to max");
        }
    }
}
