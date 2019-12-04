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
    public partial class CharacterClass
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Roll HitDice { get; set; }

        public Skills SkillProficiencies { get; set; }
        public SavingThrows SavingThrowProficiencies { get; set; }

        public List<CharacterTrait> CharacterTraits { get; set; }

        public CharacterClass Clone() => new CharacterClass
        {
            Name = Name,
            Description = Description,
            HitDice = HitDice,
            SkillProficiencies = SkillProficiencies,
            SavingThrowProficiencies = SavingThrowProficiencies,
            CharacterTraits = new List<CharacterTrait>(CharacterTraits)
        };
    }
}
