using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public static class CharacterPresets
    {
        public static Character goblin = new Character("Goblin", new AbilityScores(8, 14, 10, 10, 8, 8), 15, 7);
        public static Character youngBlackDragon = new Character("Young Black Dragon", new AbilityScores(19, 14, 17, 12, 11, 15), 18, 127);
        public static Character bandit = new Character("Bandit", new AbilityScores(11, 12, 12, 10, 10, 10), 12, 11);
    }
}
