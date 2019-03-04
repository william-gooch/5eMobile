using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// Represents a single trait that a character can have.
    /// </summary>
    public class CharacterTrait
    {
        public string Name { get; }
        public string Description { get; }

        public CharacterTrait(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
