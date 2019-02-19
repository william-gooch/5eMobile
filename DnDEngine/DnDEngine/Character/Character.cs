using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class Character
    {
        public string Name { get; private set; }

        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }

        public Character(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public Character Clone()
        {
            return new Character(Name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
        }
    }
}
