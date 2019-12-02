using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// Describes a character's background.
    /// Includes a name and a description that can both be overridden.
    /// </summary>
    public partial class CharacterBackground
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CharacterTrait> CharacterTraits { get; set; }

        public CharacterBackground Clone() => new CharacterBackground
        {
            Name = Name,
            Description = Description,
            CharacterTraits = new List<CharacterTrait>(CharacterTraits)
        };
    }
}
