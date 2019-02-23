using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character.CharacterRace
{
    public class CharacterRaceDragonborn : CharacterRace
    {
        public override string Name { get; } = "Dragonborn";
        public override string Description { get; } = "Born of dragons, as their name proclaims, the dragonborn walk proudly through a world that greets them with fearful incomprehension.";

        public override Size Size { get; } = Size.Medium;
        public override int Speed { get; } = 30;

        public override AbilityScores AbilityScoresMod { get; } = new AbilityScores(2, 0, 0, 0, 0, 1);
    }
}
