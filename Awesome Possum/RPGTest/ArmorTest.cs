using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTest
{
    [TestClass]
    public class ArmorTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var a = new Armor("Shoes", 10);

            Assert.AreEqual("Shoes", a.Name, "Name was not set properly");
            Assert.AreEqual(10, a.Defense, "Defense was not set properly");
        }

        [TestMethod]
        public void TestName()
        {
            var a = new Armor("Shoes", 10);

            a.Name = "Stiletto";
            Assert.AreEqual("Stiletto", a.Name, "Name was not set properly");
            a.Name = "";
            Assert.AreEqual("UNKNOWN", a.Name, "Empty string name was not handled properly");
        }

        [TestMethod]
        public void TestDefense()
        {
            var a = new Armor("Shoes", 10);

            a.Defense = -10;
            Assert.AreEqual(1, a.Defense, "Defense was not set to minimum");
            a.Defense = 50;
            Assert.AreEqual(50, a.Defense, "Defense was not set properly");
            a.Defense = 999;
            Assert.AreEqual(100, a.Defense, "Defense was not set to max");
        }

        [TestMethod]
        public void TestDefenseUp()
        {
            var a = new Armor("Shoes", 10);

            a.Defense -= 99;
            Assert.AreEqual(1, a.Defense, "Defense was not set to minimum");
            a.Defense += 75;
            Assert.AreEqual(76, a.Defense, "Defense was not set properly");
            a.Defense += 999;
            Assert.AreEqual(100, a.Defense, "Defense was not set to max");
        }
    }
}
