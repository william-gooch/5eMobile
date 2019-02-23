using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterClass
{
    public abstract class CharacterClass
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract Roll HitDice { get; }

        public abstract Skills SkillProficiencies { get; }
        public abstract SavingThrows SavingThrowProficiencies { get; }

        protected CharacterClass() { }
    }
}
