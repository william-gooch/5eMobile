using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class Character
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int ArmorClass { get; set; }
        public int MaximumHitPoints { get; set; }

        public Character(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int armorClass, int maximumHitPoints)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            ArmorClass = armorClass;
            MaximumHitPoints = maximumHitPoints;
        }

        public Character Clone()
        {
            return new Character(Name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, ArmorClass, MaximumHitPoints);
        }
    }
}
