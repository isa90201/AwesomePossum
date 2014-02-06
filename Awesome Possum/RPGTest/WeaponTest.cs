using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTest
{
    [TestClass]
    public class WeaponTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var w = new Weapon("Excaliber", 25);

            Assert.AreEqual("Excaliber", w.Name, "Name was not set properly");
            Assert.AreEqual(25, w.Attack, "Attack was not set properly");
        }

        [TestMethod]
        public void TestName()
        {
            var w = new Weapon("Excaliber", 25);

            w.Name = "Doritos";
            Assert.AreEqual("Doritos", w.Name, "Name was not set properly");
            w.Name = "";
            Assert.AreEqual("UNKNOWN", w.Name, "Empty string name was not handled properly");
        }

        [TestMethod]
        public void TestAttack()
        {
            var w = new Weapon("Excaliber", 25);

            w.Attack = -10;
            Assert.AreEqual(1, w.Attack, "Attack not set to minimum");
            w.Attack = 10;
            Assert.AreEqual(10, w.Attack, "Attack not set properly");
            w.Attack = 101;
            Assert.AreEqual(100, w.Attack, "Attack not set to max");
        }

        [TestMethod]
        public void TestAttackUp()
        {
            var w = new Weapon("Excaliber", 25);

            w.Attack -= 100;
            Assert.AreEqual(1, w.Attack, "Attack not set to minimum");
            w.Attack += 10;
            Assert.AreEqual(11, w.Attack, "Attack not set properly");
            w.Attack += 200;
            Assert.AreEqual(100, w.Attack, "Attack not set to max");
        }
    }
}
