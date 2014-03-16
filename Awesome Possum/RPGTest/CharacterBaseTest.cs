using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTest
{
    [TestClass]
    public class CharacterBaseTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var c = new Character("Jesus", 70, 60);

            Assert.AreEqual("Jesus", c.Name, "Expected name is not set");
            Assert.AreEqual(70, c.TotalHP, "Total HP is not set");
            Assert.AreEqual(70, c.CurrentHP, "Current HP is not set to max");
            Assert.AreEqual(60, c.Attack, "Attack is not set properly");
        }

        [TestMethod]
        public void TestDamage()  //Also tests CurrentHP
        {
            var c = new Character("Jesus", 70, 60);

            c.CurrentHP -= 20;  // 1st hit
            Assert.AreEqual(50, c.CurrentHP, "Damage is not applied properly");
            c.CurrentHP -= 50; // 2nd hit
            Assert.AreEqual(0, c.CurrentHP, "Damage is not applied properly");

            c.CurrentHP -= 50; // 3rd hit
            Assert.AreEqual(0, c.CurrentHP, "Damage is not applied properly");

            c.CurrentHP += 25; // Recover Haalth
            Assert.AreEqual(25, c.CurrentHP, "Damage is not applied properly");
        }

        [TestMethod]
        public void TestAttack()
        {
            var c = new Character("Jesus", 70, 60);

            c.Attack = -10; //
            Assert.AreEqual(1, c.Attack, "Attack is not set to minimum");

            c.Attack = 10;
            Assert.AreEqual(10, c.Attack, "Attack is not set properly");

            c.Attack = 101;
            Assert.AreEqual(100, c.Attack, "Attack is not set max");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestName()
        {
            var c = new Character("Jesus", 70, 60);

            Assert.AreEqual("Jesus", c.Name, "Name is not set properly");

            c.Name = "";
            Assert.AreEqual("", c.Name, "No valid name was provided.");
        }

        [TestMethod]
        public void TestTotalHP()
        {
            var c = new Character("Jesus", 70, 60);

            c.TotalHP = -10; //
            Assert.AreEqual(1, c.TotalHP, "Total HP is not set to minimum");

            c.TotalHP = 10;
            Assert.AreEqual(10, c.TotalHP, "Total HP is not set properly");

            c.TotalHP = 101;
            Assert.AreEqual(100, c.TotalHP, "Total HP is not set to max");
        }


        [TestMethod]
        public void TestLevel()
        {
            var c = new Character("Jesus", 70, 60);

            c.Experience = -10; //
            Assert.AreEqual(1, c.Level, "Level is not set to minimum");

            c.Experience = 10;
            Assert.AreEqual(1, c.Level, "Level is not set properly");

            c.Experience += 90;
            Assert.AreEqual(2, c.Level, "Level is not set properly");
        }

        [TestMethod]
        public void TestExperience()
        {
            var c = new Character("Jesus", 70, 60);

            c.Experience = -10; //
            Assert.AreEqual(0, c.Experience, "Attack is not set to minimum");

            c.Experience = 10;
            Assert.AreEqual(10, c.Experience, "Attack is not set properly");

            c.Experience = 101;
            Assert.AreEqual(1, c.Experience, "Attack is not set max");
        }

    }
}
