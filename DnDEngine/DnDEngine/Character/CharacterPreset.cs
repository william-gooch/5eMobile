using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    class CharacterPreset : Character
    {
        public override int ArmorClass { get; }
        public override int MaximumHitPoints { get; }

        public CharacterPreset(string name, AbilityScores baseAbilityScores, int armorClass, int maximumHitPoints)
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
            ArmorClass = armorClass;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
