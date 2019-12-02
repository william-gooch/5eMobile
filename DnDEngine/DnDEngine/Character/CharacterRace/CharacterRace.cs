using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// Describes the race of a character.
    /// Includes a name, a description, a size and speed, and
    /// some ability score modifier (not implemented yet)
    /// </summary>
    public partial class CharacterRace
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Size Size { get; set; }
        public int Speed { get; set; }

        public AbilityScores AbilityScoresMod { get; set; }

        public List<CharacterTrait> CharacterTraits { get; set; }

        public CharacterRace Clone() => new CharacterRace
        {
            Name = Name,
            Description = Description,
            Size = Size,
            Speed = Speed,
            AbilityScoresMod = AbilityScoresMod,
            CharacterTraits = new List<CharacterTrait>(CharacterTraits)
        };
    }
}
