﻿using System;
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
            var c = new CharacterBase("Jesus", 70, 60, 50);

            Assert.AreEqual("Jesus", c.Name, "Expected name is not set");
            Assert.AreEqual(70, c.TotalHP, "Total HP is not set");
            Assert.AreEqual(70, c.CurrentHP, "Current HP is not set to max");
            Assert.AreEqual(60, c.Attack, "Attack is not set properly");
            Assert.AreEqual(50, c.Defense, "Defense is not set properly");
            Assert.IsTrue(c.IsAlive, "New character is dead");
        }

        [TestMethod]
        public void TestDamage()  //Also tests CurrentHP
        {
            var c = new CharacterBase("Jesus", 70, 60, 50);

            c.Damage(20);  // 1st hit
            Assert.AreEqual(50, c.CurrentHP, "Damage is not applied properly");
            Assert.IsTrue(c.IsAlive, "Character should be alive");

            c.Damage(50); // 2nd hit
            Assert.AreEqual(0, c.CurrentHP, "Damage is not applied properly");
            Assert.IsFalse(c.IsAlive, "Character should be dead");

            c.Damage(50); // 3rd hit
            Assert.AreEqual(0, c.CurrentHP, "Damage is not applied properly");
            Assert.IsFalse(c.IsAlive, "Character should be dead");

            c.Damage(-25); // Recover Haalth
            Assert.AreEqual(25, c.CurrentHP, "Damage is not applied properly");
            Assert.IsTrue(c.IsAlive, "Character should be alive");
        }

        [TestMethod]
        public void TestAttack()
        {
            var c = new CharacterBase("Jesus", 70, 60, 50);

            c.Attack = -10; //
            Assert.AreEqual(1, c.Attack, "Attack is not set to minimum");

            c.Attack = 10;
            Assert.AreEqual(10, c.Attack, "Attack is not set properly");

            c.Attack = 101;
            Assert.AreEqual(100, c.Attack, "Attack is not set max");
        }

        [TestMethod]
        public void TestName()
        {
            var c = new CharacterBase("Jesus", 70, 60, 50);

            Assert.AreEqual("Jesus", c.Name, "Name is not set properly");

            c.Name = "";
            Assert.AreEqual("UNKNOWN", c.Name, "Name is not set to UNKNOWN");
        }

        [TestMethod]
        public void TestTotalHP()
        {
            var c = new CharacterBase("Jesus", 70, 60, 50);

            c.TotalHP = -10; //
            Assert.AreEqual(1, c.TotalHP, "Total HP is not set to minimum");
            Assert.IsTrue(c.IsAlive, "Character should be alive");

            c.TotalHP = 10;
            Assert.AreEqual(10, c.TotalHP, "Total HP is not set properly");
            Assert.IsTrue(c.IsAlive, "Character should be alive");

            c.TotalHP = 101;
            Assert.AreEqual(100, c.TotalHP, "Total HP is not set to max");
            Assert.IsTrue(c.IsAlive, "Character should be alive");
        }

        [TestMethod]
        public void TestDefense()
        {
            var c = new CharacterBase("Jesus", 70, 60, 50);

            c.Defense = -10; //
            Assert.AreEqual(0, c.Defense, "Defense is not set to minimum");

            c.Defense = 10;
            Assert.AreEqual(10, c.Defense, "Defense is not set properly");

            c.Defense = 101;
            Assert.AreEqual(100, c.Defense, "Defense is not set max");
        }
    }
}
