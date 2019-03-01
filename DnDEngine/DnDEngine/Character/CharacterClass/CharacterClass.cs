using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterClass
{
    /// <summary>
    /// Describes a character's class.
    /// Includes a name, a description, a Hit Dice, a set of skill proficiencies
    /// and saving throw proficiencies.
    /// All of these are abstract and can be overridden.
    /// </summary>
    public abstract class CharacterClass
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract Roll HitDice { get; }

        public abstract Skills SkillProficiencies { get; }
        public abstract SavingThrows SavingThrowProficiencies { get; }

        /// <summary>
        /// This means that an instance of this can be initialized in the constructor for a
        /// child class.
        /// </summary>
        protected CharacterClass() { }
    }
}
