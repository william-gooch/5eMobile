using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class PlayerCharacter : Character
    {
        // A PC's armor class is 10 + their dexterity modifier.
        public override int ArmorClass => 10 + this.BaseAbilityScores.DexterityMod;
        public override int MaximumHitPoints => throw new NotImplementedException();

        public PlayerCharacter(string name, AbilityScores baseAbilityScores)
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
        }
    }
}
