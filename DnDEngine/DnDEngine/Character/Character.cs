using DnDEngine.Utilities;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("abilityScores")]
        public AbilityScores BaseAbilityScores { get; set; }

        public virtual int ArmorClass { get; }
        public virtual int MaximumHitPoints { get; }

        public virtual Skills SkillProficiencies { get; }
        public virtual SavingThrows SavingThrowProficiencies { get; }
        public virtual int ProficiencyBonus { get; }

        public Dictionary<string, Tuple<int,int>> Skills => GetSkills();

        protected List<CharacterTrait> characterTraits;
        public virtual List<CharacterTrait> CharacterTraits => characterTraits;

        protected Character() {
            characterTraits = new List<CharacterTrait>();
        }

        public Dictionary<string,Tuple<int,int>> GetSkills()
        {
            return (from item in Enum.GetNames(typeof(Skills))
                    select item).ToDictionary(
                        name => name, // key
                        name => Tuple.Create(
                            GetSkillScore(name),
                            (int)Math.Floor( (double)(GetSkillScore(name)-10)/2 )
                        ) // value
                    );
        }

        public int GetSkillScore(string skillName)
        {
            Skills skillValue = (Skills)Enum.Parse(typeof(Skills), skillName);
            int bonus = (skillValue & SkillProficiencies) != 0 ? ProficiencyBonus : 0;

            if ((skillValue & SkillTypes.Strength) != 0) {
                return BaseAbilityScores.Strength + bonus;
            } else if ((skillValue & SkillTypes.Dexterity) != 0) {
                return BaseAbilityScores.Dexterity + bonus;
            } else if ((skillValue & SkillTypes.Constitution) != 0) {
                return BaseAbilityScores.Constitution + bonus;
            } else if ((skillValue & SkillTypes.Intelligence) != 0) {
                return BaseAbilityScores.Intelligence + bonus;
            } else if ((skillValue & SkillTypes.Wisdom) != 0) {
                return BaseAbilityScores.Wisdom + bonus;
            } else if ((skillValue & SkillTypes.Charisma) != 0) {
                return BaseAbilityScores.Charisma + bonus;
            } else {
                return 0;
            }
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
