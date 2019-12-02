using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character
{
    public partial class CharacterRace {
        public static CharacterRace Dragonborn() => _dragonborn.Clone();
        private static CharacterRace _dragonborn = new CharacterRace
        {
            Name = "Dragonborn",
            Description = "Born of dragons, as their name proclaims, the dragonborn walk proudly through a world that greets them with fearful incomprehension.",

            Size = Size.Medium,
            Speed = 30,

            AbilityScoresMod = new AbilityScores(2, 0, 0, 0, 0, 1),

            CharacterTraits = new List<CharacterTrait>
            {
                new CharacterTrait("Draconic Ancestry", "You have draconic ancestry. Choose one type of dragon from the Draconic Ancestry table. Your breath weapon and damage resistance are determined by the dragon type, as shown in the table.")
            }
        };
    }
}
