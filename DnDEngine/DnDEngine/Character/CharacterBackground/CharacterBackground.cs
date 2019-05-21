using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterBackground
{
    /// <summary>
    /// Describes a character's background.
    /// Includes a name and a description that can both be overridden.
    /// </summary>
    public abstract class CharacterBackground
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract List<CharacterTrait> CharacterTraits { get; }
    }
}
