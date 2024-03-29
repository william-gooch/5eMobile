﻿using System;
using DnDEngine.Character;
using DnDEngine.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnDTests
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void TestPlayerCharacter()
        {
            PlayerCharacter myCharacter = new PlayerCharacter(
                "Jorgen Windhelm",
                new AbilityScores(16, 9, 15, 11, 13, 14),
                new DnDEngine.Character.CharacterRace.Dragonborn(),
                new DnDEngine.Character.CharacterClass.Barbarian(),
                new DnDEngine.Character.CharacterBackground.Acolyte()
            );
            Assert.AreEqual(myCharacter.Name, "Jorgen Windhelm");
            Assert.AreEqual(myCharacter.Race.Name, "Dragonborn");
            Assert.AreEqual(myCharacter.ArmorClass, 9);
            Assert.AreEqual(myCharacter.MaximumHitPoints, 12);
        }

        [TestMethod]
        public void TestCharacterPreset()
        {
            Character myGoblin = CharacterPresets.goblin.Clone();
            Assert.AreEqual(myGoblin.ArmorClass, 15);
            Assert.AreEqual(myGoblin.Name, "Goblin");
        }

        [TestMethod]
        public void TestCharacterTraits()
        {
            Character myPC = new PlayerCharacter(
                "Jorgen Windhelm", new AbilityScores(16, 9, 15, 11, 13, 14),
                new CharacterRace.Dragonborn(),
                new CharacterClass.Barbarian(),
                new CharacterBackground.Acolyte()
                );
            Assert.IsTrue(myPC.CharacterTraits.Exists((trait) => trait.Name == "Unarmored Defense"));
        }
    }
}
