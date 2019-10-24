using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// The abstract class that represents a character.
    /// It has a name, base ability scores, an armor class and maximum hit points
    /// (that can both be overridden).
    /// It also has a dictionary of actions that the character can take.
    /// </summary>
    public abstract class Character
    {
        public string Name { get; set; }

        public AbilityScores BaseAbilityScores { get; set; }

        public virtual int ArmorClass { get; }
        public virtual int MaximumHitPoints { get; }

        protected List<CharacterTrait> characterTraits;
        public virtual List<CharacterTrait> CharacterTraits => characterTraits;

        protected Character() {
            characterTraits = new List<CharacterTrait>();
        }

        /// <summary>
        /// Clones the object, including the dictionary of character actions.
        /// </summary>
        /// <returns>The clone of this Character.</returns>
        public Character Clone()
        {
            Character clone = MemberwiseClone() as Character;
            clone.characterTraits = new List<CharacterTrait>(characterTraits);
            return clone;
        }
    }
}
