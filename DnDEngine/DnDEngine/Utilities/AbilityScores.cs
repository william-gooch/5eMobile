using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    class AbilityScores
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Constitution { get; }
        public int Intelligence { get; }
        public int Wisdom { get; }
        public int Charisma { get; }

        public AbilityScores(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public static AbilityScores operator +(AbilityScores a, AbilityScores b)
        {
            return new AbilityScores(
                a.Strength + b.Strength,
                a.Dexterity + b.Dexterity,
                a.Constitution + b.Constitution,
                a.Intelligence + b.Intelligence,
                a.Wisdom + b.Wisdom,
                a.Charisma + b.Charisma
                );
        }

        public static AbilityScores operator -(AbilityScores a, AbilityScores b)
        {
            return new AbilityScores(
                a.Strength - b.Strength,
                a.Dexterity - b.Dexterity,
                a.Constitution - b.Constitution,
                a.Intelligence - b.Intelligence,
                a.Wisdom - b.Wisdom,
                a.Charisma - b.Charisma
                );
        }
    }
}
