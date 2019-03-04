using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    /// <summary>
    /// An implementation of the Character class that describes a preset character.
    /// </summary>
    /// <example>An enemy like a goblin, or a villager like a blacksmith.</example>
    class CharacterPreset : Character
    {
        public override int ArmorClass { get; }
        public override int MaximumHitPoints { get; }

        /// <summary>
        /// This constructor creates a new preset.
        /// It can then be cloned using the Clone() method in the base class.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="baseAbilityScores">The character's ability scores.</param>
        /// <param name="armorClass">The character's armor class.</param>
        /// <param name="maximumHitPoints">The character's maximum hit points.</param>
        public CharacterPreset(string name, AbilityScores baseAbilityScores, int armorClass, int maximumHitPoints) : base()
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
            ArmorClass = armorClass;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
