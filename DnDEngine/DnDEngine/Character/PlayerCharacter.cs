using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DnDEngine.Character;

namespace DnDEngine.Character
{
    /// <summary>
    /// An implementation of the Character class.
    /// This is used for characters that are controlled by other players.
    /// As such, it has a race, a class and a background.
    /// </summary>
    public class PlayerCharacter : Character
    {
        // A PC's armor class is 10 + their dexterity modifier.
        public override int ArmorClass => 10 + this.BaseAbilityScores.DexterityMod;
        // A PC's max hit points is just the maximum roll of their hit dice (at level 1)
        public override int MaximumHitPoints => Class.HitDice.Max; // TODO: include leveling up

        public CharacterRace Race { get; }
        public CharacterClass Class { get; }
        public CharacterBackground Background { get; }

        public override List<CharacterTrait> CharacterTraits
        {
            get
            {
                return base.CharacterTraits
                    .Concat(Class.CharacterTraits)
                    .Concat(Race.CharacterTraits)
                    .Concat(Background.CharacterTraits).ToList();
            }
        }

        /// <summary>
        /// Creates a new instance of a PlayerCharacter.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="baseAbilityScores">The character's ability scores.</param>
        /// <param name="race">The character's race.</param>
        /// <param name="_class">The character's class.</param>
        /// <param name="background">The character's background.</param>
        public PlayerCharacter(string name, AbilityScores baseAbilityScores, CharacterRace race, CharacterClass _class, CharacterBackground background) : base()
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
            Race = race;
            Class = _class;
            Background = background;
        }
    }
}
