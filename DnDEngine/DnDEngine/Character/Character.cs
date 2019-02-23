using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class Character
    {
        public string Name { get; set; }

        public AbilityScores BaseAbilityScores { get; set; }

        public int ArmorClass { get; set; }
        public int MaximumHitPoints { get; set; }

        public Character(string name, AbilityScores baseAbilityScores, int armorClass, int maximumHitPoints)
        {
            Name = name;
            BaseAbilityScores = baseAbilityScores;
            ArmorClass = armorClass;
            MaximumHitPoints = maximumHitPoints;
        }

        public Character Clone()
        {
            return new Character(Name, BaseAbilityScores, ArmorClass, MaximumHitPoints);
        }
    }
}
