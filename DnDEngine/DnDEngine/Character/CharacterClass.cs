using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class CharacterClass
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Roll HitDice { get; private set; }

        public Skills SkillProficiencies { get; private set; }
        public SavingThrows SavingThrowProficiencies { get; private set; }
    }
}
