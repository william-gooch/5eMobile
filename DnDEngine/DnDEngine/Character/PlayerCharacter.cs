using DnDEngine.Utilities;
using DnDEngine.CharacterRace;
using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Character.CharacterBackground;
using DnDEngine.Character.CharacterClass;
using DnDEngine.Character.CharacterRace;

namespace DnDEngine.Character
{
    public class PlayerCharacter : Character
    {
        // A PC's armor class is 10 + their dexterity modifier.
        public override int ArmorClass => 10 + this.BaseAbilityScores.DexterityMod;
        public override int MaximumHitPoints => Class.HitDice.Max; // TODO: include leveling up

        public CharacterRace.CharacterRace Race { get; }
        public CharacterClass.CharacterClass Class { get; }
        public CharacterBackground.CharacterBackground Background { get; }

        public PlayerCharacter(string name, AbilityScores baseAbilityScores, CharacterRace.CharacterRace race, CharacterClass.CharacterClass _class, CharacterBackground.CharacterBackground background)
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
            Race = race;
            Class = _class;
            Background = background;
        }
    }
}
