using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterRace
{
    /// <summary>
    /// Describes the race of a character.
    /// Includes a name, a description, a size and speed, and
    /// some ability score modifier (not implemented yet)
    /// </summary>
    public abstract class CharacterRace
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract Size Size { get; }
        public abstract int Speed { get; }

        public abstract AbilityScores AbilityScoresMod { get; }
    }
}
