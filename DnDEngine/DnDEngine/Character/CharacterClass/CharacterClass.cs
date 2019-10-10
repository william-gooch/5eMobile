using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// Describes a character's class.
    /// Includes a name, a description, a Hit Dice, a set of skill proficiencies
    /// and saving throw proficiencies.
    /// All of these are abstract and can be overridden.
    /// </summary>
    public abstract partial class CharacterClass
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract Roll HitDice { get; }

        /// <summary>
        /// The number of levels of proficiency a character has in each skill.
        /// </summary>
        public abstract Dictionary<Skill,int> SkillProficiencies { get; }
        public abstract SavingThrows SavingThrowProficiencies { get; }

        public abstract List<CharacterTrait> CharacterTraits { get; }

        /// <summary>
        /// This means that an instance of this can be initialized in the constructor for a
        /// child class.
        /// </summary>
        protected CharacterClass() { }
    }
}
