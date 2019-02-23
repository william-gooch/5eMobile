using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterRace
{
    public abstract class CharacterRace
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract Size Size { get; }
        public abstract int Speed { get; }

        public abstract AbilityScores AbilityScoresMod { get; }
    }
}
