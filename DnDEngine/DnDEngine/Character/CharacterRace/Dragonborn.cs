using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character
{
    public abstract partial class CharacterRace {
        public class Dragonborn : CharacterRace
        {
            public override string Name { get; } = "Dragonborn";
            public override string Description { get; } = "Born of dragons, as their name proclaims, the dragonborn walk proudly through a world that greets them with fearful incomprehension.";

            public override Size Size { get; } = Size.Medium;
            public override int Speed { get; } = 30;

            public override AbilityScores AbilityScoresMod { get; } = new AbilityScores(2, 0, 0, 0, 0, 1);

            public override List<CharacterTrait> CharacterTraits => new List<CharacterTrait>
            {
                new CharacterTrait("Draconic Ancestry", "You have draconic ancestry. Choose one type of dragon from the Draconic Ancestry table. Your breath weapon and damage resistance are determined by the dragon type, as shown in the table.")
            };
        }
    }
}
